import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Loading, EntityList, CreateButton, SnackbarMessage } from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

const SaCoreTypes = ({ saCoreTypes, loading, snackbarVisible, setSnackbarVisible }) => (
    <Page>
        {loading ? (
            <Loading />
        ) : (
            <Fragment>
                 <SnackbarMessage
                            visible={snackbarVisible}
                            onClose={() => setSnackbarVisible(false)}
                            message="Save Successful"
                        />
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
    loading: PropTypes.bool.isRequired
};

export default SaCoreTypes;
