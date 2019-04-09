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
    SnackbarMessage
} from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

function SaHoldStory({
    loading,
    errorMessage,
    editStatus,
    item,
    itemId,
    addSaHoldStory,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible,
    history,
    match,
    updateSaHoldStory
}) {
    const deslugify = articleNumber => articleNumber.replace(/%2F/g, '/');
    const slugify = articleNumber => articleNumber.replace(/[/]/g, '%2F');

    const creating = () => editStatus === 'create';
    const viewing = () => editStatus === 'view';
    const editing = () => editStatus === 'edit';

    const initialState = () => {
        if (creating()) {
            return {
                salesArticle: deslugify(match.params.articleNumber),
                dateStarted: moment().toISOString()
            };
        }
        return {};
    };

    const [saHoldStory, setSaHoldStory] = useState(initialState);
    const [prevSaHoldStory, setPrevSaHoldStory] = useState({});

    useEffect(() => {
        if (!creating() && item !== prevSaHoldStory) {
            setSaHoldStory(editing() ? { ...item, dateFinished: moment().toISOString() } : item);
            setPrevSaHoldStory(item);
        }
    });

    const createInputInvalid = () => !saHoldStory.reasonStarted;
    const editInputInvalid = () => !saHoldStory.reasonFinished;

    const handleSaveClick = () => {
        if (creating()) {
            addSaHoldStory(saHoldStory);
        } else if (editing()) {
            updateSaHoldStory(itemId, saHoldStory);
            history.push(`/products/reports/sa-hold-stories/${itemId}`);
        }
    };

    const handleCancelClick = () => {
        history.push('/products/maint/put-product-on-hold');
    };

    const handleBackClick = () => {
        history.push(`/products/maint/sales-articles/${slugify(saHoldStory.salesArticle)}`);
    };

    const handleFieldChange = (propertyName, newValue) => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }
        setSaHoldStory({ ...saHoldStory, [propertyName]: newValue });
    };

    const titleText = () => {
        if (creating()) {
            return `Put ${saHoldStory.salesArticle} on Hold?`;
        }
        if (editing()) {
            return `Take ${saHoldStory.salesArticle} off Hold?`;
        }
        return `${saHoldStory.salesArticle} Hold Story Details`;
    };

    return (
        <Page>
            <Grid container spacing={24}>
                {loading || (!saHoldStory && !creating()) ? (
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
                        <Grid item xs={12}>
                            <Title text={titleText(match.params.articleNumber)} />
                        </Grid>
                        <SnackbarMessage
                            visible={snackbarVisible}
                            onClose={() => setSnackbarVisible(false)}
                            message="Save Successful"
                        />
                        {viewing() ? (
                            <Grid item xs={6}>
                                <InputField
                                    fullWidth
                                    disabled={!creating()}
                                    type="date"
                                    value={saHoldStory.dateStarted}
                                    label="Date Started"
                                    propertyName="dateStarted"
                                    onChange={handleFieldChange}
                                />
                            </Grid>
                        ) : (
                            <Fragment />
                        )}
                        {viewing() ? (
                            <Grid item xs={6}>
                                <InputField
                                    fullWidth
                                    disabled
                                    type="date"
                                    value={saHoldStory.dateFinished}
                                    label="Date Finished"
                                    propertyName="dateFinished"
                                />
                            </Grid>
                        ) : (
                            <Fragment />
                        )}
                        {viewing() || creating() ? (
                            <Grid item xs={6}>
                                <InputField
                                    value={saHoldStory.reasonStarted}
                                    disabled={!creating()}
                                    onChange={handleFieldChange}
                                    propertyName="reasonStarted"
                                    rows={4}
                                    label="Reason Put on Hold"
                                    fullWidth
                                    error={!saHoldStory.reasonStarted}
                                    helperText={
                                        !saHoldStory.reasonStarted
                                            ? 'You must provide a reason'
                                            : ''
                                    }
                                />
                            </Grid>
                        ) : (
                            <Fragment />
                        )}
                        {creating() ? (
                            <Grid item xs={6}>
                                <InputField
                                    fullWidth
                                    disabled={!creating()}
                                    type="date"
                                    value={saHoldStory.anticipatedEndDate}
                                    label="Anticipated End Date"
                                    propertyName="anticipatedEndDate"
                                    onChange={handleFieldChange}
                                />{' '}
                            </Grid>
                        ) : (
                            <Fragment />
                        )}
                        {viewing() || editing() ? (
                            <Grid item xs={6}>
                                <InputField
                                    value={saHoldStory.reasonFinished}
                                    disabled={!editing()}
                                    label="Reason Taken Off Hold"
                                    onChange={handleFieldChange}
                                    rows={4}
                                    fullWidth
                                    propertyName="reasonFinished"
                                />
                            </Grid>
                        ) : (
                            <Fragment />
                        )}
                        {viewing() ? (
                            <Fragment>
                                <Grid item xs={6}>
                                    <InputField
                                        value={saHoldStory.putOnHoldByEmployee}
                                        disabled
                                        label="Put on Hold By Employee"
                                        fullWidth
                                        propertyName="putOnHoldByEmployeeNumber"
                                    />
                                </Grid>
                                <Grid item xs={6}>
                                    <InputField
                                        value={saHoldStory.takenOffHoldByEmployee}
                                        disabled
                                        label="Taken Off Hold By Employee"
                                        fullWidth
                                        propertyName="takenOffHoldByEmployeeNumber"
                                    />
                                </Grid>
                            </Fragment>
                        ) : (
                            <Fragment />
                        )}
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={
                                    viewing() ||
                                    (creating() && createInputInvalid()) ||
                                    (editing() && editInputInvalid())
                                }
                                saveClick={handleSaveClick}
                                cancelClick={handleCancelClick}
                                backClick={handleBackClick}
                            />
                        </Grid>{' '}
                    </Fragment>
                )}
            </Grid>
        </Page>
    );
}

SaHoldStory.propTypes = {
    item: PropTypes.shape({
        item: PropTypes.shape({}),
        dateStarted: PropTypes.string,
        dateEnded: PropTypes.string,
        reasonStarted: PropTypes.string,
        reasonEnded: PropTypes.string,
        putOnHoldByEmployeeNumber: PropTypes.number,
        TakenOffByEmployeeNumber: PropTypes.number
    }),
    loading: PropTypes.bool,
    errorMessage: PropTypes.string,
    match: PropTypes.shape({}),
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    editStatus: PropTypes.string.isRequired,
    addSaHoldStory: PropTypes.func,
    updateSaHoldStory: PropTypes.func,
    setEditStatus: PropTypes.func.isRequired,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired,
    itemId: PropTypes.string
};

SaHoldStory.defaultProps = {
    loading: false,
    errorMessage: '',
    item: {},
    addSaHoldStory: null,
    snackbarVisible: false,
    updateSaHoldStory: null,
    match: {},
    itemId: null
};

export default SaHoldStory;
