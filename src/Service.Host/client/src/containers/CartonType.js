import { connect } from 'react-redux';
import CartonType from '../components/CartonType';
import initialiseOnMount from './common/initialiseOnMount';
import { fetchCartonType } from '../actions/cartonTypes';

const mapStateToProps = ({ cartonType }, { match }) => ({
    cartonType: cartonType.item,
    cartonTypeId: match.params.cartonTypeId,
    loading: cartonType.loading
});

const initialise = ({ cartonTypeId }) => dispatch => {
    dispatch(fetchCartonType(cartonTypeId));
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(CartonType));