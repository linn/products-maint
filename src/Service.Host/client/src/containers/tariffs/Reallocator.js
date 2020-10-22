import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import Reallocator from '../../components/tariffs/Reallocator';
import tariffsReallocateActions from '../../actions/tariffsReallocate';
import tariffsReallocateSelectors from '../../selectors/tariffsReallocateSelectors';
import tariffsActions from '../../actions/tariffs';
import tariffsSelectors from '../../selectors/tariffsSelectors';
import oldTariffsActions from '../../actions/oldTariffs';
import oldTariffsSelectors from '../../selectors/oldTariffsSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    loading: tariffsReallocateSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.TariffsReallocate.item),
    tariffSearchLoading: tariffsSelectors.getSearchLoading(state),
    tariffSearchResults: tariffsSelectors
        .getSearchItems(state)
        .map(s => ({ ...s, id: s.id, name: s.tariffCode, description: s.description })),
    snackbarVisible: tariffsReallocateSelectors.getSnackbarVisible(state),
    tariffSearchErrorMessage: getItemErrorDetailMessage(state, itemTypes.tariffs.item),
    oldTariffSearchLoading: oldTariffsSelectors.getSearchLoading(state),
    oldTariffSearchResults: oldTariffsSelectors
        .getSearchItems(state)
        .map(s => ({ ...s, id: s.id, name: s.tariffCode, description: s.description })),
    oldTariffSearchErrorMessage: getItemErrorDetailMessage(state, itemTypes.oldTariffs.item),
    item: tariffsReallocateSelectors.getItem(state)
});

const initialise = () => () => {};

const mapDispatchToProps = {
    initialise,
    reallocate: tariffsReallocateActions.add,
    resetSalesArticle: tariffsReallocateActions.reset,
    setEditStatus: tariffsReallocateActions.setEditStatus,
    setSnackbarVisible: tariffsReallocateActions.setSnackbarVisible,
    searchForTariff: tariffsActions.search,
    clearTariffSearch: tariffsActions.clearSearch,
    searchForOldTariff: oldTariffsActions.search,
    clearOldTariffSearch: oldTariffsActions.clearSearch
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Reallocator));
