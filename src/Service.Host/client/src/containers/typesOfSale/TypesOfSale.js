import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import TypesOfSale from '../../components/typesOfSale/TypesOfSale';
import initialiseOnMount from '../common/initialiseOnMount';
import typesOfSaleActions from '../../actions/typesOfSaleActions';
import typesOfSaleSelectors from '../../selectors/typesOfSaleSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    typesOfSale: typesOfSaleSelectors.getItems(state),
    loading: typesOfSaleSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.typesOfSale.item)
});

const initialise = () => dispatch => {
    dispatch(typesOfSaleActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(TypesOfSale));
