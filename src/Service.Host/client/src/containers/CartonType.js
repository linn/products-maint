import { connect } from 'react-redux';
import CartonType from '../components/CartonType';
import initialiseOnMount from './common/initialiseOnMount';
import { fetchCartonType, updateCartonType } from '../actions/cartonTypes';

const mapStateToProps = ({ cartonType }, { match }) => ({
    cartonType: cartonType.item,
    cartonTypeId: match.params.cartonTypeId,
    loading: cartonType.loading
});

const initialise = ({ cartonTypeId }) => dispatch => {
    dispatch(fetchCartonType(cartonTypeId));
};

const mapDispatchToProps = {
    initialise,
    updateCartonType
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(CartonType));