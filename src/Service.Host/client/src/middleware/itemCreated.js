﻿import { getSelfHref } from '@linn-it/linn-form-components-library';
import history from '../history';

export default () => next => action => {
    const result = next(action);
    if (action.type !== 'RECEIVE_NEW_SERNOS_NOTE' && action.type.startsWith('RECEIVE_NEW_')) {
        history.push(getSelfHref(action.payload.data));
    }
    return result;
};
