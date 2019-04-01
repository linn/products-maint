import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Loading, EntityList, CreateButton } from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

const SalesPackages = ({ items, loading }) => (
    <Page>
        {loading ? (
            <Loading />
        ) : (
            <Fragment>
                <CreateButton createUrl="/products/maint/sales-packages/create" />
                <EntityList
                    title="Sales Packages"
                    entityList={items.sort((a, b) => a.salesPackageId.localeCompare(b.salesPackageId))}
                    entityId="id"
                    loading={loading}
                    descriptionFieldName="description"
                />
            </Fragment>
        )}
    </Page>
);

SalesPackages.propTypes = {
    items: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired
};

export default SalesPackages;
