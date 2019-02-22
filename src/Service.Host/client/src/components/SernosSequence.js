import React, { Fragment, useState } from 'react';
import PropTypes from 'prop-types';
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
    sequenceName,
    editStatus,
    errorMessage,
    history,
    loading,
    addSernosSequence,
    updateSernosSequence,
    resetSernosSequence,
    setEditStatus,
    ...props
}) {
    const [sernosSequence, setSernosSequence] = useState({});
    const [prevSernosSequence, setPrevSernosSequence] = useState(null);

    function handleSaveClick() {
        updateSernosSequence(sequenceName, sernosSequence);
        setEditStatus('view');
    }

    function handleCancelClick() {
        setSernosSequence(sernosSequence);
        setEditStatus('view');
    }

    function handleAddClick() {
        addSernosSequence(sernosSequence);
        setEditStatus('view');
    }

    function handleBackClick() {
        history.push('/products/maint/sernos-sequences');
    }

    function creating() {
        return editStatus === 'create';
    }

    function editing() {
        return editStatus === 'edit';
    }

    function sequenceNameInvalid() {
        return !sernosSequence.sequenceName;
    }

    function descriptionInvalid() {
        return !sernosSequence.description;
    }

    function nextSerialNumberInvalid() {
        return typeof sernosSequence.nextSerialNuber !== 'number';
    }

    function inputInvalid() {
        return sequenceNameInvalid() || descriptionInvalid() || nextSerialNumberInvalid();
    }

    function handleFieldChange(propertyName, newValue) {
        setEditStatus('edit');
        setSernosSequence({ ...sernosSequence, [propertyName]: newValue });
    }

    function updateSernosSequenceFromProps() {
        if (props.sernosSequence !== prevSernosSequence) {
            setSernosSequence(props.sernosSequence);
            setPrevSernosSequence(props.sernosSequence);
        }
    }

    return (
        <Page>
            {!creating() && updateSernosSequenceFromProps()}
            <Grid container spacing={24}>
                <Grid item xs={12}>
                    {createImageBitmap() ? (
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
            </Grid>
        </Page>
    );
}

export default SernosSequence;
