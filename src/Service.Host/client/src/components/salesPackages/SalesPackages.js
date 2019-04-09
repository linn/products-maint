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

function SalesPackages({ items, loading, initialise }) {
    const [rowOpen, setRowOpen] = useState();
    const [page, setPage] = useState(0);
    const [rowsPerPage, setRowsPerpage] = useState(5);

    const handleRowOnClick = salesPackageId =>
        rowOpen === salesPackageId ? setRowOpen(null) : setRowOpen(salesPackageId);

    const cursor = {
        cursor: 'pointer'
    };

    const identifySelfLink = row => getSelfHref(row);

    const handleChangePage = (event, pge) => {
        setPage(pge);
        initialise({ page, rowsPerPage });
    };

    const handleChangeRowsPerPage = event => {
        setPage(0);
        setRowsPerpage(event.target.value);
        initialise({ page, rowsPerPage });
    };

    return (
        <Page>
            {loading ? (
                <Loading />
            ) : (
                <Fragment>
                    <CreateButton createUrl="/products/maint/sales-packages/create" />
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Sales Package Id</TableCell>
                                <TableCell align="right">Description</TableCell>
                                <TableCell align="right">Actions</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {items
                                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                                .map(row => (
                                    <Fragment key={row.salesPackageId}>
                                        <TableRow
                                            style={cursor}
                                            hover
                                            onClick={() => handleRowOnClick(row.salesPackageId)}
                                        >
                                            <TableCell component="th" scope="row">
                                                {row.salesPackageId}
                                            </TableCell>
                                            <TableCell align="right">{row.description}</TableCell>
                                            <TableCell align="right">
                                                <Link
                                                    key={row.salesPackageId}
                                                    to={identifySelfLink(row)}
                                                >
                                                    <EditIcon />
                                                </Link>
                                            </TableCell>
                                        </TableRow>
                                        {rowOpen === row.salesPackageId &&
                                            row.elements.map(element => (
                                                <tr key={element.elementType}>
                                                    <TableCell>
                                                        Type: {element.elementType}
                                                    </TableCell>
                                                    <TableCell>
                                                        Sequence: {element.sequence}
                                                    </TableCell>
                                                    <TableCell>
                                                        Quantity: {element.quantity}
                                                    </TableCell>
                                                </tr>
                                            ))}
                                    </Fragment>
                                ))}
                        </TableBody>
                        <TableFooter>
                            <TableRow>
                                <TablePagination
                                    rowsPerPageOptions={[5, 10]}
                                    colSpan={3}
                                    count={items.length}
                                    rowsPerPage={rowsPerPage}
                                    page={page}
                                    SelectProps={{
                                        native: true
                                    }}
                                    onChangePage={handleChangePage}
                                    onChangeRowsPerPage={handleChangeRowsPerPage}
                                    ActionsComponent={TablePaginationActionsWrapped}
                                />
                            </TableRow>
                        </TableFooter>
                    </Table>
                </Fragment>
            )}
        </Page>
    );
}

SalesPackages.propTypes = {
    items: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired,
    initialise: PropTypes.func.isRequired
};

export default SalesPackages;
