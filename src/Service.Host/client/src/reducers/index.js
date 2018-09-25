import { combineReducers } from 'redux';
import { routerReducer as router } from 'react-router-redux';
import { reducer as oidc } from 'redux-oidc';
import eanCodesReport from './eanCodesReport';

const rootReducer = combineReducers({
    oidc,
    eanCodesReport,
    router
});

export default rootReducer;