import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Grid } from '@material-ui/core';
import {
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage,
    Dropdown
} from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

function SerialNumber({
    errorMessage,
    editStatus,
    history,
    loading,
    item,
    snackbarVisible,
    typeOfSerialNumber,
    addItem,
    setEditStatus,
    sernosTransactions,
    sernosTransactionsLoading,
    setSnackbarVisible
}) {
    const [serialNumber, setSerialNumber] = useState({});
    const [prevSerialNumber, setPrevSerialNumber] = useState({});
    const [sernosTransactionsList, setSernosTransactionsList] = useState(['']);

    useEffect(() => {
        if (item !== prevSerialNumber) {
            setPrevSerialNumber(item);
            if (item !== null) {
                setSerialNumber(item);
            } else {
                setSerialNumber({});
            }
        }
    }, [item, prevSerialNumber]);

    useEffect(() => {
        const transactions = sernosTransactions.map(s => `${s.transCode}: ${s.transDescription}`);
        setSernosTransactionsList(['', ...transactions]);
    }, [sernosTransactions]);

    const viewing = () => editStatus === 'view';

    const articles = ['', 'please', 'fetch', 'me'];

    const serialNumbered = [
        '',
        'Not serial numbered',
        'Serial numbered in ones',
        'Serial numbered in pairs, one box',
        'Serial numbered in pairs, two boxes'
    ];

    const handleFieldChange = (propertyName, newValue) => {
        setSerialNumber({ ...serialNumber, [propertyName]: newValue });
    };

    const salesArticleInvalid = () => {
        if (!typeOfSerialNumber || typeOfSerialNumber === 'N') {
            return true;
        }

        return false;
    };
    // !typeOfSerialNumber || typeOfSerialNumber === 'N' ? true : false;

    const inputInvalid = () => salesArticleInvalid();

    const handleSaveClick = () => {
        addItem(serialNumber);
        setEditStatus('view');
    };

    const handleBackClick = () => history.push('/products/maint/serial-numbers');

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    <Title text="Create Serial Number" />
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading || sernosTransactionsLoading ? (
                    <Grid item xs={12}>
                        <Loading />
                    </Grid>
                ) : (
                    <Fragment>
                        <SnackbarMessage
                            message="Save Successful"
                            onClose={() => setSnackbarVisible(false)}
                            visible={snackbarVisible}
                        />
                        <Grid item xs={5}>
                            <Dropdown
                                disabled={viewing()}
                                fullWidth
                                items={sernosTransactionsList}
                                label="Transaction"
                                onChange={handleFieldChange}
                                propertyName="transCode"
                                value={serialNumber.transCode}
                            />
                        </Grid>
                        <Grid item xs={5} />
                        <Grid item xs={5}>
                            <Dropdown
                                disabled={viewing()}
                                error={salesArticleInvalid()}
                                fullWidth
                                helperText={
                                    salesArticleInvalid() && 'Sales Article must be serial numbered'
                                }
                                items={articles}
                                label="Article Number"
                                onChange={handleFieldChange}
                                propertyName="articleNumber"
                                value={serialNumber.articleNumber}
                            />
                        </Grid>
                        <Grid item xs={5} />
                        <Grid item xs={5}>
                            <InputField
                                disabled
                                fullWidth
                                label="Sernos Group"
                                maxLength={10}
                                onChange={handleFieldChange}
                                propertyName="sernosGroup"
                                value={serialNumber.sernosGroup}
                            />
                        </Grid>
                        <Grid item xs={5}>
                            <Dropdown
                                disabled={viewing()}
                                fullWidth
                                label="Serial Numbered"
                                items={serialNumbered}
                                onChange={handleFieldChange}
                                propertyName="serialNumbered"
                                value={serialNumber.serialNumbered || ''}
                            />
                        </Grid>
                        <Grid item xs={5}>
                            <InputField
                                disabled={viewing()}
                                fullWidth
                                label="From Serial Number"
                                maxLength={8}
                                onChange={handleFieldChange}
                                propertyName="fromSernosNumber"
                                type="number"
                                value={serialNumber.fromSernosNumber}
                            />
                        </Grid>
                        <Grid item xs={5}>
                            <InputField
                                disabled={viewing()}
                                fullWidth
                                label="To Serial Number"
                                maxLength={8}
                                onChange={handleFieldChange}
                                propertyName="toSernosNumber"
                                type="number"
                                value={serialNumber.toSernosNumber}
                            />
                        </Grid>
                        <Grid item xs={5}>
                            <InputField
                                disabled={viewing()}
                                fullWidth
                                label="Previous Serial Number"
                                maxLength={8}
                                onChange={handleFieldChange}
                                propertyName="prevSernosNumber"
                                type="number"
                                value={serialNumber.prevSernosNumber}
                            />
                        </Grid>
                        <Grid item xs={5} />
                        <Grid item xs={5}>
                            <InputField
                                disabled={viewing()}
                                fullWidth
                                label="Document Number"
                                maxLength={8}
                                onChange={handleFieldChange}
                                propertyName="documentNumber"
                                type="number"
                                value={serialNumber.documentNumber}
                            />
                        </Grid>
                        <Grid item xs={5}>
                            <InputField
                                disabled={viewing()}
                                fullWidth
                                label="Document Type"
                                maxLength={2}
                                onChange={handleFieldChange}
                                propertyName="documentType"
                                value={serialNumber.documentType}
                            />
                        </Grid>
                        <Grid item xs={5}>
                            <InputField
                                disabled={viewing()}
                                fullWidth
                                label="Sernos TRef"
                                maxLength={8}
                                onChange={handleFieldChange}
                                propertyName="sernosTRef"
                                type="number"
                                value={serialNumber.sernosTRef}
                            />
                        </Grid>
                        <Grid item xs={5}>
                            <InputField
                                disabled
                                fullWidth
                                label="Sernos Date"
                                onChange={handleFieldChange}
                                propertyName="sernosDate"
                                type="date"
                                value={
                                    serialNumber.sernosDate
                                        ? moment(serialNumber.sernosDate).format('DD MMM YYYY')
                                        : ''
                                }
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                disabled={viewing()}
                                fullWidth
                                label="Notes"
                                maxLength={2000}
                                onChange={handleFieldChange}
                                propertyName="sernosNotes"
                                rows={3}
                                value={serialNumber.sernosNotes}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={viewing() || inputInvalid()}
                                saveClick={handleSaveClick}
                                cancelClick={handleBackClick}
                                backClick={handleBackClick}
                            />
                        </Grid>
                    </Fragment>
                )}
            </Grid>
        </Page>
    );
}

SerialNumber.propTypes = {
    item: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    loading: PropTypes.bool.isRequired,
    snackbarVisible: PropTypes.bool,
    typeOfSerialNumber: PropTypes.string,
    sernosTransactions: PropTypes.arrayOf(PropTypes.shape({})),
    sernosTransactionsLoading: PropTypes.bool,
    addItem: PropTypes.func.isRequired,
    setEditStatus: PropTypes.func.isRequired,
    setSnackbarVisible: PropTypes.func.isRequired
};

SerialNumber.defaultProps = {
    item: {},
    errorMessage: '',
    snackbarVisible: false,
    typeOfSerialNumber: '',
    sernosTransactions: [],
    sernosTransactionsLoading: false
};

export default SerialNumber;
