import React, { Fragment, useState } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import { Loading, CreateButton } from '@linn-it/linn-form-components-library';
import {
    Table,
    TableHead,
    TableBody,
    TablePagination,
    TableFooter,
    TableRow,
    TableCell
} from '@material-ui/core';
import { Link } from 'react-router-dom';
import EditIcon from '@material-ui/icons/Edit';

import TablePaginationActions from '../common/TablePaginationActions';
import { getSelfHref } from '../../helpers/utilities';
import Page from '../../containers/Page';

const actionsStyles = theme => ({
    root: {
        flexShrink: 0,
        color: theme.palette.text.secondary,
        marginLeft: theme.spacing.unit * 2.5
    }
});

const TablePaginationActionsWrapped = withStyles(actionsStyles, { withTheme: true })(
    TablePaginationActions
);

function SerialNumberTransactions({ page, loading, pageLoad }) {
    const [localPage, setLocalPage] = useState(0);
    const [rowsPerPage, setRowsPerPage] = useState(5);

    const identifySelfLink = row => getSelfHref(row);

    const handleChangePage = (event, pge) => {
        setLocalPage(pge);
        pageLoad(pge + 1, rowsPerPage); // page number must be incremented because the starting index on the server is 1
    };

    const handleChangeRowsPerPage = event => {
        setLocalPage(0);
        setRowsPerPage(event.target.value);
        pageLoad(localPage + 1, event.target.value);
    };

    return (
        <Page>
            {loading || !page? (
                <Loading />
            ) : (
                <Fragment>
                    <CreateButton createUrl="/products/maint/sales-packages/create" />
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Trans Code</TableCell>
                                <TableCell>Description</TableCell>
                                <TableCell>Actions</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {page.elements &&
                                page.elements.map((row, index) => (
                                    // there are duplicates in the live database so this is a workaround
                                    // we should not use the index as a key as it will impact on performance when sorting
                                    // eslint-disable-next-line react/no-array-index-key
                                    <Fragment key={row.transCode}>
                                        <TableRow
  
                                        >
                                            <TableCell component="th" scope="row">
                                                {row.transCode}
                                            </TableCell>
                                            <TableCell>{row.description}</TableCell>
                                            <TableCell>
                                                <Link
                                                    key={row.transCode}
                                                    to={identifySelfLink(row)}
                                                >
                                                    <EditIcon />
                                                </Link>
                                            </TableCell>
                                        </TableRow>
                                    </Fragment>
                                ))}
                        </TableBody>
                        <TableFooter>
                            {page.totalItemCount && (
                                <TableRow>
                                    <TablePagination
                                        rowsPerPageOptions={[5, 10, 25, 50]}
                                        count={page.totalItemCount}
                                        rowsPerPage={rowsPerPage}
                                        page={localPage}
                                        SelectProps={{
                                            native: true
                                        }}
                                        onChangePage={handleChangePage}
                                        onChangeRowsPerPage={handleChangeRowsPerPage}
                                        ActionsComponent={TablePaginationActionsWrapped}
                                    />
                                </TableRow>
                            )}
                        </TableFooter>
                    </Table>
                </Fragment>
            )}
        </Page>
    );
}

SerialNumberTransactions.propTypes = {
    page: PropTypes.PropTypes.shape({}).isRequired,
    loading: PropTypes.bool.isRequired,
    pageLoad: PropTypes.func.isRequired
};

export default SerialNumberTransactions;
