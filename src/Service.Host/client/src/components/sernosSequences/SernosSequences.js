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

function SernosSequences({ sernosSequences, loading, errorMessage }) {
    return (
        <Page>
            <Grid container spacing={3}>
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
                        <CreateButton createUrl="/products/maint/sernos-sequences/create" />
                        <EntityList
                            title="Sernos Sequences"
                            entityList={sortEntityList(sernosSequences, 'sequenceName')}
                            entityId="sequenceName"
                            loading={loading}
                            descriptionFieldName="description"
                        />
                    </Grid>
                )}
            </Grid>
        </Page>
    );
}

SernosSequences.propTypes = {
    sernosSequences: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool.isRequired,
    errorMessage: PropTypes.string
};

SernosSequences.defaultProps = {
    errorMessage: ''
};

export default SernosSequences;
