import React from 'react';
import Grid from '@material-ui/core/Grid';
import PropTypes from 'prop-types';
import {
    Loading,
    EntityList,
    CreateButton,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';
import { sortEntityList } from '../../helpers/utilities';

const TypesOfSale = ({ typesOfSale, loading, errorMessage }) => (
    <Page>
        <Grid container spacing={3}>
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
                    <CreateButton createUrl="/products/maint/types-of-sale/create" />
                    <EntityList
                        title="Types of Sale"
                        entityList={sortEntityList(typesOfSale, 'name')}
                        entityId="name"
                        loading={loading}
                        descriptionFieldName="description"
                    />
                </Grid>
            )}
        </Grid>
    </Page>
);

TypesOfSale.propTypes = {
    typesOfSale: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired,
    errorMessage: PropTypes.string
};

TypesOfSale.defaultProps = {
    errorMessage: ''
};

export default TypesOfSale;
