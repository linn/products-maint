import React, { Fragment, useState } from 'react';
import { Grid, Typography, Button, Tabs, Tab, Tooltip } from '@material-ui/core';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import {
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage,
    utilities
} from '@linn-it/linn-form-components-library';
import HoldStoriesByRootProduct from '../../containers/saHoldStories/HoldStoriesByRootProduct';

import Page from '../../containers/Page';

function RootProduct({ item, snackbarVisible, setSnackbarVisible, loading, errorMessage, match }) {
    const [tab, setTab] = useState(0);

    const canChangeHoldStatus = () => {
        if (item.onHold) {
            return item.links.some(l => l.rel === 'put-off-hold');
        }
        return item.links.some(l => l.rel === 'put-on-hold');
    };

    const tooltipText = () => {
        if (!canChangeHoldStatus()) {
            return 'You are not authorised to complete this action.';
        }
        return '';
    };

    const buttonProps = rel => {
        let props;
        if (canChangeHoldStatus()) {
            props = {
                component: Link,
                to: utilities.getHref(item, rel)
            };
        } else {
            props = {
                disabled: true
            };
        }
        return props;
    };

    const handleTabChange = (event, value) => {
        setTab(value);
    };
    return (
        <Page>
            <Grid container spacing={3}>
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
                                    <Grid container spacing={3}>
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
                                                        <Tooltip
                                                            disableFocusListener
                                                            title={tooltipText()}
                                                            placement="top-end"
                                                        >
                                                            <span>
                                                                <Button
                                                                    {...buttonProps('put-off-hold')}
                                                                >
                                                                    REMOVE HOLD
                                                                </Button>
                                                            </span>
                                                        </Tooltip>
                                                    </Fragment>
                                                ) : (
                                                    <Tooltip
                                                        disableFocusListener
                                                        title={tooltipText()}
                                                        placement="top-end"
                                                    >
                                                        <span>
                                                            <Button {...buttonProps('put-on-hold')}>
                                                                PUT ON HOLD
                                                            </Button>
                                                        </span>
                                                    </Tooltip>
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
    item: PropTypes.shape({
        description: PropTypes.string,
        name: PropTypes.string,
        onHold: PropTypes.bool,
        links: PropTypes.array
    }),
    errorMessage: PropTypes.string,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired,
    match: PropTypes.shape({}).isRequired
};

export default RootProduct;
