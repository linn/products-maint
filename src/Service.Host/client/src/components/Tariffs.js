import React from 'react';
import Grid from '@material-ui/core/Grid';
import { Typeahead } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../containers/Page';

const Tariffs = ({ tariffs, fetchItems, loading, clearSearch }) => {
    const results = tariffs.map(tariff => ({
        ...tariff,
        name: tariff.tariffCode,
        description:
            tariff.description.length > 100
                ? `${tariff.description.substring(0, 100)} ...`
                : tariff.description
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
                        title="Search by tariff code or description"
                    />
                </Grid>
            </Grid>
        </Page>
    );
};

Tariffs.propTypes = {
    tariffs: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    loading: PropTypes.bool,
    fetchItems: PropTypes.func.isRequired,
    clearSearch: PropTypes.func.isRequired
};

Tariffs.defaultProps = {
    loading: false
};

export default Tariffs;
