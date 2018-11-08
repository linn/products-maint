﻿import * as itemTypes from '../itemTypes';

const makeActionTypes = (entityType, makeAll = true) => {
    var types = {};
    types[`REQUEST_${entityType}`] = `REQUEST_${entityType}`;
    types[`RECEIVE_${entityType}`] = `RECEIVE_${entityType}`;

    if (makeAll) {
        types[`REQUEST_ADD_${entityType}`] = `REQUEST_ADD_${entityType}`;
        types[`REQUEST_UPDATE_${entityType}`] = `REQUEST_UPDATE_${entityType}`;
        types[`RESET_${entityType}`] = `RESET_${entityType}`;
        types[`RECEIVE_NEW_${entityType}`] = `RECEIVE_NEW_${entityType}`;
    }
    return types;
}

export const FETCH_ERROR = 'FETCH_ERROR';

export const REQUEST_EAN_CODE_REPORT = 'REQUEST_EAN_CODE_REPORT';
export const RECEIVE_EAN_CODE_REPORT = 'RECEIVE_EAN_CODE_REPORT';

export const REQUEST_TARIFF = 'REQUEST_TARIFF';
export const RECEIVE_TARIFF = 'RECEIVE_TARIFF';

export const REQUEST_SEARCH_TARIFFS = 'REQUEST_SEARCH_TARIFFS';
export const RECEIVE_SEARCH_TARIFFS = 'RECEIVE_SEARCH_TARIFFS';
export const REQUEST_ADD_TARIFF = 'REQUEST_ADD_TARIFF';
export const RECEIVE_NEW_TARIFF = 'RECEIVE_NEW_TARIFF';
export const REQUEST_UPDATE_TARIFF = 'REQUEST_UPDATE_TARIFF';

export const REQUEST_CARTON_DETAILS_REPORT = 'REQUEST_CARTON_DETAILS_REPORT';
export const RECEIVE_CARTON_DETAILS_REPORT = 'RECEIVE_CARTON_DETAILS_REPORT';

export const REQUEST_PRODUCT_RANGES_REPORT = 'REQUEST_PRODUCT_RANGES_REPORT';
export const RECEIVE_PRODUCT_RANGES_REPORT = 'RECEIVE_PRODUCT_RANGES_REPORT';
export const REQUEST_SALES_PRODUCTS_BY_RANGE_REPORT = 'REQUEST_SALES_PRODUCTS_BY_RANGE_REPORT';
export const RECEIVE_SALES_PRODUCTS_BY_RANGE_REPORT = 'RECEIVE_SALES_PRODUCTS_BY_RANGE_REPORT';

export const REQUEST_ADD_CARTON_TYPE = 'REQUEST_ADD_CARTON_TYPE';
export const REQUEST_UPDATE_CARTON_TYPE = 'REQUEST_UPDATE_CARTON_TYPE';
export const REQUEST_CARTON_TYPE = 'REQUEST_CARTON_TYPE';
export const RECEIVE_CARTON_TYPE = 'RECEIVE_CARTON_TYPE';
export const RECEIVE_NEW_CARTON_TYPE = 'RECEIVE_NEW_CARTON_TYPE';
export const RESET_CARTON_TYPE = 'RESET_CARTON_TYPE';

export const sernosConfigActionTypes = makeActionTypes(itemTypes.sernosConfig.actionType);
export const sernosConfigsActionTypes = makeActionTypes(itemTypes.sernosConfigs.actionType, false);
