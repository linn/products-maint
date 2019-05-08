import * as itemTypes from '../itemTypes';
import * as reportTypes from '../reportTypes';

const makeActionTypes = (entityType, makeAll = true) => {
    const types = {};
    types[`REQUEST_${entityType}`] = `REQUEST_${entityType}`;
    types[`RECEIVE_${entityType}`] = `RECEIVE_${entityType}`;
    types[`REQUEST_SEARCH_${entityType}`] = `REQUEST_SEARCH_${entityType}`;
    types[`RECEIVE_SEARCH_${entityType}`] = `RECEIVE_SEARCH_${entityType}`;
    types[`CLEAR_SEARCH_${entityType}`] = `CLEAR_SEARCH_${entityType}`;

    if (makeAll) {
        types[`REQUEST_ADD_${entityType}`] = `REQUEST_ADD_${entityType}`;
        types[`REQUEST_CREATE_${entityType}`] = `REQUEST_CREATE_${entityType}`;
        types[`REQUEST_UPDATE_${entityType}`] = `REQUEST_UPDATE_${entityType}`;
        types[`RECEIVE_UPDATED_${entityType}`] = `RECEIVE_UPDATED_${entityType}`;
        types[`RESET_${entityType}`] = `RESET_${entityType}`;
        types[`RECEIVE_NEW_${entityType}`] = `RECEIVE_NEW_${entityType}`;
        types[`SET_${entityType}_EDIT_STATUS`] = `SET_${entityType}_EDIT_STATUS`;
        types[`SHOW_${entityType}_SNACKBAR`] = `SHOW_${entityType}_SNACKBAR`;
        types[`HIDE_${entityType}_SNACKBAR`] = `HIDE_${entityType}_SNACKBAR`;
        types.FETCH_ERROR = 'FETCH_ERROR';
    }

    return types;
};

const makeReportActionTypes = entityType => {
    const types = {};
    types[`REQUEST_${entityType}_REPORT`] = `REQUEST_${entityType}_REPORT`;
    types[`RECEIVE_${entityType}_REPORT`] = `RECEIVE_${entityType}_REPORT`;

    return types;
};

export const FETCH_ERROR = 'FETCH_ERROR';

export const saCoreTypeReportActionTypes = makeReportActionTypes(
    reportTypes.salesArticleCoreTypes.actionType
);
export const cartonDetailsReportActionTypes = makeReportActionTypes(
    reportTypes.cartonDetailsReport.actionType
);
export const eanCodesReportTypes = makeReportActionTypes(reportTypes.eanCodesReport.actionType);
export const productRangesReportActionTypes = makeReportActionTypes(
    reportTypes.productRangesReport.actionType
);
export const salesProductsByProductRangeReportActionTypes = makeReportActionTypes(
    reportTypes.salesProductsByProductRangeReport.actionType
);

export const sernosUsedOnInvoiceReportActionTypes = makeReportActionTypes(
    reportTypes.sernosUsedOnInvoiceReport.actionType
);

export const REQUEST_STOCK_TRIGGER_LEVELS_REPORT = 'REQUEST_STOCK_TRIGGER_LEVELS_REPORT';
export const RECEIVE_STOCK_TRIGGER_LEVELS_REPORT = 'RECEIVE_STOCK_TRIGGER_LEVELS_REPORT';

export const REQUEST_SA_HOLD_STORIES_REPORT = 'REQUEST_SA_HOLD_STORIES_REPORT';
export const RECEIVE_SA_HOLD_STORIES_REPORT = 'RECEIVE_SA_HOLD_STORIES_REPORT';

export const REQUEST_PRODUCTS_ON_HOLD_REPORT = 'REQUEST_PRODUCTS_ON_HOLD_REPORT';
export const RECEIVE_PRODUCTS_ON_HOLD_REPORT = 'RECEIVE_PRODUCTS_ON_HOLD_REPORT';

export const REQUEST_MENU = 'REQUEST_MENU';
export const RECEIVE_MENU = 'RECEIVE_MENU';

export const cartonTypeActionTypes = makeActionTypes(itemTypes.cartonType.actionType);

export const sernosConfigActionTypes = makeActionTypes(itemTypes.sernosConfig.actionType);
export const sernosConfigsActionTypes = makeActionTypes(itemTypes.sernosConfigs.actionType, false);

export const sernosSequenceActionTypes = makeActionTypes(itemTypes.sernosSequence.actionType);
export const sernosSequencesActionTypes = makeActionTypes(
    itemTypes.sernosSequences.actionType,
    false
);

export const saCoreTypeActionTypes = makeActionTypes(itemTypes.saCoreType.actionType);
export const saCoreTypesActionTypes = makeActionTypes(itemTypes.saCoreTypes.actionType, false);

export const salesArticleActionTypes = makeActionTypes(itemTypes.salesArticle.actionType);
export const salesArticlesActionTypes = makeActionTypes(itemTypes.salesArticles.actionType, false);

export const rootProductActionTypes = makeActionTypes(itemTypes.rootProduct.actionType);
export const rootProductsActionTypes = makeActionTypes(itemTypes.rootProducts.actionType, true);

export const tariffActionTypes = makeActionTypes(itemTypes.tariff.actionType);
export const tariffsActionTypes = makeActionTypes(itemTypes.tariffs.actionType, false);

export const typeOfSaleActionTypes = makeActionTypes(itemTypes.typeOfSale.actionType);
export const typesOfSaleActionTypes = makeActionTypes(itemTypes.typesOfSale.actionType, false);

export const saHoldStoryActionTypes = makeActionTypes(itemTypes.saHoldStory.actionType, true);

export const vatCodeActionTypes = makeActionTypes(itemTypes.vatCode.actionType);
export const vatCodesActionTypes = makeActionTypes(itemTypes.vatCodes.actionType, false);

export const productRangeActionTypes = makeActionTypes(itemTypes.productRange.actionType);
export const productRangesActionTypes = makeActionTypes(itemTypes.productRanges.actionType, false);

export const serialNumberActionTypes = makeActionTypes(itemTypes.serialNumber.actionType);
export const serialNumbersActionTypes = makeActionTypes(itemTypes.serialNumbers.actionType, false);

export const sernosNoteActionTypes = makeActionTypes(itemTypes.sernosNote.actionType);
export const sernosNotesActionTypes = makeActionTypes(itemTypes.sernosNotes.actionType, false);

export const salesPackageActionTypes = makeActionTypes(itemTypes.salesPackage.actionType);
export const salesPackagesActionTypes = makeActionTypes(itemTypes.salesPackages.actionType, false);

export const salesArticleCompositeDiscountActionTypes = makeActionTypes(
    itemTypes.salesArticleCompositeDiscount.actionType
);

export const serialNumberTransactionActionTypes = makeActionTypes(
    itemTypes.serialNumberTransaction.actionType
);
export const serialNumberTransactionsActionTypes = makeActionTypes(
    itemTypes.serialNumberTransactions.actionType,
    false
);
