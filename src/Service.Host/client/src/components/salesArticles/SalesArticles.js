import React from 'react';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { ErrorCard, Typeahead } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

function SalesArticles({ items, fetchItems, loading, clearSearch, errorMessage, history }) {
    const forecastItems = items.map(item => ({
        ...item,
        name: item.articleNumber
    }));

    return (
        <Page>
            <Grid container spacing={3}>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                <Grid item xs={10}>
                    <Typeahead
                        items={forecastItems}
                        fetchItems={fetchItems}
                        clearSearch={clearSearch}
                        loading={loading}
                        title="Search for Sales Article"
                        history={history}
                    />
                </Grid>
                <Grid item xs={2}>
                    <Button href="/products/maint/sales-articles-reallocate" variant="outlined">
                        Reallocator Utility
                    </Button>
                </Grid>
            </Grid>
        </Page>
    );
}

SalesArticles.propTypes = {
    items: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
            name: PropTypes.string,
            description: PropTypes.string,
            href: PropTypes.string
        })
    ).isRequired,
    loading: PropTypes.bool,
    fetchItems: PropTypes.func.isRequired,
    clearSearch: PropTypes.func.isRequired,
    errorMessage: PropTypes.string,
    history: PropTypes.shape({}).isRequired
};

SalesArticles.defaultProps = {
    loading: false,
    errorMessage: ''
};

export default SalesArticles;
