import { connect } from 'react-redux';
import CartonType from '../components/CartonType';
import initialiseOnMount from './common/initialiseOnMount';
import { fetchCartonType, updateCartonType, resetCartonType } from '../actions/cartonTypes';

const mapStateToProps = ({ cartonType, fetchError }, { match }) => ({
    cartonType: cartonType.item,
    cartonTypeId: match.params.cartonTypeId,
    editStatus: cartonType.editStatus ? cartonType.editStatus : 'view',
    loading: cartonType.loading,
    fetchError
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