import { connect } from 'react-redux';
import initialiseOnMount from '../common/initialiseOnMount';
import typeOfSaleActions from '../../actions/typeOfSaleActions';
import TypeOfSale from '../../components/TypeOfSale';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    typeOfSale: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const initialise = () => dispatch => {
    dispatch(typeOfSaleActions.setEditStatus('create'));
};

const mapDispatchToProps = {
    initialise,
    addTypeOfSale: typeOfSaleActions.add,
    setEditStatus: typeOfSaleActions.setEditStatus,
    setSnackbarVisible: typeOfSaleActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(TypeOfSale));
