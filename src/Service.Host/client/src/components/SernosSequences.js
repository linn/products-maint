import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Loading, EntityList, CreateButton } from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

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
                        entityList={sernosSequences.sort((a, b) => {
                            if (a.sequenceName < b.sequenceName) {
                                return -1;
                            }
                            if (a.sequenceName > b.sequenceName) {
                                return 1;
                            }
                            return 0;
                        })}
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
