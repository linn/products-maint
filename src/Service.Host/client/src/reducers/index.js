import { combineReducers } from 'redux';
import { reducer as oidc } from 'redux-oidc';
import eanCodesReport from './eanCodesReport';
import cartonDetailsReport from './cartonDetailsReport';
import tariff from './tariff';
import searchTariffs from './searchTariffs';
import productRangesReport from './productRangesReport';
import salesProductsByProductRangeReport from './salesProductsByProductRangeReport';
import cartonType from './cartonType';
import sernosConfig from './sernosConfig';
import sernosConfigs from './sernosConfigs';
import fetchError from './fetchError';
import saCoreTypes from './saCoreTypes';
import saCoreType from './saCoreType';
import typesOfSale from './typesOfSale';
import typeOfSale from './typeOfSale';

const rootReducer = combineReducers({
    oidc,
    eanCodesReport,
    cartonDetailsReport,
    tariff,
    searchTariffs,
    productRangesReport,
    salesProductsByProductRangeReport,
    cartonType,
    sernosConfig,
    sernosConfigs,
    saCoreTypes,
    saCoreType,
    typesOfSale,
    typeOfSale,
    fetchError
});

export default rootReducer;