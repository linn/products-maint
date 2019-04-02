import React, { Fragment, useState } from 'react';
import PropTypes from 'prop-types';
import { Loading, CreateButton } from '@linn-it/linn-form-components-library';
import { Table, TableHead, TableRow, TableCell } from '@material-ui/core';
import Page from '../../containers/Page';

function SalesPackages({ items, loading, }) {

    const [rowOpen, setRowOpen] = useState();

    const handleRowOnClick = (salesPackageId) => {
        return (rowOpen === salesPackageId) ?
                                             setRowOpen(null) : setRowOpen(salesPackageId)
    }

    const style = {
        cursor: 'pointer'
    }

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
                                </TableRow>
                                {items.map(row => (
                                    <Fragment key={row.salesPackageId}>
                                        <TableRow style={style} hover={true} onClick={() => handleRowOnClick(row.salesPackageId)}>
                                            <TableCell component="th" scope="row"> {row.salesPackageId} </TableCell>
                                            <TableCell align="right">{row.description}</TableCell>
                                        </TableRow>
                                        {rowOpen === row.salesPackageId &&
                                            row.elements.map(element => (
                                                <tr key={element.elementType}>
                                                    Type: {element.elementType} Sequence: {element.sequence} Quantity: {element.quantity}
                                                </tr>
                                            ))
                                        }
                                    </Fragment>
                                ))}
                            </TableHead>
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
