const { browser, element, by } = require('protractor');
const chai = require('chai');

const { expect } = chai;
const { waitUntilDisplayed } = require('../util/utils');

describe('Sales Articles', () => {
    it('should render the sales articles when a search is made', async () => {
        await browser.get('/products/maint/sales-articles');
        const typeahead = element(by.tagName('input'));
        await waitUntilDisplayed(typeahead);
        typeahead.sendKeys('ra');
        const list = element(by.tagName('ul'));
        await waitUntilDisplayed(list);
        return expect(list.isPresent()).to.eventually.be.true;
    });

    it('should allow navigation to an individual sales article', async () => {
        const listItem = element(by.tagName('p'));
        await waitUntilDisplayed(listItem);
        listItem.click();
        const tab = element(by.tagName('button'));
        await waitUntilDisplayed(tab);
        return expect(tab.getText()).to.eventually.equal('VIEW OR EDIT DETAILS');
    });
});
