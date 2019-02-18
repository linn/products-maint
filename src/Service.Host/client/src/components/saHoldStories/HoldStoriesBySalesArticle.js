import React, { Fragment } from 'react';
import { Grid } from '@material-ui/core';
import {
    ReportTable,
    Loading,
    Title,
    BackButton,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

function Report({ reportData, loading }) {
    if (loading) {
        return <Loading />;
    }
    return (
        <Fragment>
            {reportData && reportData.results.length > 0 ? (
                <ReportTable
                    reportData={reportData}
                    showTotals={false}
                    showRowTitles
                    title={reportData ? reportData.title.displayString : null}
                    showTitle={false}
                />
            ) : (
                <ErrorCard errorMessage="No Hold History Found" />
            )}
        </Fragment>
    );
}

function HoldStoriesBySalesArticle({ reportData, loading, history, match }) {
    const titleify = articleNumber => articleNumber.replace('%2F', '/');
    const handleBackClick = () => {
        history.push('/products/sa-hold-stories');
    };

    return (
        <Page>
            <Grid container spacing={24} justify="center">
                <Grid item xs={12}>
                    <Grid item xs={10}>
                        <Title
                            text={`Hold Stories for sales article 
                            ${titleify(match.params.articleNumber)}`}
                        />
                    </Grid>
                    <Grid item xs={2}>
                        <BackButton backClick={handleBackClick} />
                    </Grid>
                </Grid>
                <Grid item xs={12}>
                    <Report reportData={reportData} loading={loading} />
                </Grid>
            </Grid>
        </Page>
    );
}

HoldStoriesBySalesArticle.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    reportData: PropTypes.shape({}),
    options: PropTypes.shape({}),
    match: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool
};

Report.propTypes = {
    reportData: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool
};

Report.defaultProps = {
    loading: false
};

HoldStoriesBySalesArticle.defaultProps = {
    reportData: null,
    options: {},
    loading: false
};

export default HoldStoriesBySalesArticle;
