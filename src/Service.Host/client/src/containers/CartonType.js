import { connect } from 'react-redux';
import CartonType from '../components/CartonType';
import initialiseOnMount from './common/initialiseOnMount';
import { fetchCartonType, updateCartonType, resetCartonType } from '../actions/cartonTypes';
import { getSingleErrorMessage } from '../selectors/fetchErrorSelectors';
import { getCartonType, getCartonLoading, getCartonEditStatus } from '../selectors/cartonTypeSelectors';

const mapStateToProps = (state, { match }) => ({
    cartonType: getCartonType(state),
    cartonTypeId: match.params.cartonTypeId,
    editStatus: getCartonEditStatus(state), 
    loading: getCartonLoading(state),
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