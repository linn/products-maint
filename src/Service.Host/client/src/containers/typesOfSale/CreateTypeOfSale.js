import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import initialiseOnMount from '../common/initialiseOnMount';
import typeOfSaleActions from '../../actions/typeOfSaleActions';
import TypeOfSale from '../../components/typesOfSale/TypeOfSale';
import typeOfSaleSelectors from '../../selectors/typeOfSaleSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    errorMessage: getItemErrorDetailMessage(state, itemTypes.typeOfSale.item),
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

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(TypeOfSale));
