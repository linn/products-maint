import React, { Fragment, useState, useEffect } from 'react';
import { Grid } from '@material-ui/core';
import {
    InputField,
    Title,
    Loading,
    SaveBackCancelButtons,
    SnackbarMessage,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import history from '../../history';

function SalesArticleCompositeDiscount({
    loading,
    editStatus,
    item,
    itemId,
    updateSalesArticleCompositeDiscount,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible,
    errorMessage
}) {
    const [salesArticleCompositeDiscount, setSalesArticleCompositeDiscount] = useState();
    const [prevSalesArticleCompositeDiscount, setPrevSalesArticleCompositeDiscount] = useState({});

    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

    useEffect(() => {
        if (item !== prevSalesArticleCompositeDiscount) {
            setSalesArticleCompositeDiscount(item);
            setPrevSalesArticleCompositeDiscount(item);
        }
    });

    const handleSaveClick = () => {
        if (editing()) {
            updateSalesArticleCompositeDiscount(itemId, salesArticleCompositeDiscount);
            setEditStatus('view');
        }
    };

    const handleCancelClick = () => {
        setSalesArticleCompositeDiscount(item);
        setEditStatus('view');
    };

    const handleBackClick = () => {
        history.push(`/products/maint/sales-articles`);
    };

    const handleFieldChange = (propertyName, newValue) => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }

        setSalesArticleCompositeDiscount({
            ...salesArticleCompositeDiscount,
            [propertyName]: newValue
        });
    };

    return (
        <Grid container spacing={24}>
            {loading || !salesArticleCompositeDiscount ? (
                <Grid item xs={12}>
                    <Loading />
                </Grid>
            ) : (
                <Fragment>
                    <SnackbarMessage
                        visible={snackbarVisible}
                        onClose={() => setSnackbarVisible(false)}
                        message="Save Successful"
                    />

                    <Grid container spacing={24}>
                        <Grid item xs={12}>
                            <Title
                                text={`Composite discount parts for ${
                                    salesArticleCompositeDiscount.articleNumber
                                }`}
                            />
                        </Grid>
                        <Grid item xs={3}>
                            <InputField
                                label="Base Part"
                                type="string"
                                fullWidth
                                propertyName="baseArticleNumber"
                                value={salesArticleCompositeDiscount.baseArticleNumber}
                                onChange={handleFieldChange}
                            />
                        </Grid>
                        <Grid item xs={3}>
                            <InputField
                                label="Gloss Part"
                                type="string"
                                fullWidth
                                propertyName="noDiscountArticleNumber"
                                value={salesArticleCompositeDiscount.noDiscountArticleNumber}
                                onChange={handleFieldChange}
                            />
                        </Grid>
                    </Grid>
                    <Grid item xs={12}>
                        <SaveBackCancelButtons
                            saveDisabled={viewing()}
                            saveClick={handleSaveClick}
                            cancelClick={handleCancelClick}
                            backClick={handleBackClick}
                        />
                    </Grid>
                </Fragment>
            )}
        </Grid>
    );
}

SalesArticleCompositeDiscount.defaultProps = {
    item: PropTypes.shape({
        articleNumber: PropTypes.string,
        baseArticleNumber: PropTypes.string,
        noDiscountArticleNumber: PropTypes.string
    }),
    updateSalesArticleCompositeDiscount: null,
    loading: null,
    itemId: null,
    snackbarVisible: false,
    errorMessage: ''
};

SalesArticleCompositeDiscount.propTypes = {
    item: PropTypes.shape({}),
    editStatus: PropTypes.string.isRequired,
    itemId: PropTypes.string,
    updateSalesArticleCompositeDiscount: PropTypes.func,
    setEditStatus: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired,
    match: PropTypes.shape({}).isRequired,
    errorMessage: PropTypes.string
};

export default SalesArticleCompositeDiscount;
