import React, { Fragment, useState, useEffect, useRef } from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Grid, Button } from '@material-ui/core';
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
import { getSernosNote } from '../selectors/sernosNotesSelectors';
import SalesArticleTypeaheadDialog from '../containers/common/SalesArticleTypeaheadDialog';

function SerialNumber({
    errorMessage,
    editStatus,
    history,
    loading,
    items,
    salesArticleSernosDetails,
    snackbarVisible,
    addItem,
    setEditStatus,
    sernosNotes,
    sernosTransactions,
    sernosTransactionsLoading,
    setSnackbarVisible,
    fetchSalesArticleSernosDetails,
    clearSerialNumber,
    clearSalesArticleSernosDetails
}) {
    const [serialNumber, setSerialNumber] = useState({});
    const [prevSerialNumber, setPrevSerialNumber] = useState({});
    const [sernosTransactionsList, setSernosTransactionsList] = useState(['']);
    const handleArticleNumberChange = newValue => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }
        setSerialNumber({
            ...serialNumber,
            articleNumber: newValue.articleNumber
        });
    };
    const savedFetchSalesArticleSernosDetails = useRef(null);

    useEffect(() => {
        savedFetchSalesArticleSernosDetails.current = fetchSalesArticleSernosDetails;
    }, [fetchSalesArticleSernosDetails]);

    useEffect(() => {
        if (items === null) {
            setSerialNumber({});
            setPrevSerialNumber(null);
        } else {
            const sernos = items[0];

            setSerialNumber(s => ({
                ...sernos,
                fromSernosNumber: s.fromSernosNumber,
                toSernosNumber: s.toSernosNumber
            }));

            setPrevSerialNumber(sernos);
        }
    }, [items, prevSerialNumber]);

    useEffect(() => {
        const transactions = sernosTransactions
            .filter(s => s.manualPost === 'Y')
            .map(s => s.transCode);
        setSernosTransactionsList(['', ...transactions]);
    }, [sernosTransactions]);

    useEffect(() => {
        if (serialNumber.articleNumber) {
            savedFetchSalesArticleSernosDetails.current(serialNumber.articleNumber);
        }
    }, [serialNumber.articleNumber, editStatus]);

    useEffect(() => {
        if (salesArticleSernosDetails) {
            if (serialNumber.articleNumber) {
                setSerialNumber(s => ({
                    ...s,
                    sernosGroup: salesArticleSernosDetails.sernosGroup,
                    serialNumbered: salesArticleSernosDetails.serialNumbered
                }));
            }
        } else {
            setSerialNumber(s => ({
                ...s,
                sernosGroup: null,
                serialNumbered: null
            }));
        }
    }, [salesArticleSernosDetails, serialNumber.articleNumber]);

    const viewing = () => editStatus === 'view';

    const handleFieldChange = (propertyName, newValue) => {
        if (propertyName === 'articleNumber') {
            setSerialNumber({ ...serialNumber, [propertyName]: newValue.articleNumber });
            return;
        }

        if (
            propertyName === 'fromSernosNumber' &&
            (serialNumber.serialNumbered === 'Serial numbered in pairs, one box' ||
                serialNumber.serialNumbered === 'Serial numbered in pairs, two boxes')
        ) {
            setSerialNumber({
                ...serialNumber,
                fromSernosNumber: newValue,
                toSernosNumber: newValue + 1
            });
            return;
        }

        setSerialNumber({ ...serialNumber, [propertyName]: newValue });
    };

    const handleSaveClick = () => {
        setEditStatus('view');

        if (!serialNumber.toSernosNumber) {
            addItem({
                ...serialNumber,
                toSernosNumber: serialNumber.fromSernosNumber
            });
            return;
        }

        addItem(serialNumber);
    };

    const fromSernosNumberInvalid = () => !serialNumber.fromSernosNumber;

    const handleBackClick = () => history.push('/products/maint/serial-numbers');

    const getSernosNoteText = () => {
        const note = getSernosNote(sernosNotes, serialNumber);
        return note ? note.sernosNotes : '';
    };

    const handleCreateClick = () => {
        clearSalesArticleSernosDetails();
        clearSerialNumber();
        setEditStatus('edit');
    };

    return (
        <Page>
            <Grid container spacing={3}>
                <Grid item xs={12}>
                    <Title text="Create Serial Number" />
                    {viewing() && (
                        <Fragment>
                            <Grid item xs={12}>
                                <Button
                                    color="primary"
                                    variant="outlined"
                                    style={{ float: 'right' }}
                                    onClick={handleCreateClick}
                                >
                                    Create Another
                                </Button>
                            </Grid>
                        </Fragment>
                    )}
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
                            <InputField
                                disabled
                                label="Article Number"
                                type="string"
                                propertyName="articleNumber"
                                value={serialNumber.articleNumber}
                                onChange={handleFieldChange}
                            />
                            <SalesArticleTypeaheadDialog
                                onSelect={handleArticleNumberChange}
                                title="Search for sales article"
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
                                value={serialNumber.serialNumbered}
                            />
                        </Grid>
                        <Grid item xs={5}>
                            <InputField
                                error={fromSernosNumberInvalid()}
                                errorText="Required field"
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
                                value={
                                    viewing()
                                        ? getSernosNoteText(sernosNotes, serialNumber)
                                        : serialNumber.sernosNotes
                                }
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={viewing() || fromSernosNumberInvalid()}
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
    items: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    loading: PropTypes.bool.isRequired,
    snackbarVisible: PropTypes.bool,
    salesArticleSernosDetails: PropTypes.shape({}),
    sernosNotes: PropTypes.arrayOf(PropTypes.shape({})),
    sernosTransactions: PropTypes.arrayOf(PropTypes.shape({})),
    sernosTransactionsLoading: PropTypes.bool,
    addItem: PropTypes.func.isRequired,
    setEditStatus: PropTypes.func.isRequired,
    setSnackbarVisible: PropTypes.func.isRequired,
    fetchSalesArticleSernosDetails: PropTypes.func.isRequired,
    clearSerialNumber: PropTypes.func.isRequired,
    clearSalesArticleSernosDetails: PropTypes.func.isRequired
};

SerialNumber.defaultProps = {
    items: {},
    errorMessage: '',
    snackbarVisible: false,
    salesArticleSernosDetails: null,
    sernosNotes: [],
    sernosTransactions: [],
    sernosTransactionsLoading: false
};

export default SerialNumber;
