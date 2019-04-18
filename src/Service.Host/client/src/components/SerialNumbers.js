import React, { useEffect, useState, Fragment } from 'react';
import PropTypes from 'prop-types';
import {
    CreateButton,
    Dropdown,
    Loading,
    SearchInputField,
    SnackbarMessage,
    Title,
    useSearch
} from '@linn-it/linn-form-components-library';
import { Typography, Table, TableHead, TableRow, TableCell, TableBody } from '@material-ui/core';
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
    setSnackbarVisible
}) {
    const [searchTerm, setSearchTerm] = useState('');
    const [sernosGroups, setSernosGroups] = useState([]);
    const [selectedSernosGroup, setSelectedSernosGroup] = useState('');

    useSearch(fetchItems, searchTerm, 'sernosNumber');

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

    return (
        <Page>
            <Title text="Serial Numbers" />
            <SearchInputField
                label="Search by Serial Number"
                placeholder="Serial Number"
                onChange={handleSearchTermChange}
                value={searchTerm}
            />

            <CreateButton createUrl="/products/maint/serial-numbers/create" />

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
                                    .map(item => (
                                        <SernosNote
                                            key={item.sernosTRef}
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
    setSnackbarVisible: PropTypes.func.isRequired
};

SerialNumbers.defaultProps = {
    sernosNotes: [],
    sernosNoteLoading: false,
    sernosNotesLoading: false,
    snackbarVisible: false
};

export default SerialNumbers;
