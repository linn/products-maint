﻿﻿import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Grid, Button, Table, TableHead, TableBody, TableRow, TableCell } from '@material-ui/core';
import DeleteIcon from '@material-ui/icons/Delete';
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
    fetchCodes,
    sernosTransCodes,
    updateSerialNumberTransaction,
    addSerialNumberTransaction,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible,
    history
}) {
    const [serialNumberTransaction, setSerialNumberTransaction] = useState({});
    const [prevSerialNumberTransaction, setPrevSerialNumberTransaction] = useState({});
    const [newElements, setNewElements] = useState([]);

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    const emptySernosTransCode = {
        transCode: '',
        sernosCount: '',
        checkError: '',
        correctValue: 0,
        countIncrement: 0,
        checkErrorMess: ''
    };

    const errorOptions = [
        { displayText: 'None', id: 'N' },
        { displayText: 'Error', id: 'E' },
        { displayText: 'Warning', id: 'W' },
        ''
    ];

    useEffect(() => {
        if (!sernosTransCodes) {
            fetchCodes();
        }

        if (item !== prevSerialNumberTransaction) {
            setSerialNumberTransaction(item);
            setPrevSerialNumberTransaction(item);
        }
    });

    const cursor = {
        cursor: 'pointer'
    };

    const transCodeInvalid = () => !serialNumberTransaction.transCode;
    const descriptionInvalid = () => !serialNumberTransaction.transDescription;
    const sernosCountSelected = () =>
        !newElements || (newElements && newElements.every(element => !element.sernosCount));
    const invalidSernosCountSelection = () => {
        const usedSernosCounts = newElements
            .concat(serialNumberTransaction.sernosTransCounts)
            .map(y => y.sernosCount);
        return new Set(usedSernosCounts).size !== usedSernosCounts.length;
    };

    const checkErrorValidation = () => {
        serialNumberTransaction.sernosTransCounts.forEach(element => {
            if (!element.checkError) {
                element.checkError = 'N';
            }
        });
    };

    const validate = () =>
        viewing() ||
        transCodeInvalid() ||
        descriptionInvalid() ||
        sernosCountSelected() ||
        invalidSernosCountSelection();

    const showFieldsToAddElement = () => {
        if (!newElements.includes(emptySernosTransCode) && sernosTransCodes) {
            setNewElements([...newElements, emptySernosTransCode]);
        }
    };

    const removeElement = index => {
        const copy = [...newElements];
        setNewElements(copy.splice(index, 1));
    };

    const handleSaveClick = () => {
        if (editing()) {
            const { sernosTransCounts } = serialNumberTransaction;
            serialNumberTransaction.sernosTransCounts = [...sernosTransCounts, ...newElements];
            checkErrorValidation();
            updateSerialNumberTransaction(itemId, serialNumberTransaction);
            setNewElements([]);
            setEditStatus('view');
        } else if (creating()) {
            const { sernosTransCounts } = serialNumberTransaction;
            serialNumberTransaction.sernosTransCounts = [...sernosTransCounts, ...newElements];
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
        const splitIndex = propertyName.indexOf(',');
        const index = propertyName.slice(0, splitIndex);
        const prop = propertyName.slice(splitIndex + 1);
        const newElement = newElements[index];
        newElement[prop] = newValue;
        if (!newElement.transCode) {
            newElement.transCode = item.transCode;
        }
        setNewElements([...newElements, ...newElement]);
    };

    const handleElementChange = (propertyName, newValue) => {
        setEditStatus('edit');
        const splitIndex = propertyName.indexOf(',');
        const index = propertyName.slice(0, splitIndex);
        const prop = propertyName.slice(splitIndex + 1);
        const { sernosTransCounts } = serialNumberTransaction;

        sernosTransCounts[index][prop] = newValue;
        setSerialNumberTransaction({ ...serialNumberTransaction, sernosTransCounts });
    };

    const yesNoOptions = ['Y', 'N', ''];

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
                                error={creating() && transCodeInvalid}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <InputField
                                value={serialNumberTransaction.transDescription}
                                label="Description"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="transDescription"
                                error={descriptionInvalid}
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
                                error={!serialNumberTransaction.manualPost}
                            />
                        </Grid>
                        <Grid container>
                            <Grid item xs={6}>
                                <InputField
                                    value={serialNumberTransaction.comments}
                                    label="Comments"
                                    rows={3}
                                    fullWidth
                                    onChange={handleFieldChange}
                                    propertyName="comments"
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
                                {serialNumberTransaction.sernosTransCounts &&
                                    serialNumberTransaction.sernosTransCounts.map((row, index) => (
                                        // except if sorting
                                        // eslint-disable-next-line react/no-array-index-key
                                        <TableRow style={cursor} key={index}>
                                            <TableCell>
                                                <InputField
                                                    disabled
                                                    value={row.sernosCount}
                                                    label="Count"
                                                    propertyName="count"
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={row.countIncrement}
                                                    label="Count Increment"
                                                    type="number"
                                                    error={typeof row.countIncrement !== 'number'}
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},countIncrement`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={row.correctValue}
                                                    label="Correct Value"
                                                    error={typeof row.correctValue !== 'number'}
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},correctValue`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <Dropdown
                                                    value={row.checkError}
                                                    label="Check Error"
                                                    items={errorOptions}
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},checkError`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    type="text"
                                                    value={row.message}
                                                    label="Message"
                                                    maxLength={128}
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},message`}
                                                />
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                {newElements &&
                                    newElements.map((element, index) => (
                                        // except if sorting
                                        // eslint-disable-next-line react/no-array-index-key
                                        <TableRow style={cursor} key={index}>
                                            <TableCell>
                                                <Dropdown
                                                    value={element.sernosCount}
                                                    items={sernosTransCodes.map(
                                                        value => value.name
                                                    )}
                                                    label="Count"
                                                    propertyName={`${index},sernosCount`}
                                                    onChange={handleNewElement}
                                                    error={!element.sernosCount}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={element.countIncrement}
                                                    label="Count Increment"
                                                    type="number"
                                                    error={
                                                        typeof element.countIncrement !== 'number'
                                                    }
                                                    onChange={handleNewElement}
                                                    propertyName={`${index},countIncrement`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={element.correctValue}
                                                    label="Correct Value"
                                                    type="number"
                                                    error={typeof element.correctValue !== 'number'}
                                                    onChange={handleNewElement}
                                                    propertyName={`${index},correctValue`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <Dropdown
                                                    value={element.checkError}
                                                    label="Check Error"
                                                    items={errorOptions}
                                                    onChange={handleNewElement}
                                                    propertyName={`${index},checkError`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    type="text"
                                                    value={element.checkErrorMess}
                                                    label="Message"
                                                    onChange={handleNewElement}
                                                    maxLength={128}
                                                    propertyName={`${index},message`}
                                                />
                                            </TableCell>

                                            <TableCell>
                                                <Button onClick={() => removeElement(index)}>
                                                    <DeleteIcon />
                                                </Button>
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                <TableRow key="addButton">
                                    <TableCell>
                                        <Button onClick={showFieldsToAddElement}>
                                            <AddIcon />
                                        </Button>
                                    </TableCell>
                                </TableRow>
                            </TableBody>
                        </Table>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={validate()}
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
    fetchCodes: PropTypes.func.isRequired,
    sernosTransCodes: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
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
