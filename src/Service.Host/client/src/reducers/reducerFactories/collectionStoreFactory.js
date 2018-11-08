import { getSelfHref } from '../../helpers/utilities';

export default function (itemRoot, actionTypes, defaultState = { loading: false, items: [] }) {
    const makeItem = (item) => ({ ...item, href: getSelfHref(item) });

    const getItems = (items) => {
        if (items) {
            return items.map((i) => (makeItem(i)));
        }

        return items;
    };

    return (state = defaultState, action) => {
        switch (action.type) {
        case actionTypes[`REQUEST_${itemRoot}`]:
            return {
                ...state,
                loading: true
            }
        case actionTypes[`RECEIVE_${itemRoot}`]:
            return {
                ...state,
                loading: false,
                items: getItems(action.payload.data)
            }
        }

        return state;
    }
}
