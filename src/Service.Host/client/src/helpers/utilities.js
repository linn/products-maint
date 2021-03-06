﻿export const makeNumber = (str, defaultValue = 0) => {
    const result = Number(str);
    return Number.isNaN(result) ? defaultValue : result;
};

export const sortList = list =>
    list.slice().sort((a, b) => {
        if (a < b) {
            return -1;
        }
        if (a > b) {
            return 1;
        }
        return 0;
    });

export const sortEntityList = (list, property) =>
    list.slice().sort((a, b) => {
        if (a[property] < b[property]) {
            return -1;
        }
        if (a[property] > b[property]) {
            return 1;
        }
        return 0;
    });
