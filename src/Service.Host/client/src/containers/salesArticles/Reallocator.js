import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import Reallocator from '../../components/salesArticles/Reallocator';
import salesArticleReallocateActions from '../../actions/salesArticlesReallocate';
import salesArticlesReallocateSelectors from '../../selectors/salesArticlesReallocateSelectors';
import tariffsActions from '../../actions/tariffs';
import tariffsSelectors from '../../selectors/tariffsSelectors';
import oldTariffsActions from '../../actions/oldTariffs';
import oldTariffsSelectors from '../../selectors/oldTariffsSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    loading: salesArticlesReallocateSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.salesArticlesReallocate.item),
    tariffSearchLoading: tariffsSelectors.getSearchLoading(state),
    tariffSearchResults: tariffsSelectors
        .getSearchItems(state)
        .map(s => ({ ...s, id: s.id, name: s.tariffCode, description: s.description })),
    snackbarVisible: salesArticlesReallocateSelectors.getSnackbarVisible(state),
    tariffSearchErrorMessage: getItemErrorDetailMessage(state, itemTypes.tariffs.item),
    oldTariffSearchLoading: oldTariffsSelectors.getSearchLoading(state),
    oldTariffSearchResults: oldTariffsSelectors
        .getSearchItems(state)
        .map(s => ({ ...s, id: s.id, name: s.tariffCode, description: s.description })),
    oldTariffSearchErrorMessage: getItemErrorDetailMessage(state, itemTypes.oldTariffs.item),
    item: salesArticlesReallocateSelectors.getItem(state)
});

const initialise = () => dispatch => {
    dispatch(salesArticleReallocateActions.fetch());
};

const mapDispatchToProps = {
    initialise,
    reallocate: salesArticleReallocateActions.add,
    resetSalesArticle: salesArticleReallocateActions.reset,
    setEditStatus: salesArticleReallocateActions.setEditStatus,
    setSnackbarVisible: salesArticleReallocateActions.setSnackbarVisible,
    searchForTariff: tariffsActions.search,
    clearTariffSearch: tariffsActions.clearSearch,
    searchForOldTariff: oldTariffsActions.search,
    clearOldTariffSearch: oldTariffsActions.clearSearch
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Reallocator));
