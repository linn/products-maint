import { combineReducers } from 'redux';
import { routerReducer as router } from 'react-router-redux';
import { reducer as oidc } from 'redux-oidc';
import eanCodesReport from './eanCodesReport';
import cartonDetailsReport from './cartonDetailsReport';
import tariff from './tariff';
import tariffs from './tariffs';

const rootReducer = combineReducers({
    oidc,
    eanCodesReport,
    cartonDetailsReport,
    tariff,
    tariffs,
    router
});

export default rootReducer;