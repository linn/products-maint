import { ItemType } from '@linn-it/linn-form-components-library';

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
    '/products/reports/sales-article-ean-codes'
);

export const productRangesReport = new ItemType(
    'productRangesReport',
    'PRODUCT_RANGES',
    '/products/reports/product-ranges'
);

export const salesProductsByProductRangeReport = new ItemType(
    'salesProductsByProductRangeReport',
    'SALES_PRODUCTS_BY_RANGE',
    '/products/reports/sales-products-by-product-range'
);

export const sernosUsedOnInvoiceReport = new ItemType(
    'sernosUsedOnInvoiceReport',
    'SERNOS_USED_ON_INVOICE',
    '/products/reports/sernos-used-on-invoice'
);

export const salesArticlesByTariffReport = new ItemType(
    'salesArticlesByTariffReport',
    'SALES_ARTICLES_BY_TARIFF',
    '/products/reports/sales-articles/get-by-tariff'
);

export const salesArticleTriggerLevelsReport = new ItemType(
    'salesArticleTriggerLevelsReport',
    'SALES_ARTICLE_TRIGGER_LEVELS',
    '/products/reports/sales-articles/trigger-levels'
);
