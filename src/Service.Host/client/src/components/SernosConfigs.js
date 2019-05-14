import React from 'react';
import Grid from '@material-ui/core/Grid';
import PropTypes from 'prop-types';
import {
    Page,
    Loading,
    EntityList,
    CreateButton,
    ErrorCard
} from '@linn-it/linn-form-components-library';

const SernosConfigs = ({ sernosConfigs, loading, history, errorMessage }) => (
    <Page history={history}>
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
                    <CreateButton createUrl="/products/maint/sernos-configs/create" />
                    <EntityList
                        title="Sernos Configs"
                        entityList={sernosConfigs}
                        entityId="name"
                        loading={loading}
                        descriptionFieldName="description"
                    />
                </Grid>
            )}
        </Grid>
    </Page>
);

SernosConfigs.propTypes = {
    sernosConfigs: PropTypes.arrayOf(PropTypes.shape({})),
    history: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool.isRequired,
    errorMessage: PropTypes.string
};

SernosConfigs.defaultProps = {
    sernosConfigs: null,
    errorMessage: ''
};

export default SernosConfigs;
