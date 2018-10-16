export const getCartonType = (state) => {
    const cartonType = state.cartonType;
    if (!cartonType) {
        return null;
    }

    if (cartonType.item) {
        return cartonType.item;
    }

    return null;
}

export const getCartonLoading = (state) => {
    const cartonType = state.cartonType;
    if (!cartonType) {
        return null;
    }

    return cartonType.loading;
}

export const getCartonEditStatus = (state) => {
    const cartonType = state.cartonType;
    if (!cartonType) {
        return null;
    }

    if (!cartonType.editStatus) {
        return 'view';
    }

    return cartonType.editStatus;
}