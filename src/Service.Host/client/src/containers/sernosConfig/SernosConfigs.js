import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import SernosConfigs from '../../components/SernosConfigs';
import sernosConfigsActions from '../../actions/sernosConfigsActions';
import sernosConfigsSelectors from '../../selectors/sernosConfigsSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    sernosConfigs: sernosConfigsSelectors.getItems(state),
    loading: sernosConfigsSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.sernosConfigs.item)
});

const initialise = () => dispatch => {
    dispatch(sernosConfigsActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(SernosConfigs));
