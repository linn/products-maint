import React from 'react';
import Grid from '@material-ui/core/Grid';
import { Typeahead, CreateButton, ErrorCard } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const Tariffs = ({ items, fetchItems, loading, clearSearch, errorMessage }) => {
    const results = items.map(tariff => ({
        ...tariff,
        name: tariff.tariffCode,
        description:
            tariff.description.length > 100
                ? `${tariff.description.substring(0, 100)} ...`
                : tariff.description
    }));

    const hasPermission = () => {
        if (items[0]) {
            return items[0].links.some(l => l.rel === 'tariff.admin');
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
                <Grid item xs={10}>
                    <Typeahead
                        items={results}
                        fetchItems={fetchItems}
                        clearSearch={clearSearch}
                        loading={loading}
                        title="Search by tariff code or description"
                    />
                </Grid>
                <Grid item xs={2}>
                    <CreateButton
                        disabled={!hasPermission()}
                        createUrl="/products/maint/tariffs/create"
                    />
                </Grid>
            </Grid>
        </Page>
    );
};

Tariffs.propTypes = {
    items: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool,
    fetchItems: PropTypes.func.isRequired,
    clearSearch: PropTypes.func.isRequired,
    errorMessage: PropTypes.string
};

Tariffs.defaultProps = {
    loading: false,
    errorMessage: ''
};

export default Tariffs;
