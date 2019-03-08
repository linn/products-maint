import { connect } from 'react-redux';
import TypeOfSale from '../../components/TypeOfSale';
import initialiseOnMount from '../common/initialiseOnMount';
import typeOfSaleActions from '../../actions/typeOfSaleActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import typeOfSaleSelectors from '../../selectors/typeOfSaleSelectors';

const mapStateToProps = (state, { match }) => ({
    item: typeOfSaleSelectors.getItem(state),
    itemId: match.params.typeOfSaleId,
    editStatus: typeOfSaleSelectors.getEditStatus(state),
    loading: typeOfSaleSelectors.getLoading(state),
    snackbarVisible: typeOfSaleSelectors.getSnackbarVisible(state),
    errorMessage: getSingleErrorMessage(state)
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

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(TypeOfSale));
