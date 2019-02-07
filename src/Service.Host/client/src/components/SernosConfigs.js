import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Page, Loading, EntityList, CreateButton } from '@linn-it/linn-form-components-library';

const SernosConfigs = ({ sernosConfigs, loading, history }) => (
    <Page history={history}>
        {loading ? (
            <Loading />
        ) : (
            <Fragment>
                <CreateButton createUrl="/products/maint/sernos-configs/create" />
                <EntityList
                    title="Sernos Configs"
                    entityList={sernosConfigs}
                    entityId="name"
                    loading={loading}
                    descriptionFieldName="description"
                />
            </Fragment>
        )}
    </Page>
);

SernosConfigs.propTypes = {
    sernosConfigs: PropTypes.arrayOf(PropTypes.shape({})),
    history: PropTypes.shape({}).isRequired,
    loading: PropTypes.bool.isRequired
};

SernosConfigs.defaultProps = {
    sernosConfigs: null
};

export default SernosConfigs;
