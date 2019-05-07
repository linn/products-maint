import React, { Fragment, useState, useEffect } from 'react';
import moment from 'moment';
import { Grid, Typography, Button, Tabs, Tab, Tooltip } from '@material-ui/core';
import { Link } from 'react-router-dom';
import {
    InputField,
    Title,
    ErrorCard,
    Loading,
    SaveBackCancelButtons,
    SnackbarMessage,
    Dropdown
} from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import { getSelfHref, getHref } from '../../helpers/utilities';
import Page from '../../containers/Page';
import HoldStoriesBySalesArticle from '../../containers/saHoldStories/HoldStoriesBySalesArticle';
import SalesArticleCompositeDiscount from '../../containers/salesArticles/SalesArticleCompositeDiscount';

function SalesArticle({
    loading,
    errorMessage,
    editStatus,
    item,
    itemId,
    updateSalesArticle,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible,
    saCoreTypes,
    history,
    match
}) {
    const [salesArticle, setSalesArticle] = useState();
    const [prevSalesArticle, setPrevSalesArticle] = useState({});
    const [tab, setTab] = useState(0);

    const handleTabChange = (event, value) => {
        setTab(value);
    };

    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    useEffect(() => {
        if (item !== prevSalesArticle) {
            setSalesArticle(item);
            setPrevSalesArticle(item);
        }
    });

    const handleSaveClick = () => {
        if (editing()) {
            updateSalesArticle(itemId, salesArticle);
            setEditStatus('view');
        }
    };

    const handleCancelClick = () => {
        setSalesArticle(item);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push('/products/maint/sales-articles');
    };

    const handleFieldChange = (propertyName, newValue) => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }

        setSalesArticle({ ...salesArticle, [propertyName]: newValue });
    };
    const salesArticleCoreTypeHref = getHref(salesArticle, 'sa-core-type')
        ? getHref(salesArticle, 'sa-core-type')
        : '';

    const handleLinkRelChange = (rel, newValue) => {
        setEditStatus('edit');
        let { links } = salesArticle;
        if (newValue) {
            links = links.map(link => (link.rel === rel ? { rel, href: newValue } : link));
        }

        setSalesArticle({ ...salesArticle, links });
    };

    let saCoreTypeItems;

    if (saCoreTypes.length > 0) {
        saCoreTypeItems = saCoreTypes
            .filter(sa => !sa.dateInvalid)
            .map(sa => ({
                id: getSelfHref(sa),
                displayText: sa.description
            }));
        saCoreTypeItems.push({ id: '', displayText: '' });
    } else {
        saCoreTypeItems = [
            { id: salesArticleCoreTypeHref, displayText: salesArticleCoreTypeHref || 'Waiting' }
        ];
    }

    const forecastTypes = [
        { id: 'Y', displayText: 'Yes' },
        { id: 'N', displayText: 'No' },
        { id: '', displayText: '' }
    ];

    return (
        <Page>
            <Grid container spacing={24}>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading || !salesArticle ? (
                    <Grid item xs={12}>
                        <Loading />
                    </Grid>
                ) : (
                    <Fragment>
                        <SnackbarMessage
                            visible={snackbarVisible}
                            onClose={() => setSnackbarVisible(false)}
                            message="Save Successful"
                        />

                        <Grid item xs={12}>
                            <Tabs
                                value={tab}
                                onChange={handleTabChange}
                                indicatorColor="primary"
                                textColor="primary"
                                style={{ paddingBottom: '40px' }}
                            >
                                <Tab label="View Or Edit Details" />
                                <Tab label="View Hold History" />
                                <Tab label="Set Composite Discount" />
                            </Tabs>
                            {tab === 0 && (
                                <Grid container spacing={24}>
                                    <Grid item xs={6}>
                                        <Title text={salesArticle.articleNumber} />
                                    </Grid>
                                    <Grid item xs={6}>
                                        <Typography
                                            color="textSecondary"
                                            style={{ textAlign: 'right' }}
                                            gutterBottom
                                        >
                                            {salesArticle.onHold &&
                                            !salesArticle.rootProductOnHold ? (
                                                <Fragment>
                                                    <span> ON HOLD </span>

                                                    <Button
                                                        disabled={salesArticle.rootProductOnHold}
                                                        component={Link}
                                                        to={getHref(salesArticle, 'put-off-hold')}
                                                    >
                                                        REMOVE HOLD
                                                    </Button>
                                                </Fragment>
                                            ) : (
                                                <Tooltip
                                                    disableFocusListener
                                                    title={
                                                        salesArticle.rootProductOnHold
                                                            ? 'This sales article is already on hold as part of its root product group.'
                                                            : ''
                                                    }
                                                    placement="top-end"
                                                >
                                                    <span>
                                                        <Button
                                                            component={Link}
                                                            disabled={
                                                                salesArticle.rootProductOnHold
                                                            }
                                                            to={getHref(
                                                                salesArticle,
                                                                'put-on-hold'
                                                            )}
                                                        >
                                                            PUT ON HOLD
                                                        </Button>
                                                    </span>
                                                </Tooltip>
                                            )}
                                            {salesArticle.rootProductOnHold && (
                                                <div>ROOT PRODUCT ON HOLD</div>
                                            )}
                                        </Typography>
                                    </Grid>
                                    <Grid item xs={6}>
                                        <InputField
                                            propertyName="description"
                                            label="Description"
                                            fullWidth
                                            disabled
                                            rows={4}
                                            value={salesArticle.description}
                                        />
                                    </Grid>
                                    <Grid item xs={3}>
                                        <InputField
                                            label="Forecast From"
                                            type="date"
                                            fullWidth
                                            propertyName="forecastFromDate"
                                            value={moment(salesArticle.forecastFromDate).format(
                                                'YYYY-MM-DD'
                                            )}
                                            onChange={handleFieldChange}
                                        />
                                    </Grid>
                                    <Grid item xs={3}>
                                        <InputField
                                            label="Forecast To"
                                            type="date"
                                            fullWidth
                                            propertyName="forecastToDate"
                                            value={moment(salesArticle.forecastToDate).format(
                                                'YYYY-MM-DD'
                                            )}
                                            onChange={handleFieldChange}
                                        />
                                    </Grid>
                                    <Grid item xs={3}>
                                        <Dropdown
                                            label="Forecast Type"
                                            propertyName="forecastType"
                                            items={forecastTypes}
                                            fullWidth
                                            value={salesArticle.forecastType}
                                            onChange={handleFieldChange}
                                        />
                                    </Grid>
                                    <Grid item xs={3}>
                                        <InputField
                                            label="% of Root Product Sales"
                                            type="number"
                                            fullWidth
                                            propertyName="percentageOfRootProductSales"
                                            value={salesArticle.percentageOfRootProductSales}
                                            onChange={handleFieldChange}
                                        />
                                    </Grid>
                                    <Grid item xs={6} />
                                    <Grid item xs={3}>
                                        <Dropdown
                                            label="Core Type"
                                            propertyName="sa-core-type"
                                            items={saCoreTypeItems}
                                            fullWidth
                                            value={salesArticleCoreTypeHref}
                                            onChange={handleLinkRelChange}
                                        />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <SaveBackCancelButtons
                                            saveDisabled={viewing()}
                                            saveClick={handleSaveClick}
                                            cancelClick={handleCancelClick}
                                            backClick={handleBackClick}
                                        />
                                    </Grid>
                                </Grid>
                            )}
                            {tab === 1 && (
                                <HoldStoriesBySalesArticle
                                    articleNumber={salesArticle.articleNumber}
                                    match={match}
                                />
                            )}
                            {tab === 2 && (
                                <SalesArticleCompositeDiscount
                                    articleNumber={salesArticle.articleNumber}
                                    match={match}
                                />
                            )}
                        </Grid>
                    </Fragment>
                )}
            </Grid>
        </Page>
    );
}

SalesArticle.defaultProps = {
    item: PropTypes.shape({
        id: PropTypes.string,
        description: PropTypes.string,
        forecastFromDate: PropTypes.string,
        forecastToDate: PropTypes.string,
        forecastType: PropTypes.string,
        percentageOfRootProductSales: PropTypes.number
    }),
    updateSalesArticle: null,
    loading: null,
    errorMessage: '',
    itemId: null,
    snackbarVisible: false
};

SalesArticle.propTypes = {
    item: PropTypes.shape({}),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    itemId: PropTypes.string,
    updateSalesArticle: PropTypes.func,
    setEditStatus: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired,
    saCoreTypes: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    match: PropTypes.shape({}).isRequired
};

export default SalesArticle;
