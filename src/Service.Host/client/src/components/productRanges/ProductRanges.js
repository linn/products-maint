import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Loading, EntityList, CreateButton } from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

const ProductRanges = ({ items, loading }) => (
    <Page>
        {loading ? (
            <Loading />
        ) : (
            <Fragment>
                <CreateButton createUrl="/products/maint/product-ranges/create" />
                <EntityList
                    title="Product Ranges"
                    entityList={items.sort((a, b) => a.rangeName.localeCompare(b.rangeName))}
                    entityId="rangeName"
                    loading={loading}
                    descriptionFieldName="rangeDescription"
                />
            </Fragment>
        )}
    </Page>
);

ProductRanges.propTypes = {
    items: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired
};

export default ProductRanges;
