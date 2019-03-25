﻿import ItemType from './ItemType';

export const salesArticleCoreTypes = new ItemType(
    'salesArticleCoreTypes',
    'SALES_ARTICLE_CORE_TYPES',
    '/products/reports/sales-article-core-types'
);

export const cartonDetailsReport = new ItemType(
    'cartonDetailsReport',
    'CARTON_DETAILS',
    '/products/reports/carton-details'
);

export const eanCodesReport = new ItemType(
    'eanCodesReport',
    'EAN_CODE',
    `/products/reports/sales-article-ean-codes`
);
