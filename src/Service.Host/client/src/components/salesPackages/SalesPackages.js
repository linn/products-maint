import React, { Fragment, useState } from 'react';
import PropTypes from 'prop-types';
import { Loading, CreateButton } from '@linn-it/linn-form-components-library';
import { Table, TableHead, TableBody, TableRow, TableCell } from '@material-ui/core';
import { Link } from 'react-router-dom';
import EditIcon from '@material-ui/icons/Edit';
import Page from '../../containers/Page';

function SalesPackages({ items, loading }) {
    const [rowOpen, setRowOpen] = useState();

    const handleRowOnClick = salesPackageId =>
        rowOpen === salesPackageId ? setRowOpen(null) : setRowOpen(salesPackageId);

    const cursor = {
        cursor: 'pointer'
    };

    const identifySelfLink = row => {
        const selfLink = row.links.find(link => link.rel === 'self');
        return selfLink.href;
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
                            {items.map(row => (
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
                                                <TableCell>Type: {element.elementType}</TableCell>
                                                <TableCell>Sequence: {element.sequence}</TableCell>
                                                <TableCell>Quantity: {element.quantity}</TableCell>
                                            </tr>
                                        ))}
                                </Fragment>
                            ))}
                        </TableBody>
                    </Table>
                </Fragment>
            )}
        </Page>
    );
}

SalesPackages.propTypes = {
    items: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired
};

export default SalesPackages;
