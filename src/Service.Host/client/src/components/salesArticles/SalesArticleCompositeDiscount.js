import React, { Fragment, useState, useEffect } from 'react';
import { Grid } from '@material-ui/core';
import {
    InputField,
    Title,
    Loading,
    SaveBackCancelButtons,
    SnackbarMessage
} from '@linn-it/linn-form-components-library';
import PropTypes from 'prop-types';
import SalesArticleTypeaheadDialog from '../../containers/common/SalesArticleTypeaheadDialog';

import history from '../../history';

function SalesArticleCompositeDiscount({
    loading,
    editStatus,
    item,
    itemId,
    updateSalesArticleCompositeDiscount,
    setEditStatus,
    snackbarVisible,
    setSnackbarVisible
}) {
    const [salesArticleCompositeDiscount, setSalesArticleCompositeDiscount] = useState();
    const [prevSalesArticleCompositeDiscount, setPrevSalesArticleCompositeDiscount] = useState({});

    useEffect(() => {
        if (item !== prevSalesArticleCompositeDiscount) {
            setSalesArticleCompositeDiscount(item);
            setPrevSalesArticleCompositeDiscount(item);
        }
    });

    const editing = () => editStatus === 'edit';
    const viewing = () => editStatus === 'view';

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

    const handleBaseChange = newValue => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }

        setSalesArticleCompositeDiscount({
            ...salesArticleCompositeDiscount,
            baseArticleNumber: newValue.articleNumber
        });
    };

    const handleGlossChange = newValue => {
        if (editStatus === 'view') {
            setEditStatus('edit');
        }

        setSalesArticleCompositeDiscount({
            ...salesArticleCompositeDiscount,
            noDiscountArticleNumber: newValue.articleNumber
        });
    };

    return (
        <Grid container spacing={3}>
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

                    <Grid container spacing={3}>
                        <Grid item xs={12}>
                            <Title
                                text={`Composite discount parts for ${
                                    salesArticleCompositeDiscount.articleNumber
                                }`}
                            />
                        </Grid>
                        <Grid item xs={4}>
                            <InputField
                                label="Base Part"
                                type="string"
                                propertyName="baseArticleNumber"
                                value={salesArticleCompositeDiscount.baseArticleNumber}
                                onChange={handleFieldChange}
                            />
                            <SalesArticleTypeaheadDialog
                                onSelect={handleBaseChange}
                                title="Search for sales article"
                            />
                        </Grid>
                        <Grid item xs={4}>
                            <InputField
                                label="Gloss Part"
                                type="string"
                                propertyName="noDiscountArticleNumber"
                                value={salesArticleCompositeDiscount.noDiscountArticleNumber}
                                onChange={handleFieldChange}
                            />
                            <SalesArticleTypeaheadDialog
                                onSelect={handleGlossChange}
                                title="Search for sales article"
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

SalesArticleCompositeDiscount.propTypes = {
    item: PropTypes.shape({}),
    editStatus: PropTypes.string.isRequired,
    itemId: PropTypes.string,
    updateSalesArticleCompositeDiscount: PropTypes.func,
    setEditStatus: PropTypes.func.isRequired,
    loading: PropTypes.bool,
    snackbarVisible: PropTypes.bool,
    setSnackbarVisible: PropTypes.func.isRequired,
    match: PropTypes.shape({}).isRequired
};

SalesArticleCompositeDiscount.defaultProps = {
    item: PropTypes.shape({
        articleNumber: PropTypes.string,
        baseArticleNumber: PropTypes.string,
        noDiscountArticleNumber: PropTypes.string
    }),
    updateSalesArticleCompositeDiscount: null,
    loading: null,
    itemId: null,
    snackbarVisible: false
};

export default SalesArticleCompositeDiscount;
