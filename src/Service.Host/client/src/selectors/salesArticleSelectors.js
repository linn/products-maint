import ItemSelectors from './ItemSelectors';
import * as itemTypes from '../itemTypes';

export const getArticleType = state => {
    const { salesArticle } = state;

    if (salesArticle.item) {
        return salesArticle.item.typeOfSerialNumber;
    }

    return null;
};

export default new ItemSelectors(itemTypes.salesArticle.item, 'articleNumber');
