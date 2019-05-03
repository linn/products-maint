import PaginationSelectors from './PaginationSelectors';
import * as itemTypes from '../itemTypes';

export default new PaginationSelectors(itemTypes.serialNumberTransactions.item, 'transCode');
