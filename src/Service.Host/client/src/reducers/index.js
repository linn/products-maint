import { combineReducers } from 'redux';
import { routerReducer as router } from 'react-router-redux';
import { reducer as oidc } from 'redux-oidc';
import eanCodesReport from './eanCodesReport';
import cartonDetailsReport from './cartonDetailsReport';
import productRangesReport from './productRangesReport';
import salesProductsByProductRangeReport from './salesProductsByProductRangeReport';
import cartonType from './cartonType';

const rootReducer = combineReducers({
    oidc,
    eanCodesReport,
    cartonDetailsReport,
    router,
    productRangesReport,
    salesProductsByProductRangeReport,
    cartonType
});

export default rootReducer;