import { connect } from 'react-redux';
import {
    getItemErrorDetailMessage,
    initialiseOnMount
} from '@linn-it/linn-form-components-library';
import Reallocator from '../../components/salesArticles/Reallocator';
import tariffsActions from '../../actions/tariffs';
import salesArticleReallocateActions from '../../actions/salesArticlesReallocate';
import salesArticlesReallocateSelectors from '../../selectors/salesArticlesReallocateSelectors';
import tariffsSelectors from '../../selectors/tariffsSelectors';
import * as itemTypes from '../../itemTypes';

const mapStateToProps = state => ({
    loading: salesArticlesReallocateSelectors.getLoading(state),
    errorMessage: getItemErrorDetailMessage(state, itemTypes.salesArticlesReallocate.item),
    tariffSearchLoading: tariffsSelectors.getSearchLoading(state),
    tariffSearchResults: tariffsSelectors
        .getSearchItems(state)
        .map(s => ({ ...s, id: s.tariffCode, name: s.description })),
    snackbarVisible: salesArticlesReallocateSelectors.getSnackbarVisible(state),
    tariffSearchErrorMessage: getItemErrorDetailMessage(state, itemTypes.tariffs.item)
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
    clearTariffSearch: tariffsActions.clearSearch
};

export default connect(mapStateToProps, mapDispatchToProps)(initialiseOnMount(Reallocator));
