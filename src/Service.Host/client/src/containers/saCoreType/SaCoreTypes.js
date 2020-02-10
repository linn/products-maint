import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import SaCoreTypes from '../../components/SaCoreTypes';
import initialiseOnMount from '../common/initialiseOnMount';
import saCoreTypesActions from '../../actions/saCoreTypesActions';
import saCoreTypesSelectors from '../../selectors/saCoreTypesSelector';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    saCoreTypes: saCoreTypesSelectors.getItems(state),
    loading: saCoreTypesSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.saCoreTypes.item)
});

const initialise = () => dispatch => {
    dispatch(saCoreTypesActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SaCoreTypes));
