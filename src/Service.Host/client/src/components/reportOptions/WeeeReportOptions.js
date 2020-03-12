import React, { useState } from 'react';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import { Title, DatePicker, Dropdown } from '@linn-it/linn-form-components-library';
import { makeStyles } from '@material-ui/styles';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

const useStyles = makeStyles(theme => ({
    marginTop: {
        marginTop: theme.spacing(2)
    }
}));

export default function WeeeReportOptions({ history }) {
    const [options, setOptions] = useState({ fromDate: null, toDate: null, countryCode: null });

    const classes = useStyles();

    const handleFieldChange = (propertyName, newValue) => {
        setOptions(o => ({ ...o, [propertyName]: newValue }));
    };

    const handleRunClick = () => {
        const from = options.fromDate.toISOString();
        const to = options.toDate.toISOString();

        const searchString = `?fromDate=${from}&toDate=${to}&countryCode=${options.countryCode}`;

        history.push({
            pathname: '/products/reports/weee/report',
            search: searchString
        });
    };

    return (
        <Page>
            <>
                <Title text="WEEE Report" />
                <Grid className={classes.marginTop} container spacing={3} justify="center">
                    <Grid item xs={4}>
                        <DatePicker
                            value={options.fromDate}
                            label="From Date"
                            onChange={value => handleFieldChange('fromDate', value)}
                        />
                    </Grid>
                    <Grid item xs={8} />
                    <Grid item xs={4}>
                        <DatePicker
                            value={options.toDate}
                            label="To Date"
                            onChange={value => handleFieldChange('toDate', value)}
                        />
                    </Grid>
                    <Grid item xs={8} />
                    <Grid item xs={4}>
                        <Dropdown
                            value={options.countryCode}
                            label="Country"
                            fullWidth
                            items={[
                                { id: 'GB', displayText: 'United Kingdom' },
                                { id: 'DE', displayText: 'Germany' }
                            ]}
                            onChange={handleFieldChange}
                            propertyName="countryCode"
                            allowNoValue
                        />
                    </Grid>
                    <Grid item xs={8} />
                    <Grid item xs={12}>
                        <Button
                            color="primary"
                            variant="contained"
                            style={{ float: 'right' }}
                            onClick={handleRunClick}
                        >
                            Run Report
                        </Button>
                    </Grid>
                </Grid>
            </>
        </Page>
    );
}

WeeeReportOptions.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired
};
