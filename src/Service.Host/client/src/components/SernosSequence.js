import React, { Fragment, useState } from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Grid } from '@material-ui/core';
import {
    SaveBackCancelButtons,
    InputField,
    Loading,
    Title,
    ErrorCard
} from '@linn-it/linn-form-components-library';
import Page from '../containers/Page';

function SernosSequence({
    editStatus,
    errorMessage,
    history,
    itemId,
    item,
    loading,
    addItem,
    updateItem,
    setEditStatus
}) {
    const [sernosSequence, setSernosSequence] = useState({});
    const [prevSernosSequence, setPrevSernosSequence] = useState({});

    function creating() {
        return editStatus === 'create';
    }

    function editing() {
        return editStatus === 'edit';
    }

    function viewing() {
        return editStatus === 'view';
    }

    function sequenceNameInvalid() {
        return !sernosSequence.sequenceName;
    }

    function descriptionInvalid() {
        return !sernosSequence.description;
    }

    function nextSerialNumberInvalid() {
        return typeof sernosSequence.nextSerialNumber !== 'number';
    }

    function inputInvalid() {
        return sequenceNameInvalid() || descriptionInvalid() || nextSerialNumberInvalid();
    }

    function handleSaveClick() {
        if (editing()) {
            updateItem(itemId, sernosSequence);
            setEditStatus('view');
        } else if (creating()) {
            addItem(sernosSequence);
            setEditStatus('view');
        }
    }

    function handleCancelClick() {
        setSernosSequence(item);
        setEditStatus('view');
    }

    function handleBackClick() {
        history.push('/products/maint/sernos-sequences');
    }

    function handleFieldChange(propertyName, newValue) {
        if (viewing()) {
            setEditStatus('edit');
        }
        setSernosSequence({ ...sernosSequence, [propertyName]: newValue });
    }

    function updateSernosSequenceFromProps() {
        if (item !== prevSernosSequence) {
            setSernosSequence(item);
            setPrevSernosSequence(item);
        }
    }

    return (
        <Page>
            {!creating() && updateSernosSequenceFromProps()}
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {creating() ? (
                        <Title text="Create Sernos Sequence" />
                    ) : (
                        <Title text="Sernos Sequence Details" />
                    )}
                </Grid>
                {errorMessage && (
                    <Grid item xs={12}>
                        <ErrorCard errorMessage={errorMessage} />
                    </Grid>
                )}
                {loading || !sernosSequence ? (
                    <Grid item xs={12}>
                        <Loading />
                    </Grid>
                ) : (
                    <Fragment>
                        <Grid item xs={8}>
                            <InputField
                                fullWidth
                                disabled={!creating()}
                                value={sernosSequence.sequenceName}
                                label="Sequence Name"
                                maxLength={10}
                                helperText={
                                    !creating()
                                        ? 'This field cannot be changed'
                                        : `${sequenceNameInvalid() ? 'This field is required' : ''}`
                                }
                                error={sequenceNameInvalid()}
                                onChange={handleFieldChange}
                                propertyName="sequenceName"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={sernosSequence.description}
                                label="Description"
                                maxLength={50}
                                fullWidth
                                helperText={descriptionInvalid() ? 'This field is required' : ''}
                                error={descriptionInvalid()}
                                onChange={handleFieldChange}
                                propertyName="description"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={sernosSequence.nextSerialNumber}
                                error={nextSerialNumberInvalid()}
                                label="Next Serial Number"
                                fullWidth
                                helperText={
                                    nextSerialNumberInvalid() ? 'This field is required' : ''
                                }
                                onChange={handleFieldChange}
                                propertyName="nextSerialNumber"
                                type="number"
                            />
                        </Grid>
                        <Grid item xs={8}>
                            <InputField
                                value={
                                    sernosSequence.dateClosed
                                        ? moment(sernosSequence.dateClosed).format('YYYY-MM-DD')
                                        : ''
                                }
                                label="Date Closed"
                                fullWidth
                                onChange={handleFieldChange}
                                propertyName="dateClosed"
                                type="date"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <SaveBackCancelButtons
                                saveDisabled={viewing() || inputInvalid()}
                                saveClick={handleSaveClick}
                                cancelClick={handleCancelClick}
                                backClick={handleBackClick}
                            />
                        </Grid>
                    </Fragment>
                )}
            </Grid>
        </Page>
    );
}

SernosSequence.propTypes = {
    item: PropTypes.shape({
        sernosSequence: PropTypes.string,
        description: PropTypes.string,
        nextSerialNumber: PropTypes.number,
        dateClosed: PropTypes.string
    }),
    history: PropTypes.shape({}).isRequired,
    editStatus: PropTypes.string.isRequired,
    errorMessage: PropTypes.string,
    itemId: PropTypes.string,
    updateItem: PropTypes.func,
    addItem: PropTypes.func,
    loading: PropTypes.bool,
    setEditStatus: PropTypes.func.isRequired
};

SernosSequence.defaultProps = {
    item: {},
    addItem: null,
    updateItem: null,
    loading: null,
    errorMessage: '',
    itemId: null
};

export default SernosSequence;
