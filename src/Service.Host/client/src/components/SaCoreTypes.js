import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Page, Loading, EntityList, CreateButton } from '@linn-it/linn-form-components-library';

const SaCoreTypes = ({ saCoreTypes, loading, history }) => (
    <Page history={history}>
        {loading ? (
            <Loading />
        ) : (
            <Fragment>
                <CreateButton createUrl="/products/maint/sa-core-types/create" />
                <EntityList
                    title="SA Core Types"
                    entityList={saCoreTypes}
                    entityId="coreType"
                    loading={loading}
                    descriptionFieldName="description"
                />
            </Fragment>
        )}
    </Page>
);

SaCoreTypes.propTypes = {
    saCoreTypes: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    history: PropTypes.shape.isRequired,
    loading: PropTypes.bool.isRequired
};

export default SaCoreTypes;
