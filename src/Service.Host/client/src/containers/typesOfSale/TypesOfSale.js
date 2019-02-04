import { connect } from 'react-redux';
import TypesOfSale from '../../components/TypesOfSale';
import initialiseOnMount from '../common/initialiseOnMount';
import typesOfSaleActions from '../../actions/typesOfSaleActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import typesOfSaleSelectors from '../../selectors/typesOfSaleSelectors';

const mapStateToProps = (state) => ({
    typesOfSale: typesOfSaleSelectors.getItems(state),
    loading: typesOfSaleSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const initialise = () => dispatch => {
    dispatch(typesOfSaleActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(TypesOfSale));
