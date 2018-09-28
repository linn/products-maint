import { combineReducers } from 'redux';
import { routerReducer as router } from 'react-router-redux';
import { reducer as oidc } from 'redux-oidc';
import eanCodesReport from './eanCodesReport';
import cartonDetailsReport from './cartonDetailsReport';

const rootReducer = combineReducers({
    oidc,
    eanCodesReport,
    cartonDetailsReport,
    router
});

export default rootReducer;