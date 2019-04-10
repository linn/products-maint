import React, { useEffect, useState, useRef, Fragment } from 'react';
import PropTypes from 'prop-types';
import { Dropdown, Loading, Title } from '@linn-it/linn-form-components-library';
import {
    TextField,
    InputAdornment,
    Typography,
    Table,
    TableHead,
    TableRow,
    TableCell,
    TableBody
} from '@material-ui/core';
import { getSernosNote } from '../selectors/sernosNotesSelectors';
import SerialNumber from './SerialNumber';
import Page from '../containers/Page';

function SerialNumbers({
    items,
    loading,
    fetchItems,
    sernosNotes,
    addSernosNote,
    updateSernosNote
}) {
    const [searchTerm, setSearchTerm] = useState('');
    const [salesArticles, setSalesArticles] = useState([]);
    const [selectedArticle, setSelectedArticle] = useState('');
    const [debounceTimer, setDebounceTimer] = useState(null);

    const savedFetchItems = useRef();
    const savedDebounceTimer = useRef();

    useEffect(() => {
        savedFetchItems.current = fetchItems;
    }, [fetchItems]);

    useEffect(() => {
        savedDebounceTimer.current = debounceTimer;
    }, [debounceTimer]);

    useEffect(() => {
        if (items.length) {
            const articles = [];
            items.map(
                item => !articles.includes(item.articleNumber) && articles.push(item.articleNumber)
            );
            setSalesArticles(articles);
            setSelectedArticle(articles[0] || '');
        }
    }, [items]);

    useEffect(() => {
        if (searchTerm) {
            if (savedDebounceTimer.current) {
                clearTimeout(savedDebounceTimer.current);
            }

            setDebounceTimer(
                setTimeout(() => savedFetchItems.current('sernosNumber', searchTerm), 500)
            );
        } else if (savedDebounceTimer.current) {
            clearTimeout(savedDebounceTimer.current);
        }
    }, [searchTerm]);

    const handleSalesArticleChange = (...args) => {
        setSelectedArticle(args[1]);
    };

    const handleSearchTermChange = e => {
        setSearchTerm(e.target.value);
    };

    return (
        <Page>
            <Title text="Amend Serial Number" />
            <TextField
                label="Search by Serial Number"
                placeholder="Serial Number"
                type="search"
                margin="normal"
                variant="outlined"
                onChange={e => handleSearchTermChange(e)}
                InputProps={{
                    startAdornment: (
                        <InputAdornment position="start">
                            <svg
                                xmlns="http://www.w3.org/2000/svg"
                                width="24"
                                height="24"
                                viewBox="0 0 24 24"
                            >
                                <path d="M15.5 14h-.79l-.28-.27C15.41 12.59 16 11.11 16 9.5 16 5.91 13.09 3 9.5 3S3 5.91 3 9.5 5.91 16 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z" />
                            </svg>
                        </InputAdornment>
                    )
                }}
            />

            {loading && <Loading />}

            {!loading && items.length > 0 && (
                <Fragment>
                    <Dropdown
                        value={selectedArticle}
                        label=""
                        fullWidth
                        items={salesArticles}
                        onChange={handleSalesArticleChange}
                        propertyName="serialNumbered"
                    />

                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Date </TableCell>
                                <TableCell align="right">Trans</TableCell>
                                <TableCell align="right">Document</TableCell>
                                <TableCell align="right">Article No</TableCell>
                                <TableCell align="right">Comments</TableCell>
                                <TableCell />
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {items
                                .filter(item => item.articleNumber === selectedArticle)
                                .map(item => (
                                    <SerialNumber
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
    addSernosNote: PropTypes.func.isRequired,
    updateSernosNote: PropTypes.func.isRequired
};

SerialNumbers.defaultProps = {
    sernosNotes: []
};

export default SerialNumbers;
