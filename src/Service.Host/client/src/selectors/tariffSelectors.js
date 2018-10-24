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

export const getTariff = ({ tariff }) => {
    if (!tariff) {
        return null;
    }

    return tariff.item;
}

export const getTariffLoading = ({ tariff }) => {
    if (!tariff) {
        return null;
    }

    return tariff.loading;
}