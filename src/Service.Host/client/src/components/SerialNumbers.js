import React, { useEffect, useState, Fragment } from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Dropdown, Loading, Title } from '@linn-it/linn-form-components-library';
import {
    TextField,
    Button,
    Typography,
    Table,
    TableHead,
    TableRow,
    TableCell,
    TableBody
} from '@material-ui/core';
import Page from '../containers/Page';

function SerialNumbers({ items, loading, fetchItems }) {
    const [searchTerm, setSearchTerm] = useState('');
    const [selectedArticle, setSelectedArticle] = useState('');

    const selectSalesArticleList = () => {
        const articleNumbers = [];
        items.map(
            item =>
                !articleNumbers.includes(item.articleNumber) &&
                articleNumbers.push(item.articleNumber)
        );
        return articleNumbers;
    };

    useEffect(() => {
        if (items.length) {
            setSelectedArticle(selectSalesArticleList()[0]);
        }
        // if (item !== prevSernosSequence) {
        //     setSernosSequence(item);
        //     setPrevSernosSequence(item);
        // }
    }, [items]);

    const handleFieldChange = (propertyName, newValue) => {
        setSelectedArticle(newValue);
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
                onChange={e => setSearchTerm(e.target.value)}
            />

            <Button onClick={() => fetchItems('sernosNumber', searchTerm)}>Search</Button>

            {loading && <Loading />}

            {!loading && items.length > 0 && (
                <Fragment>
                    <Dropdown
                        value={selectedArticle}
                        label=""
                        fullWidth
                        items={selectSalesArticleList()}
                        onChange={handleFieldChange}
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
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {items
                                .filter(item => item.articleNumber === selectedArticle)
                                .map(row => (
                                    <TableRow key={row.sernosTref}>
                                        <TableCell component="th" scope="row">
                                            {row.sernosDate
                                                ? moment(row.sernosDate).format('YYYY-MM-DD')
                                                : ''}
                                        </TableCell>
                                        <TableCell align="right">{row.transCode}</TableCell>
                                        <TableCell align="right">{row.documentNumber}</TableCell>
                                        <TableCell align="right">{row.articleNumber}</TableCell>
                                        <TableCell align="right">{row.comment}</TableCell>
                                    </TableRow>
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
    fetchItems: PropTypes.func.isRequired
};

export default SerialNumbers;
