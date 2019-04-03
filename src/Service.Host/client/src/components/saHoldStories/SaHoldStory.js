import React, { Fragment, useState, useEffect } from 'react';
import PropTypes from 'prop-types';
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
    updateSaHoldStory,
    addSaHoldStory,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible,
    history,
    match
}) {
    const titleify = articleNumber => articleNumber.replace(/%2F/g, '/');

    const creating = () => editStatus === 'create';
    const viewing = () => editStatus === 'view';

    const [saHoldStory, setSaHoldStory] = useState(
        !creating() ? {} : { salesArticle: titleify(match.params.articleNumber) }
    );
    const [prevSaHoldStory, setPrevSaHoldStory] = useState({});

    useEffect(() => {
        if (!creating() && item !== prevSaHoldStory) {
            setSaHoldStory(item);
            setPrevSaHoldStory(item);
        }
    });

    const inputInvalid = () => !saHoldStory.reasonStarted;

    const handleSaveClick = () => {
        addSaHoldStory(saHoldStory);
    };

    const handleCancelClick = () => {
        history.push('/products/reports/put-product-on-hold');
    };

    const handleBackClick = () => {
        history.push('/products/reports/put-product-on-hold');
    };

    const handleFieldChange = (propertyName, newValue) => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }
        setSaHoldStory({ ...saHoldStory, [propertyName]: newValue });
    };

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text={`Put ${titleify(match.params.articleNumber)} on Hold?`} />
                    ) : (
                        <Title text="Hold Story Details" />
                    )}
                </Grid>
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
                        <SnackbarMessage
                            visible={snackbarVisible}
                            onClose={() => setSnackbarVisible(false)}
                            message="Save Successful"
                        />
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
                        <Grid item xs={6}>
                            <InputField
                                value={saHoldStory.reasonStarted}
                                disabled={!creating()}
                                onChange={handleFieldChange}
                                propertyName="reasonStarted"
                                rows={4}
                                label="Reason Put on Hold"
                                fullWidth
                            />
                        </Grid>
                        {viewing() ? (
                            <Fragment>
                                <Grid item xs={6}>
                                    <InputField
                                        value={saHoldStory.reasonFinished}
                                        disabled
                                        label="Reason Taken Off Hold"
                                        rows={4}
                                        fullWidth
                                        propertyName="reasonFinished"
                                    />
                                </Grid>
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
                                saveDisabled={viewing() || inputInvalid()}
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
    saHoldStory: PropTypes.shape({
        holdStoryId: PropTypes.number,
        dateStarted: PropTypes.string,
        dateEnded: PropTypes.string,
        reasonStarted: PropTypes.string,
        reasonEnded: PropTypes.string,
        putOnHoldByEmployeeNumber: PropTypes.number,
        TakenOffByEmployeeNumber: PropTypes.number
    }),
    classes: PropTypes.shape({}),
    loading: PropTypes.bool,
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    errorMessage: PropTypes.string
};

SaHoldStory.defaultProps = {
    loading: false,
    classes: {},
    errorMessage: '',
    saHoldStory: null
};

export default SaHoldStory;
