import { connect } from 'react-redux';
import sernosConfigActions from '../../actions/sernosConfigActions';
import SernosConfig from '../../components/SernosConfig';
import { getSingleErrorMessage } from '../../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    sernosConfig: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const mapDispatchToProps = {
    addSernosConfig: sernosConfigActions.add,
    resetSernosConfig: sernosConfigActions.reset
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SernosConfig);