export const getSections = state => {
    const { menu } = state;
    if (!menu.data) return null;
    return menu.data.sections;
};

export const getMyStuff = state => {
    const { menu } = state;
    if (!menu.data) return null;
    return menu.data.myStuff;
};

export const getMenuLoading = state => {
    const menu = state;
    return menu ? menu.loading : false;
};
