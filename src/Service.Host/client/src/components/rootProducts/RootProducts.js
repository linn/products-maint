import React from 'react';
import Grid from '@material-ui/core/Grid';
import { Typeahead, ErrorCard } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const RootProducts = ({ items, fetchItems, loading, clearSearch, errorMessage }) => {
    const forecastItems = items.map(item => ({
        ...item,
        id: item.name,
        name: item.name
    }));

    return (
        <Page>
            <Grid container spacing={3}>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                <Grid item xs={12}>
                    <Typeahead
                        items={forecastItems}
                        fetchItems={fetchItems}
                        clearSearch={clearSearch}
                        loading={loading}
                        title="Search for Root Product"
                    />
                </Grid>
            </Grid>
        </Page>
    );
};

RootProducts.propTypes = {
    items: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
            name: PropTypes.string,
            description: PropTypes.string
        })
    ).isRequired,
    loading: PropTypes.bool,
    fetchItems: PropTypes.func.isRequired,
    clearSearch: PropTypes.func.isRequired,
    errorMessage: PropTypes.string
};

RootProducts.defaultProps = {
    loading: false,
    errorMessage: ''
};

export default RootProducts;
