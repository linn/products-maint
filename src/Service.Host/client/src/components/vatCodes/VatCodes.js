import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import { Loading, EntityList, CreateButton } from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';
import { sortEntityList } from '../../helpers/utilities';

function VatCodes({ vatCodes, loading }) {
    return (
        <Page>
            {loading ? (
                <Loading />
            ) : (
                <Fragment>
                    <CreateButton createUrl="/products/maint/vat-codes/create" />
                    <EntityList
                        title="Vat Codes"
                        entityList={sortEntityList(vatCodes, 'code')}
                        entityId="code"
                        loading={loading}
                        descriptionFieldName="description"
                    />
                </Fragment>
            )}
        </Page>
    );
}

VatCodes.propTypes = {
    vatCodes: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired
};

export default VatCodes;
