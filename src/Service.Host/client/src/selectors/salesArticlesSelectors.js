import { CollectionSelectors } from '@linn-it/linn-form-components-library';
import * as itemTypes from '../itemTypes';

export const getSerialNumberedSalesArticles = state => {
    const { salesArticles } = state;

    if (salesArticles.items.length) {
        return salesArticles.items.filter(
            s =>
                s.typeOfSerialNumber === 'P1' ||
                s.typeOfSerialNumber === 'P2' ||
                s.typeOfSerialNumber === 'S'
        );
    }

    return null;
};

export default new CollectionSelectors(itemTypes.salesArticles.item, 'articleNumber');
