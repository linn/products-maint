import React from 'react';
import Grid from '@material-ui/core/Grid';
import { Typeahead } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const SaHoldStoriesSearch = ({ items, fetchItems, loading, clearSearch }) => {
    const results = items.map(item => ({
        ...item,
        name: item.articleNumber,
        id: item.articleNumber
    }));

    return (
        <Page>
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    <Typeahead
                        items={results}
                        fetchItems={fetchItems}
                        clearSearch={clearSearch}
                        loading={loading}
                        title="Search for Sales Article"
                    />
                </Grid>
            </Grid>
        </Page>
    );
};

SaHoldStoriesSearch.propTypes = {
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
    clearSearch: PropTypes.func.isRequired
};

SaHoldStoriesSearch.defaultProps = {
    loading: false
};

export default SaHoldStoriesSearch;
