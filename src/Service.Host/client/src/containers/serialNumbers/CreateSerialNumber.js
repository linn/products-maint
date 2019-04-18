import { connect } from 'react-redux';
import initialiseOnMount from '../common/initialiseOnMount';
import serialNumberActions from '../../actions/serialNumberActions';
import SerialNumber from '../../components/SerialNumber';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import serialNumberSelectors from '../../selectors/serialNumberSelectors';

const mapStateToProps = state => ({
    item: serialNumberSelectors.getItem(state),
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state),
    loading: serialNumberSelectors.getLoading(state),
    snackbarVisible: serialNumberSelectors.getSnackbarVisible(state)
});

const initialise = () => dispatch => {
    dispatch(serialNumberActions.setEditStatus('create'));
    dispatch(serialNumberActions.create());
};

const mapDispatchToProps = {
    initialise,
    addItem: serialNumberActions.add,
    setEditStatus: serialNumberActions.setEditStatus,
    setSnackbarVisible: serialNumberActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SerialNumber));
