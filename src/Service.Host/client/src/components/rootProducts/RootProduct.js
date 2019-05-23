import React, { Fragment, useState } from 'react';
import { Grid, Typography, Button, Tabs, Tab } from '@material-ui/core';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import {
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage,
    getHref
} from '@linn-it/linn-form-components-library';
import HoldStoriesByRootProduct from '../../containers/saHoldStories/HoldStoriesByRootProduct';

import Page from '../../containers/Page';

function RootProduct({ item, snackbarVisible, setSnackbarVisible, loading, errorMessage, match }) {
    const [tab, setTab] = useState(0);

    const handleTabChange = (event, value) => {
        setTab(value);
    };
    return (
        <Page>
            <Grid container spacing={24}>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading || !item ? (
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
                            <Grid item xs={12}>
                                <Tabs
                                    value={tab}
                                    onChange={handleTabChange}
                                    indicatorColor="primary"
                                    textColor="primary"
                                    style={{ paddingBottom: '40px' }}
                                >
                                    <Tab label="Details" />
                                    <Tab label="Hold History" />
                                </Tabs>
                                {tab === 0 && (
                                    <Grid container spacing={24}>
                                        <Grid item xs={6}>
                                            <Title text={`${item.name} Root Product Details`} />
                                        </Grid>
                                        <Grid item xs={6}>
                                            <Typography
                                                color="textSecondary"
                                                style={{ textAlign: 'right' }}
                                                gutterBottom
                                            >
                                                {item.onHold ? (
                                                    <Fragment>
                                                        <span> ON HOLD </span>
                                                        <Button
                                                            component={Link}
                                                            to={getHref(item, 'put-off-hold')}
                                                        >
                                                            REMOVE HOLD
                                                        </Button>{' '}
                                                    </Fragment>
                                                ) : (
                                                    <Button
                                                        component={Link}
                                                        to={getHref(item, 'put-on-hold')}
                                                    >
                                                        PUT ON HOLD
                                                    </Button>
                                                )}
                                            </Typography>
                                        </Grid>
                                        <Grid item xs={6}>
                                            <InputField
                                                value={item.name}
                                                disabled
                                                label="Name"
                                                fullWidth
                                                rows={3}
                                                propertyName="name"
                                                maxLength={2000}
                                                error={!item.name}
                                            />
                                        </Grid>
                                        <Grid item xs={6}>
                                            <InputField
                                                value={item.description}
                                                disabled
                                                label="Description"
                                                fullWidth
                                                rows={3}
                                                propertyName="description"
                                                maxLength={2000}
                                                error={!item.description}
                                            />
                                        </Grid>
                                    </Grid>
                                )}
                            </Grid>
                        </Grid>
                    </Fragment>
                )}
                {tab === 1 && <HoldStoriesByRootProduct rootproduct={item.name} match={match} />}
            </Grid>
        </Page>
    );
}

RootProduct.defaultProps = {
    item: null,
    loading: null,
    errorMessage: '',
    snackbarVisible: false
};

RootProduct.propTypes = {
    item: PropTypes.shape({}),
    errorMessage: PropTypes.string,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired,
    match: PropTypes.shape({}).isRequired
};

export default RootProduct;
