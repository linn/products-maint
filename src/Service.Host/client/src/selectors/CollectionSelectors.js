export default function CollectionSelectors (itemType, idField = 'id') {
    this.getItems = (state) => {
        const storeItems = state[itemType];
        if (!storeItems) {
            return [];
        }

        return storeItems.items ? storeItems.items : [];
    }

    this.getItem = (state, id) => {
        const storeItems = state[itemType];
        if (!storeItems || !storeItems.items) {
            return null;
        }

        return storeItems.items.find(a => a[idField] === id);
    }

    this.getLoading = (state) => {
        const storeItems = state[itemType];
        if (!storeItems) {
            return null;
        }

        return storeItems.loading;
    }
}
