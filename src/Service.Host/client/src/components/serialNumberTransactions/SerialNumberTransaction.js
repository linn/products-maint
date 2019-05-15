﻿import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Grid, Button, Table, TableHead, TableBody, TableRow, TableCell } from '@material-ui/core';
import AddIcon from '@material-ui/icons/Add';
import {
    SaveBackCancelButtons,
    InputField,
    Dropdown,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage
} from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

function SerialNumberTransaction({
    loading,
    errorMessage,
    editStatus,
    item,
    itemId,
    updateSerialNumberTransaction,
    addSerialNumberTransaction,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible,
    history
}) {
    const [serialNumberTransaction, setSerialNumberTransaction] = useState({});
    const [prevSerialNumberTransaction, setPrevSerialNumberTransaction] = useState({});

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    useEffect(() => {
        if (item !== prevSerialNumberTransaction) {
            setSerialNumberTransaction(item);
            setPrevSerialNumberTransaction(item);
        }
    });

    const transCodeInvalid = () => !serialNumberTransaction.transCode;
    const descriptionInvalid = () => !serialNumberTransaction.transDescription;

    const handleSaveClick = () => {
        if (editing()) {
            updateSerialNumberTransaction(itemId, serialNumberTransaction);
            setEditStatus('view');
        } else if (creating()) {
            addSerialNumberTransaction(serialNumberTransaction);
        }
    };

    const handleCancelClick = () => {
        setSerialNumberTransaction(item);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/maint/serial-number-transactions');
    };

    const handleFieldChange = (propertyName, newValue) => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }

        setSerialNumberTransaction({ ...serialNumberTransaction, [propertyName]: newValue });
    };

    const handleNewElement = (propertyName, newValue) => {
        setEditStatus('edit');
        // ({ ...newElement, [propertyName]: newValue });
    };

    const handleElementChange = (propertyName, newValue) => {
        setEditStatus('edit');
        const splitIndex = propertyName.indexOf(',');
        const index = propertyName.slice(0, splitIndex);
        const prop = propertyName.slice(splitIndex + 1);
        const { elements } = salesPackage;
        elements[index][prop] = newValue;
        // setSalesPackage({ ...salesPackage, elements });
    };

    const yesNoOptions = ['Y', 'N'];

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Add Serial Number Transaction" />
                    ) : (
                        <Title text="Serial Number Transaction Details" />
                    )}
                </Grid>
                {loading || (!serialNumberTransaction && !creating()) ? (
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
                        <Grid item xs={6}>
                            <InputField
                                fullWidth
                                disabled={!creating()}
                                value={serialNumberTransaction.transCode}
                                label="Trans Code"
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : 'This field is required'
                                }
                                onChange={handleFieldChange}
                                propertyName="transCode"
                                error={transCodeInvalid()}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <InputField
                                value={serialNumberTransaction.transDescription}
                                label="Description"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="transDescription"
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <Dropdown
                                value={serialNumberTransaction.manualPost}
                                label="Allow manual post"
                                fullWidth
                                items={yesNoOptions}
                                onChange={handleFieldChange}
                                propertyName="manualPost"
                            />
                        </Grid>
                        <Grid container>
                            <Grid item xs={6}>
                                <InputField
                                    value={serialNumberTransaction.comment}
                                    label="Comment"
                                    rows={3}
                                    fullWidth
                                    onChange={handleFieldChange}
                                    propertyName="comment"
                                />
                            </Grid>
                        </Grid>

                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell>Count</TableCell>
                                    <TableCell>Count Increment</TableCell>
                                    <TableCell>Correct Value</TableCell>
                                    <TableCell>Check Error</TableCell>
                                    <TableCell>Message</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {serialNumberTransaction.elements &&
                                    serialNumberTransaction.elements.map((row, index) => (
                                        <TableRow style={cursor} key={row.count}>
                                            <TableCell>
                                                <Dropdown
                                                    disabled
                                                    value={row.count}
                                                    label="Count"
                                                    propertyName="count"
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={row.countIncrement}
                                                    label="Count Increment"
                                                    type="number"
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},countIncrement`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={row.correctValue}
                                                    label="Correct Value"
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},correctValue`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <Dropdown
                                                    value={row.checkError}
                                                    label="Check Error"
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},checkError`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    type="text"
                                                    value={row.message}
                                                    label="Message"
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},message`}
                                                />
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                <TableRow>
                                    <TableCell>
                                        <Button onClick={showFieldsToAddElement}>
                                            <AddIcon />
                                        </Button>
                                    </TableCell>
                                </TableRow>
                                {newElements &&
                                    newElements.map((element, index) => (
                                        <TableRow style={cursor}>
                                            <TableCell>
                                                <Dropdown
                                                    disabled
                                                    value={element.count}
                                                    label="Count"
                                                    propertyName="count"
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={element.countIncrement}
                                                    label="Count Increment"
                                                    type="number"
                                                    onChange={handleNewElement}
                                                    propertyName={`${index},countIncrement`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={element.correctValue}
                                                    label="Correct Value"
                                                    onChange={handleNewElement}
                                                    propertyName={`${index},correctValue`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <Dropdown
                                                    value={element.checkError}
                                                    label="Check Error"
                                                    onChange={handleNewElement}
                                                    propertyName={`${index},checkError`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    type="text"
                                                    value={element.message}
                                                    label="Message"
                                                    onChange={handleNewElement}
                                                    propertyName={`${index},message`}
                                                />
                                            </TableCell>
                                        </TableRow>
                                    ))}
                            </TableBody>
                        </Table>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={
                                    viewing() || transCodeInvalid() || descriptionInvalid()
                                }
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

SerialNumberTransaction.defaultProps = {
    item: {},
    addSerialNumberTransaction: null,
    updateSerialNumberTransaction: null,
    loading: null,
    errorMessage: '',
    itemId: null,
    snackbarVisible: false
};

SerialNumberTransaction.propTypes = {
    item: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    itemId: PropTypes.string,
    updateSerialNumberTransaction: PropTypes.func,
    addSerialNumberTransaction: PropTypes.func,
    setEditStatus: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired
};

export default SerialNumberTransaction;
