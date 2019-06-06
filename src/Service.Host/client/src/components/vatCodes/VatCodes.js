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
import { sortEntityList } from '../../helpers/utilities';

function VatCodes({ vatCodes, loading, errorMessage }) {
    const hasPermission = () => {
        if (vatCodes[0]) {
            return vatCodes[0].links.some(l => l.rel === 'vat.admin');
        }
        return false;
    };

    return (
        <Page>
            <Grid container spacing={24}>
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
                        <CreateButton
                            disabled={!hasPermission()}
                            createUrl="/products/maint/vat-codes/create"
                        />
                        <EntityList
                            title="Vat Codes"
                            entityList={sortEntityList(vatCodes, 'code')}
                            entityId="code"
                            loading={loading}
                            descriptionFieldName="description"
                        />
                    </Grid>
                )}
            </Grid>
        </Page>
    );
}

VatCodes.propTypes = {
    vatCodes: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired,
    errorMessage: PropTypes.string
};

VatCodes.defaultProps = {
    errorMessage: ''
};

export default VatCodes;
