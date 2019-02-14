export const getMenuData = state => {
    const { menu } = state;
    return menu.data || null;
};

export const getMenuLoading = state => {
    const menu = getMenuData(state);
    return menu ? menu.loading : false;
};

export const getMenuSection = (state, sectionId) => {
    const menu = getMenuData(state);
    if (menu) {
        const section = menu.filter(x => x.id === sectionId);
        const { columns } = section[0];
        const categoriesListArray = [];

        columns.forEach(column => {
            categoriesListArray.push(column.categories);
        });

        const lists = [];

        categoriesListArray.forEach(categoriesList => {
            lists.push(categoriesList);
        });

        const data = [];
        lists.forEach(list => {
            list.forEach(item => {
                data.push(item);
            });
        });

        return data;
    }
    return [];
};
