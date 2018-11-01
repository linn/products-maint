import { combineReducers } from 'redux';
import { reducer as oidc } from 'redux-oidc';
import eanCodesReport from './eanCodesReport';
import cartonDetailsReport from './cartonDetailsReport';
import productRangesReport from './productRangesReport';
import salesProductsByProductRangeReport from './salesProductsByProductRangeReport';
import cartonType from './cartonType';
import sernosConfig from './sernosConfig';
import fetchError from './fetchError';

const rootReducer = combineReducers({
    oidc,
    eanCodesReport,
    cartonDetailsReport,
    productRangesReport,
    salesProductsByProductRangeReport,
    cartonType,
    sernosConfig,
    fetchError
});

export default rootReducer;