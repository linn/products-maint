export const getCartonType = state => {
    const { cartonType } = state;
    if (!cartonType) {
        return null;
    }

    return cartonType.item ? cartonType.item : null;
};

export const getCartonLoading = state => {
    const { cartonType } = state;
    if (!cartonType) {
        return null;
    }

    return cartonType.loading;
};

export const getCartonEditStatus = state => {
    const { cartonType } = state;
    if (!cartonType) {
        return null;
    }

    return cartonType.editStatus ? cartonType.editStatus : 'view';
};
