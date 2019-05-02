const { browser, element, by } = require('protractor');
const chai = require('chai');

const { expect } = chai;
const { waitUntilDisplayed } = require('../util/utils');

describe('Sales Packages', () => {
    it('should render the page with table', async () => {
        await browser.get('/products/maint/sales-packages');
        const table = element(by.tagName('table'));
        await waitUntilDisplayed(table);
        return expect(table.isPresent()).to.eventually.be.true;
    });
    it('should have pagination options', async () => {
        const paginationOptions = element(by.tagName('tfoot'));
        await waitUntilDisplayed(paginationOptions);
        return expect(paginationOptions.isPresent()).to.eventually.be.true;
    });
});
