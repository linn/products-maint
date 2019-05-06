import React, { Fragment, useState, useEffect, useRef } from 'react';
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
    salesArticleSernosDetails,
    snackbarVisible,
    addItem,
    setEditStatus,
    sernosNotes,
    sernosNotesLoading,
    sernosTransactions,
    sernosTransactionsLoading,
    setSnackbarVisible,
    addSernosNote,
    fetchSalesArticleSernosDetails
}) {
    const [serialNumber, setSerialNumber] = useState({});
    const [prevSerialNumber, setPrevSerialNumber] = useState({});
    const [sernosTransactionsList, setSernosTransactionsList] = useState(['']);
    const [selectedSernosTransaction, setSelectedSernosTransaction] = useState('');

    const savedFetchSalesArticleSernosDetails = useRef(null);

    useEffect(() => {
        savedFetchSalesArticleSernosDetails.current = fetchSalesArticleSernosDetails;
    }, [fetchSalesArticleSernosDetails]);

    useEffect(() => {
        if (item === null) {
            setSerialNumber({});
            setPrevSerialNumber(null);
        } else {
            const sernos = item[0];
            setSerialNumber(s => ({
                ...sernos,
                fromSernosNumber: s.fromSernosNumber,
                toSernosNumber: s.toSernosNumber
            }));
            setPrevSerialNumber(sernos);
        }
    }, [item, prevSerialNumber]);

    useEffect(() => {
        const transactions = sernosTransactions.map(s => `${s.transCode}: ${s.transDescription}`);
        setSernosTransactionsList(['', ...transactions]);
    }, [sernosTransactions]);

    useEffect(() => {
        if (serialNumber.articleNumber) {
            savedFetchSalesArticleSernosDetails.current(serialNumber.articleNumber);
        }
    }, [serialNumber.articleNumber]);

    useEffect(() => {
        if (salesArticleSernosDetails) {
            setSerialNumber(s => ({
                ...s,
                sernosGroup: salesArticleSernosDetails.sernosGroup,
                serialNumbered: salesArticleSernosDetails.serialNumbered
            }));
        } else {
            setSerialNumber(s => ({
                ...s,
                sernosGroup: null,
                serialNumbered: null
            }));
        }
    }, [salesArticleSernosDetails]);

    const articles = ['', 'MAJIK-IP', 'MAJIK CD', 'KLIMAX DS', 'KIKO DSM', 'AKURATE CD'];

    const viewing = () => editStatus === 'view';

    const handleFieldChange = (propertyName, newValue) => {
        if (propertyName === 'transCode') {
            const code = newValue.split(':')[0];

            setSerialNumber({ ...serialNumber, [propertyName]: code });
            setSelectedSernosTransaction(newValue);

            return;
        }
        setSerialNumber({ ...serialNumber, [propertyName]: newValue });
    };

    const handleSaveClick = () => {
        setEditStatus('view');
        addItem(serialNumber);
        // for the length of the serial numbers?
        for (
            let sernosNumber = serialNumber.fromSernosNumber;
            sernosNumber <= serialNumber.toSernosNumber;
            sernosNumber += 1
        )
            addSernosNote({
                sernosNotes: serialNumber.sernosNotes,
                sernosGroup: serialNumber.sernosGroup,
                sernosNumber,
                sernosTRef: serialNumber.sernosTRef,
                transCode: serialNumber.transCode
            });
    };

    const handleBackClick = () => history.push('/products/maint/serial-numbers');

    return (
        <Page>
            {/* {console.log(sernosNotes)} */}
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    <Title text="Create Serial Number" />
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading || sernosTransactionsLoading || sernosNotesLoading ? (
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
                                value={selectedSernosTransaction}
                            />
                        </Grid>
                        <Grid item xs={5} />
                        <Grid item xs={5}>
                            <Dropdown
                                disabled={viewing()}
                                fullWidth
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
                            <InputField
                                disabled
                                fullWidth
                                label="Serial Numbered"
                                maxLength={10}
                                onChange={handleFieldChange}
                                propertyName="sernosGroup"
                                value={serialNumber.serialNumbered}
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
                                disabled
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
                                saveDisabled={viewing()}
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
    salesArticleSernosDetails: PropTypes.shape({}).isRequired,
    sernosTransactions: PropTypes.arrayOf(PropTypes.shape({})),
    sernosTransactionsLoading: PropTypes.bool,
    addItem: PropTypes.func.isRequired,
    setEditStatus: PropTypes.func.isRequired,
    setSnackbarVisible: PropTypes.func.isRequired,
    fetchSalesArticleSernosDetails: PropTypes.func.isRequired
};

SerialNumber.defaultProps = {
    item: {},
    errorMessage: '',
    snackbarVisible: false,
    sernosTransactions: [],
    sernosTransactionsLoading: false
};

export default SerialNumber;
