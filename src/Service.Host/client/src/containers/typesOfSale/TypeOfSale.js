import { connect } from 'react-redux';
import TypeOfSale from '../../components/TypeOfSale';
import initialiseOnMount from '../common/initialiseOnMount';
import typeOfSaleActions from '../../actions/typeOfSaleActions';
import { getSingleErrorMessage } from '../../selectors/fetchErrorSelectors';
import typeOfSaleSelectors from '../../selectors/typeOfSaleSelectors';

const mapStateToProps = (state, { match }) => ({
    typeOfSale: typeOfSaleSelectors.getItem(state),
    typeOfSaleId: match.params.typeOfSaleId,
    editStatus: typeOfSaleSelectors.getEditStatus(state), 
    loading: typeOfSaleSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ typeOfSaleId }) => dispatch => {
    dispatch(typeOfSaleActions.fetch(typeOfSaleId));
};

const mapDispatchToProps = {
    initialise,
    updateTypeOfSale: typeOfSaleActions.update,
    resetTypeOfSale: typeOfSaleActions.reset
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(TypeOfSale));