import React, { useEffect, useState } from 'react';
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
    Grid
} from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';
import { getSernosNote } from '../selectors/sernosNotesSelectors';
import SernosNote from './SernosNote';
import Page from '../containers/Page';
import { sortEntityList, sortList } from '../helpers/utilities';

const useStyles = makeStyles(theme => ({
    marginTop: {
        marginTop: theme.spacing(3)
    },
    createButton: {
        float: 'right',
        paddingTop: theme.spacing(3)
    }
}));

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

    const classes = useStyles();

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

    return (
        <Page>
            {errorMessage && <ErrorCard errorMessage={errorMessage} />}
            <Title text="Serial Numbers" />

            <Grid container>
                <Grid item xs={4}>
                    <SearchInputField
                        label="Search by Serial Number"
                        fullWidth
                        placeholder="Serial Number"
                        onChange={handleSearchTermChange}
                        propertyName="searchTerm"
                        type="number"
                        value={searchTerm}
                    />
                </Grid>
                <Grid item xs={8}>
                    <CreateButton createUrl="/products/maint/serial-numbers/create" />
                </Grid>
            </Grid>

            {loading || sernosNoteLoading || sernosNotesLoading ? (
                <Loading />
            ) : (
                items.length > 0 && (
                    <>
                        <SnackbarMessage
                            visible={snackbarVisible}
                            onClose={() => setSnackbarVisible(false)}
                            message="Save Successful"
                        />

                        <Grid container>
                            <Grid item xs={4} className={classes.marginTop}>
                                <Dropdown
                                    value={selectedSernosGroup || ''}
                                    label="Filter by Sernos Group"
                                    fullWidth
                                    items={sernosGroups}
                                    onChange={handleSalesArticleChange}
                                    propertyName="serialNumbered"
                                />
                            </Grid>
                        </Grid>

                        <Table size="small" className={classes.marginTop}>
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
                                    .map((item, i) => (
                                        <SernosNote
                                            // eslint-disable-next-line react/no-array-index-key
                                            key={`${item.sernosDate}${item.articleNumber}${item.transCode}${item.sernosNumber}-${i}`}
                                            serialNumber={item}
                                            item={getSernosNote(sernosNotes, item)}
                                            addSernosNote={addSernosNote}
                                            updateSernosNote={updateSernosNote}
                                        />
                                    ))}
                            </TableBody>
                        </Table>
                    </>
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
