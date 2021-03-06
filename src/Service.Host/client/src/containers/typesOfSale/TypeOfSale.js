import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import TypeOfSale from '../../components/typesOfSale/TypeOfSale';
import initialiseOnMount from '../common/initialiseOnMount';
import typeOfSaleActions from '../../actions/typeOfSaleActions';
import typeOfSaleSelectors from '../../selectors/typeOfSaleSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = (state, { match }) => ({
    item: typeOfSaleSelectors.getItem(state),
    itemId: match.params.typeOfSaleId,
    editStatus: typeOfSaleSelectors.getEditStatus(state),
    loading: typeOfSaleSelectors.getLoading(state),
    snackbarVisible: typeOfSaleSelectors.getSnackbarVisible(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.typeOfSale.item)
});

const initialise = ({ itemId }) => dispatch => {
    dispatch(typeOfSaleActions.fetch(itemId));
};

const mapDispatchToProps = {
    initialise,
    updateItem: typeOfSaleActions.update,
    setEditStatus: typeOfSaleActions.setEditStatus,
    setSnackbarVisible: typeOfSaleActions.setSnackbarVisible
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(TypeOfSale));
