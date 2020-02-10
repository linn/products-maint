import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import VatCodes from '../../components/vatCodes/VatCodes';
import vatCodesActions from '../../actions/vatCodesActions';
import vatCodesSelectors from '../../selectors/vatCodesSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    vatCodes: vatCodesSelectors.getItems(state),
    loading: vatCodesSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.vatCodes.item)
});

const initialise = () => dispatch => {
    dispatch(vatCodesActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(VatCodes));
