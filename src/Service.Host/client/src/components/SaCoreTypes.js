import React from 'react';
import PropTypes from 'prop-types';
import Grid from '@material-ui/core/Grid';
import {
    Loading,
    EntityList,
    CreateButton,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

const SaCoreTypes = ({ saCoreTypes, loading, errorMessage }) => (
    <Page>
        <Grid container spacing={24}>
            {errorMessage && (
                <Grid item xs={12}>
                    <ErrorCard errorMessage={errorMessage} />
                </Grid>
            )}
            {loading ? (
                <Grid item xs={12}>
                    <Loading />
                </Grid>
            ) : (
                <Grid item xs={12}>
                    <CreateButton createUrl="/products/maint/sa-core-types/create" />
                    <EntityList
                        title="SA Core Types"
                        entityList={saCoreTypes}
                        entityId="coreType"
                        loading={loading}
                        descriptionFieldName="description"
                    />
                </Grid>
            )}
        </Grid>
    </Page>
);

SaCoreTypes.defaultProps = {
    errorMessage: ''
};

SaCoreTypes.propTypes = {
    saCoreTypes: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired,
    errorMessage: PropTypes.string
};

export default SaCoreTypes;
