import { combineReducers } from 'redux';
import { reducer as oidc } from 'redux-oidc';
import eanCodesReport from './eanCodesReport';
import cartonDetailsReport from './cartonDetailsReport';
import tariff from './tariff';
import tariffs from './tariffs';
import productRangesReport from './productRangesReport';
import stockTriggerLevelsReport from './stockTriggerLevelReports';
import salesProductsByProductRangeReport from './salesProductsByProductRangeReport';
import cartonType from './cartonType';
import sernosConfig from './sernosConfig';
import sernosConfigs from './sernosConfigs';
import fetchError from './fetchError';
import saCoreTypes from './saCoreTypes';
import saCoreType from './saCoreType';
import typesOfSale from './typesOfSale';
import typeOfSale from './typeOfSale';
import salesArticle from './salesArticle';
import salesArticles from './salesArticles';
import menu from './menu';
import vatCode from './vatCode';
import vatCodes from './vatCodes';

const rootReducer = combineReducers({
    oidc,
    eanCodesReport,
    cartonDetailsReport,
    tariff,
    tariffs,
    productRangesReport,
    salesProductsByProductRangeReport,
    cartonType,
    sernosConfig,
    sernosConfigs,
    saCoreTypes,
    saCoreType,
    fetchError,
    salesArticle,
    salesArticles,
    typesOfSale,
    typeOfSale,
    stockTriggerLevelsReport,
    menu,
    vatCode,
    vatCodes,
    stockTriggerLevelsReport
});

export default rootReducer;
