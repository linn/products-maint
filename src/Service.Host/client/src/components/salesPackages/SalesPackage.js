import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Grid, Table, TableBody, TableHead, TableRow, TableCell } from '@material-ui/core';
import {
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage
} from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

function SalesPackage({
    item,
    editStatus,
    setEditStatus,
    errorMessage,
    itemId,
    update,
    history,
    add,
    loading,
    snackbarVisible,
    setSnackbarVisible
}) {
    const [salesPackage, setSalesPackage] = useState({});
    const [prevSalesPackage, setPrevSalesPackage] = useState({});

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';
    const cursor = {
        cursor: 'pointer'
    };
    useEffect(() => {
        if (!creating() && item !== prevSalesPackage) {
            setSalesPackage(item);
            setPrevSalesPackage(item);
        }
    });

    const inputInvalid = () => !salesPackage.salesPackageId || !salesPackage.description;

    const handleSaveClick = () => {
        if (editing()) {
            update(itemId, salesPackage);
            setEditStatus('view');
        } else if (creating()) {
            add(salesPackage);
        }
    };

    const handleCancelClick = () => {
        setSalesPackage(item);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/maint/sales-packages');
    };

    const handleFieldChange = (propertyName, newValue) => {
        setEditStatus('edit');
        setSalesPackage({ ...salesPackage, [propertyName]: newValue });
    };

    const handleElementChange = (propertyName, newValue) => {
        setEditStatus('edit');
        const splitIndex = propertyName.indexOf(',');
        const index = propertyName.slice(0, splitIndex);
        const prop = propertyName.slice(splitIndex + 1);
        const { elements } = salesPackage;
        elements[index][prop] = newValue;
        setSalesPackage({ ...salesPackage, elements });
    };

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Add Sales Package" />
                    ) : (
                        <Title text="Sales Package Details" />
                    )}
                </Grid>
                {loading || (!item && !creating()) ? (
                    <Grid item xs={12}>
                        <Loading />
                    </Grid>
                ) : (
                    <Fragment>
                        {errorMessage && (
                            <Grid item xs={12}>
                                <ErrorCard errorMessage={errorMessage} />
                            </Grid>
                        )}
                        <SnackbarMessage
                            visible={snackbarVisible}
                            onClose={() => setSnackbarVisible(false)}
                            message="Save Successful"
                        />
                        <Grid item xs={4}>
                            <InputField
                                fullWidth
                                disabled={!creating()}
                                value={salesPackage.salesPackageId}
                                label="Sales Package Id"
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : 'This field is required'
                                }
                                maxLength={14}
                                onChange={handleFieldChange}
                                propertyName="salesPackageId"
                                error={!salesPackage.salesPackageId}
                            />
                        </Grid>
                        <Grid item xs={8} />
                        <Grid item xs={8}>
                            <InputField
                                value={salesPackage.description}
                                label="Description"
                                fullWidth
                                rows={3}
                                onChange={handleFieldChange}
                                propertyName="description"
                                maxLength={2000}
                                error={!salesPackage.description}
                            />
                        </Grid>
                        <Grid item xs={4} />
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell>Type</TableCell>
                                    <TableCell align="right">Sequence</TableCell>
                                    <TableCell align="right">Quantity</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {item.elements &&
                                    item.elements.map((row, index) => (
                                        <TableRow style={cursor} hover key={row.elementType}>
                                            <TableCell>
                                                <InputField
                                                    disabled
                                                    value={row.elementType}
                                                    label="Type"
                                                    propertyName="type"
                                                    maxLength={10}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={row.sequence}
                                                    label="Sequence"
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},sequence`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={row.quantity}
                                                    label="Quantity"
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},quantity`}
                                                />
                                            </TableCell>
                                        </TableRow>
                                    ))}
                            </TableBody>
                        </Table>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={viewing() || inputInvalid()}
                                saveClick={handleSaveClick}
                                cancelClick={handleCancelClick}
                                backClick={handleBackClick}
                            />
                        </Grid>
                    </Fragment>
                )}
            </Grid>
        </Page>
    );
}

SalesPackage.defaultProps = {
    item: {},
    add: null,
    update: null,
    loading: null,
    errorMessage: '',
    itemId: null,
    snackbarVisible: false
};

SalesPackage.propTypes = {
    item: PropTypes.shape({}),
    editStatus: PropTypes.string.isRequired,
    setEditStatus: PropTypes.func.isRequired,
    errorMessage: PropTypes.string,
    itemId: PropTypes.string,
    update: PropTypes.func,
    history: PropTypes.func.isRequired,
    add: PropTypes.func,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired
};

export default SalesPackage;
