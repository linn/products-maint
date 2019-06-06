import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Grid, Button, Table, TableBody, TableHead, TableRow, TableCell } from '@material-ui/core';
import AddIcon from '@material-ui/icons/Add';
import DeleteIcon from '@material-ui/icons/Delete';

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
    const [newElements, setNewElements] = useState([]);

    const creating = () => editStatus === 'create';
    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';
    useEffect(() => {
        if (!creating() && item !== prevSalesPackage) {
            setSalesPackage(item);
            setPrevSalesPackage(item);
        }
    });

    const emptySalesPackage = {
        type: '',
        sequence: '',
        quantity: ''
    };

    //TODO - INPUT VALIDITY CHECK, type is required
    const showFieldsToAddElement = () => {
        setEditStatus('edit');
        setNewElements([...newElements, emptySalesPackage]);
    };

    const removeNewElement = index => {
        const copy = [...newElements];
        copy.splice(index, 1);
        setNewElements(copy);
    };

    const handleSaveClick = () => {
        if (editing()) {
            const { elements } = salesPackage;
            salesPackage.elements = [...elements, ...newElements];
            //checkErrorValidation();
            update(itemId, salesPackage);
            setNewElements([]);
            setEditStatus('view');
        } else if (creating()) {
            newElements.forEach(newElement => {
                const elementToCheck = newElement;
                if (!elementToCheck.type) {
                    elementToCheck.type = salesPackage.type;
                }
            });

            salesPackage.elements = newElements;
            //checkErrorValidation();
            add(salesPackage);
        }
    };

    const handleCancelClick = () => {
        setSalesPackage(item);
        setNewElements([]);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/maint/sales-packages');
    };

    const handleFieldChange = (propertyName, newValue) => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }

        setSalesPackage({ ...salesPackage, [propertyName]: newValue });
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
        const { elements } = salesPackage;

        elements[index][prop] = newValue;
        setSalesPackage({ ...salesPackage, elements });
    };

    const inputInvalid = () => newElements.some(e => !e.elementType);

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
                {loading || (!salesPackage && !creating()) ? (
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
                            />
                        </Grid>
                        <Grid item xs={4} />

                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell>Type</TableCell>
                                    <TableCell>Sequence</TableCell>
                                    <TableCell>Quantity</TableCell>
                                    <TableCell />
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {salesPackage.elements &&
                                    salesPackage.elements.map((row, index) => (
                                        // eslint-disable-next-line react/no-array-index-key
                                        <TableRow key={index}>
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
                                                    type="number"
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},sequence`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={row.quantity}
                                                    label="Quantity"
                                                    type="number"
                                                    onChange={handleElementChange}
                                                    propertyName={`${index},quantity`}
                                                />
                                            </TableCell>
                                            <TableCell />
                                        </TableRow>
                                    ))}
                                {newElements &&
                                    newElements.map((element, index) => (
                                        // eslint-disable-next-line react/no-array-index-key
                                        <TableRow key={index}>
                                            <TableCell>
                                                <InputField
                                                    value={element.elementType}
                                                    label="Type"
                                                    onChange={handleNewElement}
                                                    propertyName={`${index},elementType`}
                                                    maxLength={10}
                                                    error={!element.elementType}
                                                    helperText={
                                                        element.elementType
                                                            ? ''
                                                            : 'Field Cannot Be Empty'
                                                    }
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={element.sequence}
                                                    label="Sequence"
                                                    type="number"
                                                    onChange={handleNewElement}
                                                    propertyName={`${index},sequence`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <InputField
                                                    value={element.quantity}
                                                    label="Quantity"
                                                    type="number"
                                                    onChange={handleNewElement}
                                                    propertyName={`${index},quantity`}
                                                />
                                            </TableCell>
                                            <TableCell>
                                                <Button onClick={() => removeNewElement(index)}>
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
    snackbarVisible: false,
    setSnackbarVisible: null
};

SalesPackage.propTypes = {
    item: PropTypes.shape({}),
    editStatus: PropTypes.string.isRequired,
    setEditStatus: PropTypes.func.isRequired,
    errorMessage: PropTypes.string,
    itemId: PropTypes.string,
    update: PropTypes.func,
    history: PropTypes.shape({}).isRequired,
    add: PropTypes.func,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func
};

export default SalesPackage;
