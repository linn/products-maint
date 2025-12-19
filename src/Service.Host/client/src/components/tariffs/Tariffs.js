import React from 'react';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { Typeahead, CreateButton, ErrorCard } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

function Tariffs({ items, fetchItems, loading, clearSearch, errorMessage, history }) {
    const results = items.map(tariff => ({
        ...tariff,
        name: tariff.tariffCode,
        description:
            tariff.description.length > 100
                ? `${tariff.description.substring(0, 100)} ...`
                : tariff.description
    }));

    return (
        <Page>
            <Grid container spacing={3}>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                <Grid item xs={8}>
                    <Typeahead
                        items={results}
                        fetchItems={fetchItems}
                        clearSearch={clearSearch}
                        loading={loading}
                        title="Search by tariff code or description"
                        history={history}
                    />
                </Grid>
                <Grid item xs={2}>
                    <Button href="/products/maint/tariffs-reallocate" variant="outlined">
                        Reallocator Utility
                    </Button>
                </Grid>
                <Grid item xs={2}>
                    <CreateButton createUrl="/products/maint/tariffs/create" />
                </Grid>
            </Grid>
        </Page>
    );
}

Tariffs.propTypes = {
    items: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool,
    fetchItems: PropTypes.func.isRequired,
    clearSearch: PropTypes.func.isRequired,
    errorMessage: PropTypes.string,
    history: PropTypes.shape({}).isRequired
};

Tariffs.defaultProps = {
    loading: false,
    errorMessage: ''
};

export default Tariffs;
