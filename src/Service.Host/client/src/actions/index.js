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

export const REQUEST_REPORT = 'REQUEST_REPORT';
export const RECEIVE_REPORT = 'RECEIVE_REPORT';

export const saCoreTypeReportActionTypes = makeReportActionTypes(
    reportTypes.salesArticleCoreTypes.actionType
);
export const cartonDetailsReportActionTypes = makeReportActionTypes(
    reportTypes.cartonDetailsReport.actionType
);
export const eanCodesReportTypes = makeReportActionTypes(reportTypes.eanCodesReport.actionType);

export const REQUEST_STOCK_TRIGGER_LEVELS_REPORT = 'REQUEST_STOCK_TRIGGER_LEVELS_REPORT';
export const RECEIVE_STOCK_TRIGGER_LEVELS_REPORT = 'RECEIVE_STOCK_TRIGGER_LEVELS_REPORT';

export const REQUEST_STOCK_TRIGGER_LEVELS_REPORT_BY_PART =
    'REQUEST_STOCK_TRIGGER_LEVELS_REPORT_BY_PART';
export const RECEIVE_STOCK_TRIGGER_LEVELS_REPORT_BY_PART =
    'RECEIVE_STOCK_TRIGGER_LEVELS_REPORT_BY_PART';

export const REQUEST_TARIFF = 'REQUEST_TARIFF';
export const RECEIVE_TARIFF = 'RECEIVE_TARIFF';

export const REQUEST_SEARCH_TARIFFS = 'REQUEST_SEARCH_TARIFFS';
export const RECEIVE_SEARCH_TARIFFS = 'RECEIVE_SEARCH_TARIFFS';
export const REQUEST_ADD_TARIFF = 'REQUEST_ADD_TARIFF';
export const RECEIVE_NEW_TARIFF = 'RECEIVE_NEW_TARIFF';
export const REQUEST_UPDATE_TARIFF = 'REQUEST_UPDATE_TARIFF';

export const REQUEST_PRODUCT_RANGES_REPORT = 'REQUEST_PRODUCT_RANGES_REPORT';
export const RECEIVE_PRODUCT_RANGES_REPORT = 'RECEIVE_PRODUCT_RANGES_REPORT';
export const REQUEST_SALES_PRODUCTS_BY_RANGE_REPORT = 'REQUEST_SALES_PRODUCTS_BY_RANGE_REPORT';
export const RECEIVE_SALES_PRODUCTS_BY_RANGE_REPORT = 'RECEIVE_SALES_PRODUCTS_BY_RANGE_REPORT';

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

export const tariffActionTypes = makeActionTypes(itemTypes.tariff.actionType);
export const tariffsActionTypes = makeActionTypes(itemTypes.tariffs.actionType, false);

export const typeOfSaleActionTypes = makeActionTypes(itemTypes.typeOfSale.actionType);
export const typesOfSaleActionTypes = makeActionTypes(itemTypes.typesOfSale.actionType, false);

export const saHoldStoryActionTypes = makeActionTypes(itemTypes.saHoldStory.actionType, false);

export const vatCodeActionTypes = makeActionTypes(itemTypes.vatCode.actionType);
export const vatCodesActionTypes = makeActionTypes(itemTypes.vatCodes.actionType, false);

export const productRangeActionTypes = makeActionTypes(itemTypes.productRange.actionType);
export const productRangesActionTypes = makeActionTypes(itemTypes.productRanges.actionType, false);
