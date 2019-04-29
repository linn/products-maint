const { browser, element, by } = require('protractor');
const chai = require('chai');

const { expect } = chai;
const { waitUntilDisplayed } = require('../util/utils');

describe('Sales Packages', () => {
    it('should render the page with table', async () => {
        await browser.get('/products/maint/sales-packages');
        const table = element(by.className('MuiTable-root-187'));
        await waitUntilDisplayed(table);
        return expect(table.isPresent()).to.eventually.be.true;
    });
    it('should render five rows by default', async () => {
        const rows = element.all(by.className('MuiTableRow-root-189'));
        await waitUntilDisplayed(rows);
        console.info(rows);
        return expect(rows.length).to.eventually.equal(6); // +1 for the header
    });
    it('should have pagination options', async () => {
        const paginationOptions = element(by.className('MuiTablePagination-root-217'));
        await waitUntilDisplayed(paginationOptions);
        return expect(paginationOptions.isPresent()).to.eventually.be.true;
    });
});
