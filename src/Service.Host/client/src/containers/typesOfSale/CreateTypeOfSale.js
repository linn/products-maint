import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import initialiseOnMount from '../common/initialiseOnMount';
import typeOfSaleActions from '../../actions/typeOfSaleActions';
import TypeOfSale from '../../components/typesOfSale/TypeOfSale';
import typeOfSaleSelectors from '../../selectors/typeOfSaleSelectors';

const mapStateToProps = state => ({
    item: typeOfSaleSelectors.getItem(state),
    editStatus: 'create',
    errorMessage: fetchErrorSelectors(state),
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
