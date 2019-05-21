import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import tariffActions from '../../actions/tariff';
import Tariff from '../../components/tariffs/Tariff';
import tariffSelectors from '../../selectors/tariffSelectors';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    loading: tariffSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state),
    snackbarVisible: tariffSelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    addTariff: tariffActions.add,
    setSnackBarVisible: tariffActions.setSnackbarVisible,
    setEditStatus: tariffActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Tariff);
