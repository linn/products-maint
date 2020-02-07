import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import SernosConfig from '../../components/SernosConfig';
import sernosConfigActions from '../../actions/sernosConfigActions';
import sernosConfigSelectors from '../../selectors/sernosConfigSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = (state, { match }) => ({
    item: sernosConfigSelectors.getItem(state),
    itemId: match.params.sernosConfigId,
    editStatus: sernosConfigSelectors.getEditStatus(state),
    loading: sernosConfigSelectors.getLoading(state),
    snackbarVisible: sernosConfigSelectors.getSnackbarVisible(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.sernosConfig.item)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(sernosConfigActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateSernosConfig: sernosConfigActions.update,
    setEditStatus: sernosConfigActions.setEditStatus,
    resetSernosConfig: sernosConfigActions.reset,
    setSnackbarVisible: sernosConfigActions.setSnackbarVisible
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SernosConfig));
