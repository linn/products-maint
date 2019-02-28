import React, { Fragment } from 'react';
import { withStyles } from '@material-ui/core/styles';
import { Grid, Paper } from '@material-ui/core';
import {
    InputField,
    Title,
    ErrorCard,
    Loading,
    BackButton
} from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';

const styles = () => ({
    root: {
        margin: '40px',
        padding: '40px'
    }
});

function SaHoldStory({ saHoldStory, loading, errorMessage, classes, history }) {
    const slugify = articleNumber => articleNumber.replace(/\//g, '%2F');
    const handleBackClick = () => {
        history.push(
            `/products/reports/sa-hold-stories-for-sales-article/${slugify(
                saHoldStory.articleNumber
            )}`
        ); //TODO
    };
    return (
        <Paper className={classes.root}>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    <Title text="Hold Story Details" />
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading || !saHoldStory ? (
                    <Grid item xs={12}>
                        <Loading />
                    </Grid>
                ) : (
                    <Fragment>
                        <Grid item xs={2}>
                            <InputField
                                label="Hold Story Id"
                                disabled
                                fullWidth
                                propertyName="holdStoryId"
                                value={saHoldStory.holdStoryId}
                            />
                        </Grid>
                        <Grid item xs={8} />
                        <Grid item xs={6}>
                            <InputField
                                fullWidth
                                disabled
                                type="date"
                                value={saHoldStory.dateStarted}
                                label="Date Started"
                                propertyName="dateStarted"
                            />
                        </Grid>
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
                        <Grid item xs={6}>
                            <InputField
                                value={saHoldStory.reasonStarted}
                                disabled
                                rows={4}
                                label="Reason Put on Hold"
                                fullWidth
                                propertyName="reasonStarted"
                            />
                        </Grid>
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
                                value={saHoldStory.putOnHoldByEmployeeNumber}
                                disabled
                                label="Put on Hold By Employee"
                                fullWidth
                                propertyName="putOnHoldByEmployeeNumber"
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <InputField
                                value={saHoldStory.takenOffHoldByEmployeeNumber}
                                disabled
                                label="Taken Off Hold By Employee"
                                fullWidth
                                propertyName="takenOffHoldByEmployeeNumber"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <BackButton backClick={handleBackClick} />
                        </Grid>
                    </Fragment>
                )}
            </Grid>
        </Paper>
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

export default withStyles(styles)(SaHoldStory);