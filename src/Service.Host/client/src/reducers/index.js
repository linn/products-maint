﻿import { combineReducers } from 'redux';
import { reducer as oidc } from 'redux-oidc';
import eanCodesReport from './eanCodesReport';
import cartonDetailsReport from './cartonDetailsReport';
import tariff from './tariff';
import tariffs from './tariffs';
import productRangesReport from './productRangesReport';
import stockTriggerLevelsReport from './stockTriggerLevelReports';
import salesProductsByProductRangeReport from './salesProductsByProductRangeReport';
import saHoldStoriesReport from './saHoldStoriesReport';
import cartonType from './cartonType';
import sernosConfig from './sernosConfig';
import sernosConfigs from './sernosConfigs';
import sernosSequence from './sernosSequence';
import sernosSequences from './sernosSequences';
import fetchError from './fetchError';
import saCoreTypes from './saCoreTypes';
import saCoreType from './saCoreType';
import typesOfSale from './typesOfSale';
import typeOfSale from './typeOfSale';
import salesArticle from './salesArticle';
import salesArticles from './salesArticles';
import saHoldStory from './saHoldStory';
import menu from './menu';
import reportData from './reportData';
import vatCode from './vatCode';
import vatCodes from './vatCodes';
import productRange from './productRange';
import productRanges from './productRanges';

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
    sernosSequence,
    sernosSequences,
    saCoreTypes,
    saCoreType,
    fetchError,
    salesArticle,
    salesArticles,
    typesOfSale,
    typeOfSale,
    stockTriggerLevelsReport,
    saHoldStoriesReport,
    saHoldStory,
    menu,
    reportData,
    vatCode,
    vatCodes,
    productRange,
    productRanges
});

export default rootReducer;
