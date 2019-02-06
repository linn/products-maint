import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Loading, EntityList, CreateButton } from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

const TypesOfSale = ({ typesOfSale, loading }) => (
    <Page>
        {loading ? (
            <Loading />
        ) : (
            <Fragment>
                <CreateButton createUrl="/products/maint/types-of-sale/create" />
                <EntityList
                    title="Types of Sale"
                    entityList={typesOfSale}
                    entityId="name"
                    loading={loading}
                    descriptionFieldName="description"
                />
            </Fragment>
        )}
    </Page>
);

TypesOfSale.propTypes = {
    typesOfSale: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired
};

export default TypesOfSale;
