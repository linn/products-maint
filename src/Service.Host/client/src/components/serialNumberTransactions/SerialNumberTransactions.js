import React, { Fragment, useState } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import {
    Loading,
    CreateButton,
    getSelfHref,
    ErrorCard,
    Title
} from '@linn-it/linn-form-components-library';
import {
    Link,
    Table,
    TableHead,
    TableBody,
    TablePagination,
    TableFooter,
    TableRow,
    TableCell
} from '@material-ui/core';
import EditIcon from '@material-ui/icons/Edit';

import TablePaginationActions from '../common/TablePaginationActions';
import Page from '../../containers/Page';

const actionsStyles = theme => ({
    root: {
        flexShrink: 0,
        color: theme.palette.text.secondary,
        marginLeft: theme.spacing(2.5)
    }
});

const styles = {
    link: {
        '&:hover': {
            cursor: 'pointer'
        }
    }
};

const TablePaginationActionsWrapped = withStyles(actionsStyles, { withTheme: true })(
    TablePaginationActions
);

function SerialNumberTransactions({ page, loading, pageLoad, errorMessage, classes, history }) {
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
            <Title text="Serial Number Transactions" />
            {errorMessage && <ErrorCard errorMessage={errorMessage} />}

            {loading || !page ? (
                <Loading />
            ) : (
                <Fragment>
                    <CreateButton createUrl="/products/maint/serial-number-transactions/create" />
                    <Table size="small">
                        <TableHead>
                            <TableRow>
                                <TableCell>Trans Code</TableCell>
                                <TableCell>Description</TableCell>
                                <TableCell>Actions</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {page.elements &&
                                page.elements.map(row => (
                                    <Fragment key={row.transCode}>
                                        <TableRow>
                                            <TableCell component="th" scope="row">
                                                {row.transCode}
                                            </TableCell>
                                            <TableCell>{row.description}</TableCell>
                                            <TableCell>
                                                <Link
                                                    key={row.transCode}
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
    pageLoad: PropTypes.func.isRequired,
    history: PropTypes.shape({}).isRequired,
    classes: PropTypes.shape({}).isRequired,
    errorMessage: PropTypes.string
};

SerialNumberTransactions.defaultProps = {
    errorMessage: ''
};

export default withStyles(styles)(SerialNumberTransactions);
