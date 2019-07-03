﻿import { reducers as sharedLibraryReducers } from '@linn-it/linn-form-components-library';
import { combineReducers } from 'redux';
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
import serialNumber from './serialNumber';
import serialNumbers from './serialNumbers';
import sernosNote from './sernosNote';
import sernosNotes from './sernosNotes';
import sernosConfig from './sernosConfig';
import sernosConfigs from './sernosConfigs';
import serialNumberTransaction from './serialNumberTransaction';
import serialNumberTransactions from './serialNumberTransactions';
import serialNumberTransactionsPaged from './serialNumberTransactionsPaged';
import sernosSequence from './sernosSequence';
import sernosSequences from './sernosSequences';
import saCoreTypes from './saCoreTypes';
import saCoreType from './saCoreType';
import typesOfSale from './typesOfSale';
import typeOfSale from './typeOfSale';
import salesArticle from './salesArticle';
import salesArticles from './salesArticles';
import saHoldStory from './saHoldStory';
import vatCode from './vatCode';
import vatCodes from './vatCodes';
import productRange from './productRange';
import productRanges from './productRanges';
import productsOnHoldReport from './productsOnHoldReport';
import salesArticleCoreTypes from './salesArticleCoreTypes/index';
import salesPackage from './salesPackage';
import salesPackages from './salesPackages';
import rootProducts from './rootProducts/rootProducts';
import rootProduct from './rootProducts/rootProduct';
import salesArticleCompositeDiscount from './salesArticleCompositeDiscount';
import salesArticleSernosDetails from './salesArticleSernosDetails';
import sernosUsedOnInvoiceReport from './sernosUsedOnInvoiceReport';
import serialNumberTransCounts from './serialNumberTransCounts';

const rootReducer = combineReducers({
    oidc,
    eanCodesReport,
    cartonDetailsReport,
    tariff,
    tariffs,
    productRangesReport,
    salesProductsByProductRangeReport,
    cartonType,
    serialNumber,
    serialNumbers,
    sernosNote,
    sernosNotes,
    sernosConfig,
    sernosConfigs,
    serialNumberTransaction,
    serialNumberTransactions,
    serialNumberTransactionsPaged,
    sernosSequence,
    sernosSequences,
    saCoreTypes,
    saCoreType,
    salesArticle,
    salesArticles,
    typesOfSale,
    typeOfSale,
    stockTriggerLevelsReport,
    saHoldStoriesReport,
    saHoldStory,
    salesArticleCoreTypes,
    vatCode,
    vatCodes,
    productRange,
    productRanges,
    productsOnHoldReport,
    salesPackage,
    salesPackages,
    salesArticleCompositeDiscount,
    salesArticleSernosDetails,
    rootProduct,
    rootProducts,
    sernosUsedOnInvoiceReport,
    serialNumberTransCounts,
    ...sharedLibraryReducers
});

export default rootReducer;
