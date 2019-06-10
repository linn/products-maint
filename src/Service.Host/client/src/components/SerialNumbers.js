import React, { useEffect, useState, Fragment } from 'react';
import PropTypes from 'prop-types';
import {
    CreateButton,
    Dropdown,
    Loading,
    SearchInputField,
    SnackbarMessage,
    Title,
    ErrorCard,
    useSearch
} from '@linn-it/linn-form-components-library';
import {
    Typography,
    Table,
    TableHead,
    TableRow,
    TableCell,
    TableBody,
    Tooltip
} from '@material-ui/core';
import { getSernosNote } from '../selectors/sernosNotesSelectors';
import SernosNote from './SernosNote';
import Page from '../containers/Page';
import { sortEntityList, sortList } from '../helpers/utilities';

function SerialNumbers({
    items,
    loading,
    fetchItems,
    sernosNotes,
    snackbarVisible,
    sernosNoteLoading,
    sernosNotesLoading,
    addSernosNote,
    updateSernosNote,
    setSnackbarVisible,
    errorMessage
}) {
    const [searchTerm, setSearchTerm] = useState(null);
    const [sernosGroups, setSernosGroups] = useState([]);
    const [selectedSernosGroup, setSelectedSernosGroup] = useState('');

    useSearch(fetchItems, searchTerm, null, 'sernosNumber');

    useEffect(() => {
        if (items.length) {
            const groups = [];
            items.map(item => !groups.includes(item.sernosGroup) && groups.push(item.sernosGroup));
            const sortedGroups = sortList(groups);
            setSernosGroups(sortedGroups);
            setSelectedSernosGroup(sortedGroups[0] || '');
        }
    }, [items]);

    const handleSalesArticleChange = (...args) => {
        setSelectedSernosGroup(args[1]);
    };

    const handleSearchTermChange = (...args) => {
        setSearchTerm(args[1]);
    };

    const canAmendOrCreateSerialNumbers = () => {
        if (items.links) {
            return items.links.some(l => l.rel === 'amend-create-serial-number');
        }
        return false;
    };

    const tooltipText = () =>
        canAmendOrCreateSerialNumbers() ? '' : 'You are not authorised to complete this action';

    return (
        <Page>
            {errorMessage && <ErrorCard errorMessage={errorMessage} />}
            <Title text="Serial Numbers" />

            <SearchInputField
                label="Search by Serial Number"
                placeholder="Serial Number"
                onChange={handleSearchTermChange}
                propertyName="searchTerm"
                type="number"
                value={searchTerm}
            />

            <Tooltip title={tooltipText()} placement="top-end" disableFocusListener>
                <span style={{ float: 'right' }}>
                    <CreateButton
                        disabled={!canAmendOrCreateSerialNumbers()}
                        createUrl="/products/maint/serial-numbers/create"
                    />
                </span>
            </Tooltip>

            {loading || sernosNoteLoading || sernosNotesLoading ? (
                <Loading />
            ) : (
                items.length > 0 && (
                    <Fragment>
                        <SnackbarMessage
                            visible={snackbarVisible}
                            onClose={() => setSnackbarVisible(false)}
                            message="Save Successful"
                        />

                        <Dropdown
                            value={selectedSernosGroup || ''}
                            label="Filter by Sernos Group"
                            fullWidth
                            items={sernosGroups.length ? sernosGroups : ['']}
                            onChange={handleSalesArticleChange}
                            propertyName="serialNumbered"
                        />

                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell>Sernos Date</TableCell>
                                    <TableCell>Trans Code</TableCell>
                                    <TableCell>Document Number</TableCell>
                                    <TableCell>Article Number</TableCell>
                                    <TableCell>Notes</TableCell>
                                    <TableCell />
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {sortEntityList(items, 'sernosDate')
                                    .filter(item => item.sernosGroup === selectedSernosGroup)
                                    .map((item, index) => (
                                        <SernosNote
                                            // eslint-disable-next-line react/no-array-index-key
                                            key={`${item.sernosDate}${item.articleNumber}${
                                                item.transCode
                                            }${index}`}
                                            serialNumber={item}
                                            item={getSernosNote(sernosNotes, item)}
                                            addSernosNote={addSernosNote}
                                            updateSernosNote={updateSernosNote}
                                        />
                                    ))}
                            </TableBody>
                        </Table>
                    </Fragment>
                )
            )}

            {!loading && searchTerm && !items.length && <Typography>No matching items</Typography>}
        </Page>
    );
}

SerialNumbers.propTypes = {
    items: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired,
    fetchItems: PropTypes.func.isRequired,
    sernosNotes: PropTypes.arrayOf(PropTypes.shape({})),
    sernosNoteLoading: PropTypes.bool,
    sernosNotesLoading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    addSernosNote: PropTypes.func.isRequired,
    updateSernosNote: PropTypes.func.isRequired,
    setSnackbarVisible: PropTypes.func.isRequired,
    errorMessage: PropTypes.string
};

SerialNumbers.defaultProps = {
    sernosNotes: [],
    sernosNoteLoading: false,
    sernosNotesLoading: false,
    snackbarVisible: false,
    errorMessage: ''
};

export default SerialNumbers;
