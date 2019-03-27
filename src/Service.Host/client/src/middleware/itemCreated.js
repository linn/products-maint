import { getSelfHref } from '../helpers/utilities';
import history from '../history';

export default () => next => action => {
    const result = next(action);
    if (action.type.startsWith('RECEIVE_NEW')) {
        history.push(getSelfHref(action.payload.data));
    }
    return result;
};
