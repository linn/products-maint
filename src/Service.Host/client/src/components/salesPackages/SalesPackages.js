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
import IconButton from '@material-ui/core/IconButton';
import FirstPageIcon from '@material-ui/icons/FirstPage';
import KeyboardArrowLeft from '@material-ui/icons/KeyboardArrowLeft';
import KeyboardArrowRight from '@material-ui/icons/KeyboardArrowRight';
import LastPageIcon from '@material-ui/icons/LastPage';
import { getSelfHref } from '../../helpers/utilities';
import Page from '../../containers/Page';

const actionsStyles = theme => ({
    root: {
        flexShrink: 0,
        color: theme.palette.text.secondary,
        marginLeft: theme.spacing.unit * 2.5
    }
});

class TablePaginationActions extends React.Component {
    handleFirstPageButtonClick = event => {
        this.props.onChangePage(event, 0);
    };

    handleBackButtonClick = event => {
        this.props.onChangePage(event, this.props.page - 1);
    };

    handleNextButtonClick = event => {
        this.props.onChangePage(event, this.props.page + 1);
    };

    handleLastPageButtonClick = event => {
        this.props.onChangePage(
            event,
            Math.max(0, Math.ceil(this.props.count / this.props.rowsPerPage) - 1)
        );
    };

    render() {
        const { classes, count, page, rowsPerPage, theme } = this.props;

        return (
            <div className={classes.root}>
                <IconButton
                    onClick={this.handleFirstPageButtonClick}
                    disabled={page === 0}
                    aria-label="First Page"
                >
                    {theme.direction === 'rtl' ? <LastPageIcon /> : <FirstPageIcon />}
                </IconButton>
                <IconButton
                    onClick={this.handleBackButtonClick}
                    disabled={page === 0}
                    aria-label="Previous Page"
                >
                    {theme.direction === 'rtl' ? <KeyboardArrowRight /> : <KeyboardArrowLeft />}
                </IconButton>
                <IconButton
                    onClick={this.handleNextButtonClick}
                    disabled={page >= Math.ceil(count / rowsPerPage) - 1}
                    aria-label="Next Page"
                >
                    {theme.direction === 'rtl' ? <KeyboardArrowLeft /> : <KeyboardArrowRight />}
                </IconButton>
                <IconButton
                    onClick={this.handleLastPageButtonClick}
                    disabled={page >= Math.ceil(count / rowsPerPage) - 1}
                    aria-label="Last Page"
                >
                    {theme.direction === 'rtl' ? <FirstPageIcon /> : <LastPageIcon />}
                </IconButton>
            </div>
        );
    }
}
TablePaginationActions.propTypes = {
    classes: PropTypes.shape({}).isRequired,
    count: PropTypes.number.isRequired,
    onChangePage: PropTypes.func.isRequired,
    page: PropTypes.number.isRequired,
    rowsPerPage: PropTypes.number.isRequired,
    theme: PropTypes.shape({}).isRequired
};

const TablePaginationActionsWrapped = withStyles(actionsStyles, { withTheme: true })(
    TablePaginationActions
);

function SalesPackages({ items, loading, rowsPerPage, page }) {
    const [rowOpen, setRowOpen] = useState();
    const [pageLocal, setPage] = useState({});

    const handleRowOnClick = salesPackageId =>
        rowOpen === salesPackageId ? setRowOpen(null) : setRowOpen(salesPackageId);

    const cursor = {
        cursor: 'pointer'
    };

    const identifySelfLink = row => getSelfHref(row);

    const handleChangePage = (event, pge) => {
        setPage({ pge });
    };

    const handleChangeRowsPerPage = event => {
        setPage({ page: 0, rowsPerPage: event.target.value });
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
                                    rowsPerPageOptions={[5, 10, 25]}
                                    colSpan={3}
                                    count={items.length}
                                    rowsPerPage={rowsPerPage}
                                    page={pageLocal}
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
    rowsPerPage: PropTypes.number.isRequired,
    page: PropTypes.number.isRequired
};

export default SalesPackages;
