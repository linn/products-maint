import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Loading, CreateButton } from '@linn-it/linn-form-components-library';
import { Table, TableHead, TableRow, TableCell } from '@material-ui/core';
import Page from '../../containers/Page';

const SalesPackages = ({ items, loading }) => (
    <Page>
        {loading ? (
            <Loading />
        ) : (
                <Fragment>
                    <CreateButton createUrl="/products/maint/sales-packages/create" />
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Sales Bundle Id</TableCell>
                                <TableCell align="right">Description</TableCell>
                                <TableCell align="right">Bridge Id</TableCell>
                            </TableRow>
                            {loading && <Loading></Loading>}
                            {!loading && <TableRow>
                                {items.map(row => (
                                    <TableRow key={row.salesPackageId}>
                                        <TableCell component="th" scope="row">
                                            {row.salesPackageId}
                                        </TableCell>
                                        <TableCell align="right">{row.description}</TableCell>
                                        <TableCell align="right">{row.bridgeId}</TableCell>
                                    </TableRow>
                                ))}
                            </TableRow>}
                        </TableHead>
                    </Table>
                </Fragment>
            )}
    </Page>
);

SalesPackages.propTypes = {
    items: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired
};

export default SalesPackages;
