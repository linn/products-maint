import { connect } from 'react-redux';
import { getItemErrorDetailMessage } from '@linn-it/linn-form-components-library';
import tariffActions from '../../actions/tariff';
import Tariff from '../../components/tariffs/Tariff';
import tariffSelectors from '../../selectors/tariffSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    item: {},
    editStatus: 'create',
    loading: tariffSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.tariff.item),
    snackbarVisible: tariffSelectors.getSnackbarVisible(state)
});

const mapDispatchToProps = {
    addTariff: tariffActions.add,
    setSnackBarVisible: tariffActions.setSnackbarVisible,
    setEditStatus: tariffActions.setEditStatus
};

export default connect(mapStateToProps, mapDispatchToProps)(Tariff);
