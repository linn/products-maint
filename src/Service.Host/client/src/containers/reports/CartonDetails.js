import { connect } from 'react-redux';
import CartonDetails from '../../components/reports/CartonDetails';
import initialiseOnMount from '../common/initialiseOnMount';
import { fetchCartonDetailsReport } from '../../actions/cartonDetailsReport';
import config from '../../config';

const mapStateToProps = (state, ownProps) => ({
    reportData: state.cartonDetailsReport.results.data,
    loading: state.cartonDetailsReport.results.loading,
    config 
});

const initialise = () => dispatch => {
    dispatch(fetchCartonDetailsReport());
};

const mapDispatchToProps = {
    initialise
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(CartonDetails));