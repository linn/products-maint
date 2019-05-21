import * as itemTypes from '../itemTypes';

export default new function serialNumberTransaction() {
    const { item } = itemTypes.serialNumberTransaction;

    this.getItem = state => {
        const storeItem = state[item];
        if (!storeItem) {
            return null;
        }

        return storeItem.item ? storeItem.item : null;
    };

    this.getSernosTransCodes = state => {
        const storeItem = state[item];
        if (!storeItem) {
            return null;
        }

        return storeItem.sernosTransCodes ? storeItem.sernosTransCodes : null;
    };

    this.getLoading = state => {
        const storeItem = state[item];
        if (!storeItem) {
            return null;
        }

        return storeItem.loading;
    };

    this.getEditStatus = state => {
        const storeItem = state[item];
        if (!storeItem) {
            return null;
        }

        return storeItem.editStatus ? storeItem.editStatus : 'view';
    };

    this.getSnackbarVisible = state => {
        const storeItem = state[item];
        if (!storeItem) {
            return null;
        }

        return storeItem.snackbarVisible;
    };
}();
