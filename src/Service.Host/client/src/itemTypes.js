import ItemType from './ItemType';

export const sernosConfig = new ItemType('sernosConfig', 'SERNOS_CONFIG', '/products/maint/sernos-configs');
export const sernosConfigs = new ItemType('sernosConfigs', 'SERNOS_CONFIGS', '/products/maint/sernos-configs');

export const saCoreType = new ItemType('saCoreType', 'SA_CORE_TYPE', '/products/maint/sa-core-types');
export const saCoreTypes = new ItemType('saCoreTypes', 'SA_CORE_TYPES', '/products/maint/sa-core-types');

export const salesArticle = new ItemType('salesArticle', 'SALES_ARTICLE', '/products/maint/sales-articles?articleNumber=');
export const salesArticles = new ItemType('salesArticles', 'SALES_ARTICLES', '/products/maint/sales-articles');