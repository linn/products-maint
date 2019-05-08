import React, { useState } from 'react';
import { Button, Grid, Typography } from '@material-ui/core';
import { InputField } from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import Page from '../../containers/Page';

function SernosUsedOnInvoiceOptions({ prevOptions, history }) {
    const [invoiceNumber, setInvoiceNumber] = useState(prevOptions.invoiceNumber);
    const [consignmentNumber, setConsignmentNumber] = useState(prevOptions.consignmentNumber);

    const handleClick = () =>
        history.push({
            pathname: `/products/reports/sernos-used-on-invoice/report`,
            search: `?invoiceNumber=${invoiceNumber}&consignmentNumber=${consignmentNumber}`
        });
    return (
        <Page>
            <Grid style={{ marginTop: 40 }} container spacing={24} justify="center">
                <Grid item xs={12}>
                    <Typography variant="h4" gutterBottom>
                        Search Invoice, Consignment or Both:
                    </Typography>
                </Grid>
                <Grid item xs={12}>
                    <InputField
                        fullWidth
                        value={invoiceNumber}
                        label="Invoice Number"
                        onChange={(propertyName, value) => setInvoiceNumber(value)}
                        propertyName="invoiceNumber"
                        error={false}
                    />
                </Grid>
                <Grid item xs={12}>
                    <InputField
                        fullWidth
                        value={consignmentNumber}
                        label="Consignment Number"
                        onChange={(propertyName, value) => setConsignmentNumber(value)}
                        propertyName="consignmentNumber"
                        error={false}
                    />
                </Grid>
                <Button
                    color="primary"
                    variant="contained"
                    disabled={!invoiceNumber && !consignmentNumber}
                    onClick={handleClick}
                >
                    Run Report
                </Button>
            </Grid>
        </Page>
    );
}

SernosUsedOnInvoiceOptions.propTypes = {
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    prevOptions: PropTypes.shape({
        invoiceNumber: PropTypes.string,
        consignmentNumber: PropTypes.string
    }).isRequired
};

export default SernosUsedOnInvoiceOptions;
