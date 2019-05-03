import { connect } from 'react-redux';
import initialiseOnMount from '../common/initialiseOnMount';
import typeOfSaleActions from '../../actions/typeOfSaleActions';
import TypeOfSale from '../../components/typesOfSale/TypeOfSale';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import typeOfSaleSelectors from '../../selectors/typeOfSaleSelectors';

const mapStateToProps = state => ({
    item: typeOfSaleSelectors.getItem(state),
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    loading: typeOfSaleSelectors.getLoading(state),
    snackbarVisible: typeOfSaleSelectors.getSnackbarVisible(state)
});

const initialise = () => dispatch => {
    dispatch(typeOfSaleActions.setEditStatus('create'));
    dispatch(typeOfSaleActions.create());
};

const mapDispatchToProps = {
    initialise,
    addItem: typeOfSaleActions.add,
    setEditStatus: typeOfSaleActions.setEditStatus,
    setSnackbarVisible: typeOfSaleActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(TypeOfSale));
