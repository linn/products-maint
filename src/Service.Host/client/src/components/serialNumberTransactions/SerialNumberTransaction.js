﻿import React, { Fragment, useState, useEffect } from 'react';
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
    sernosTransCountTypes,
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

    useEffect(() => {
        if (!creating() && item !== prevSerialNumberTransaction) {
            setSerialNumberTransaction(item);
            setPrevSerialNumberTransaction(item);
        }
    });

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
        { displayText: '', id: ''}
    ];

    const cursor = {
        cursor: 'pointer'
    };

    const transCodeInvalid = () => creating() && !serialNumberTransaction.transCode;
    const descriptionInvalid = () => !serialNumberTransaction.transDescription;
    const sernosCountSelected = () =>
        newElements.length > 0 && newElements.some(element => !element.sernosCount);
    const invalidSernosCountSelection = () => {
        const usedSernosCounts = creating()
            ? newElements
            : newElements.concat(serialNumberTransaction.sernosTransCounts);
        const counts = usedSernosCounts.map(a => a.sernosCount);
        return new Set(counts).size !== counts.length;
    };

    const checkErrorValidation = () => {
        serialNumberTransaction.sernosTransCounts.forEach(element => {
            const elementToCheck = element;
            if (!elementToCheck.checkError) {
                elementToCheck.checkError = 'N';
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
        if (!newElements.includes(emptySernosTransCode) && sernosTransCountTypes) {
            setNewElements([...newElements, emptySernosTransCode]);
        }
    };

    const removeElement = index => {
        const copy = [...newElements];
        copy.splice(index, 1);
        setNewElements(copy);
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
            newElements.forEach(newElement => {
                const elementToCheck = newElement;
                if (!elementToCheck.transCode) {
                    elementToCheck.transCode = serialNumberTransaction.transCode;
                }
            });

            serialNumberTransaction.sernosTransCounts = newElements;
            checkErrorValidation();
            addSerialNumberTransaction(serialNumberTransaction);
        }
    };

    const handleCancelClick = () => {
        setSerialNumberTransaction(item);
        setNewElements([]);
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
        if (viewing()) {
            setEditStatus('edit');
        }

        const splitIndex = propertyName.indexOf(',');
        const index = propertyName.slice(0, splitIndex);
        const prop = propertyName.slice(splitIndex + 1);
        const newElement = newElements[index];
        newElement[prop] = newValue;

        setNewElements([...newElements]);
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
    const sernosCountOptions = [...sernosTransCountTypes.map(value => value.name), ''];

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
                                error={descriptionInvalid()}
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
                                                    value={row.checkErrorMess}
                                                    label="Message"
                                                    maxLength={128}
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},checkErrorMess`}
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
                                                    items={sernosCountOptions}
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
                                                    propertyName={`${index},checkErrorMess`}
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
    sernosTransCountTypes: null,
    loading: null,
    errorMessage: '',
    itemId: null,
    snackbarVisible: false
};

SerialNumberTransaction.propTypes = {
    item: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    sernosTransCountTypes: PropTypes.arrayOf(PropTypes.shape({})),
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
