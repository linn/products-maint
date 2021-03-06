﻿import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import CartonType from '../../components/CartonType';
import cartonTypeActions from '../../actions/cartonTypeActions';
import cartonTypeSelectors from '../../selectors/cartonTypeSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = (state, { match }) => ({
    item: cartonTypeSelectors.getItem(state),
    itemId: match.params.cartonTypeId,
    editStatus: cartonTypeSelectors.getEditStatus(state),
    loading: cartonTypeSelectors.getLoading(state),
    snackbarVisible: cartonTypeSelectors.getSnackbarVisible(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.cartonType.item)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(cartonTypeActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateCartonType: cartonTypeActions.update,
    setEditStatus: cartonTypeActions.setEditStatus,
    setSnackbarVisible: cartonTypeActions.setSnackbarVisible
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(CartonType));
