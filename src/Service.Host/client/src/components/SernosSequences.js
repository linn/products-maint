import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Loading, EntityList, CreateButton } from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';
import { sortEntityList } from '../helpers/utilities';

function SernosSequences({ sernosSequences, loading }) {
    return (
        <Page>
            {loading ? (
                <Loading />
            ) : (
                <Fragment>
                    <CreateButton createUrl="/products/maint/sernos-sequences/create" />
                    <EntityList
                        title="Sernos Sequences"
                        entityList={sortEntityList(sernosSequences, 'sequenceName')}
                        entityId="sequenceName"
                        loading={loading}
                        descriptionFieldName="description"
                    />
                </Fragment>
            )}
        </Page>
    );
}

SernosSequences.propTypes = {
    sernosSequences: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired
};

export default SernosSequences;
