import ItemType from './ItemType';

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
