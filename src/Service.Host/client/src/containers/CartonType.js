import { connect } from 'react-redux';
import CartonType from '../components/CartonType';
import initialiseOnMount from './common/initialiseOnMount';
import { fetchCartonType, updateCartonType, resetCartonType } from '../actions/cartonTypes';
import { getSingleErrorMessage } from '../selectors/fetchErrorSelectors';

const mapStateToProps = (state, { match }) => ({
    cartonType: state.cartonType.item,
    cartonTypeId: match.params.cartonTypeId,
    editStatus: state.cartonType.editStatus ? state.cartonType.editStatus : 'view',
    loading: state.cartonType.loading,
    errorMessage: getSingleErrorMessage(state)
});

const initialise = ({ cartonTypeId }) => dispatch => {
    dispatch(fetchCartonType(cartonTypeId));
};

const mapDispatchToProps = {
    initialise,
    updateCartonType,
    resetCartonType
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(CartonType));