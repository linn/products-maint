import React, { Fragment } from 'react';
import { Grid, Typography, Button } from '@material-ui/core';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import {
    InputField,
    Loading,
    Title,
    ErrorCard,
    SnackbarMessage
} from '@linn-it/linn-form-components-library';
import { getHref } from '../../helpers/utilities';

import Page from '../../containers/Page';

function RootProduct({ item, snackbarVisible, setSnackbarVisible, loading, errorMessage }) {
    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    <Title text="RootProduct Details" />
                </Grid>
                {loading || !item ? (
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
                        <Grid item xs={12}>
                            <Typography
                                color="textSecondary"
                                style={{ textAlign: 'right' }}
                                gutterBottom
                            >
                                {item.onHold ? (
                                    <Fragment>
                                        <span> ON HOLD </span>
                                        <Button component={Link} to={getHref(item, 'put-off-hold')}>
                                            REMOVE HOLD
                                        </Button>{' '}
                                    </Fragment>
                                ) : (
                                    <Button component={Link} to={getHref(item, 'put-on-hold')}>
                                        PUT ON HOLD
                                    </Button>
                                )}
                            </Typography>
                        </Grid>
                        <Grid item xs={6}>
                            <InputField
                                value={item.name}
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
                                label="Description"
                                fullWidth
                                rows={3}
                                propertyName="description"
                                maxLength={2000}
                                error={!item.description}
                            />
                        </Grid>
                    </Fragment>
                )}
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
    setSnackbarVisible: PropTypes.func.isRequired
};

export default RootProduct;
