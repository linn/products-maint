import { connect } from 'react-redux';
import typeOfSaleActions from '../../actions/typeOfSaleActions';
import TypeOfSale from '../../components/TypeOfSale';
import { getSingleErrorMessage } from '../../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    typeOfSale: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const mapDispatchToProps = {
    addTypeOfSale: typeOfSaleActions.add,
    resetTypeOfSale: typeOfSaleActions.reset
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(TypeOfSale);