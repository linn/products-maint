export const getTariffs = ({ tariffs }) => {
    if (!tariffs) {
        return null;
    }

    return tariffs.items;
}

export const getTariffsLoading = ({ tariffs }) => {
    if (!tariffs) {
        return null;
    }

    return tariffs.loading;
}