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

const ProductRanges = ({ items, loading, errorMessage }) => (
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
                    <CreateButton createUrl="/products/maint/product-ranges/create" />
                    <EntityList
                        title="Product Ranges"
                        entityList={items.sort((a, b) => a.rangeName.localeCompare(b.rangeName))}
                        entityId="rangeName"
                        loading={loading}
                        descriptionFieldName="rangeDescription"
                    />
                </Grid>
            )}
        </Grid>
    </Page>
);

ProductRanges.propTypes = {
    items: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired,
    errorMessage: PropTypes.string
};

ProductRanges.defaultProps = {
    errorMessage: ''
};

export default ProductRanges;
