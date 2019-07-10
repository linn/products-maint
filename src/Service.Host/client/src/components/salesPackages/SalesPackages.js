import React, { Fragment, useState } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import {
    Loading,
    CreateButton,
    ErrorCard,
    getSelfHref
} from '@linn-it/linn-form-components-library';
import {
    Link,
    Table,
    TableHead,
    TableBody,
    TablePagination,
    TableFooter,
    TableRow,
    TableCell,
    TableSortLabel
} from '@material-ui/core';
import makeStyles from '@material-ui/styles/makeStyles';
import EditIcon from '@material-ui/icons/Edit';

import TablePaginationActions from '../common/TablePaginationActions';
import Page from '../../containers/Page';

const actionsStyles = theme => ({
    root: {
        flexShrink: 0,
        color: theme.palette.text.secondary,
        marginLeft: theme.spacing(2)
    }
});

const useStyles = makeStyles(() => ({
    link: {
        '&:hover': {
            cursor: 'pointer'
        }
    }
}));

const TablePaginationActionsWrapped = withStyles(actionsStyles, { withTheme: true })(
    TablePaginationActions
);

function SalesPackages({ page, loading, pageLoad, pageSortedLoad, errorMessage, history }) {
    const [rowOpen, setRowOpen] = useState();
    const [localPage, setLocalPage] = useState(0);
    const [localOrderBy, setOrderBy] = useState();
    const [asc, setAsc] = useState(false);
    const [rowsPerPage, setRowsPerPage] = useState(5);

    const classes = useStyles();

    const handleRowOnClick = salesPackageId =>
        rowOpen === salesPackageId ? setRowOpen(null) : setRowOpen(salesPackageId);

    const cursor = {
        cursor: 'pointer'
    };

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

    const createSortHandler = property => {
        setOrderBy(property);
        setAsc(!asc);
        pageSortedLoad(localPage + 1, rowsPerPage, property, asc);
    };

    return (
        <Page>
            {errorMessage && <ErrorCard errorMessage={errorMessage} />}
            {loading ? (
                <Loading />
            ) : (
                <Fragment>
                    <CreateButton createUrl="/products/maint/sales-packages/create" />
                    <Table size="small">
                        <TableHead>
                            <TableRow>
                                <TableCell
                                    sortDirection={localOrderBy === 'salesPackageId' ? asc : false}
                                >
                                    <TableSortLabel
                                        active={localOrderBy === 'salesPackageId'}
                                        direction={asc ? 'asc' : 'desc'}
                                        onClick={() => createSortHandler('salesPackageId')}
                                    >
                                        Sales Package Id
                                    </TableSortLabel>
                                </TableCell>
                                <TableCell
                                    sortDirection={localOrderBy === 'description' ? asc : false}
                                >
                                    <TableSortLabel
                                        active={localOrderBy === 'description'}
                                        direction={asc ? 'asc' : 'desc'}
                                        onClick={() => createSortHandler('description')}
                                    >
                                        Description
                                    </TableSortLabel>
                                </TableCell>
                                <TableCell>Actions</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {page.elements &&
                                page.elements.map((row, index) => (
                                    // there are duplicates in the live database so this is a workaround
                                    // we should not use the index as a key as it will impact on performance when sorting
                                    // eslint-disable-next-line react/no-array-index-key
                                    <Fragment key={row.salesPackageId + index}>
                                        <TableRow
                                            style={cursor}
                                            hover
                                            onClick={() => handleRowOnClick(row.salesPackageId)}
                                        >
                                            <TableCell component="th" scope="row">
                                                {row.salesPackageId}
                                            </TableCell>
                                            <TableCell>{row.description}</TableCell>
                                            <TableCell>
                                                <Link
                                                    key={row.salesPackageId}
                                                    to={identifySelfLink(row)}
                                                    classes={{ root: classes.link }}
                                                    variant="button"
                                                    onClick={() =>
                                                        history.push(identifySelfLink(row))
                                                    }
                                                >
                                                    <EditIcon />
                                                </Link>
                                            </TableCell>
                                        </TableRow>
                                        {rowOpen === row.salesPackageId &&
                                            row.elements
                                                .sort((a, b) => a.sequence - b.sequence)
                                                .map(element => (
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

SalesPackages.propTypes = {
    page: PropTypes.PropTypes.shape({}).isRequired,
    loading: PropTypes.bool.isRequired,
    pageLoad: PropTypes.func.isRequired,
    pageSortedLoad: PropTypes.func.isRequired,
    errorMessage: PropTypes.string,
    history: PropTypes.shape({}).isRequired
};

SalesPackages.defaultProps = {
    errorMessage: ''
};

export default SalesPackages;
