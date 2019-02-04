export const getTariffs = ({ searchTariffs }) => {
    if (!searchTariffs) {
        return null;
    }

    return searchTariffs.items;
};

export const getTariffsLoading = ({ searchTariffs }) => {
    if (!searchTariffs) {
        return null;
    }

    return searchTariffs.loading;
};

export const getTariff = ({ tariff }) => {
    if (!tariff) {
        return null;
    }

    return tariff.item;
};

export const getTariffLoading = ({ tariff }) => {
    if (!tariff) {
        return null;
    }

    return tariff.loading;
};