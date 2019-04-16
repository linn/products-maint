const { browser, element, by } = require('protractor');
const chai = require('chai');

const { expect } = chai;
const { waitUntilDisplayed } = require('../util/utils');
const SignInPage = require('../page-objects/signin-page');

describe('Sales Packages', () => {
    it('should first login', async () => {
        await browser.get('/signin');
        const signInPage = new SignInPage();
        await signInPage.waitUntilDisplayed();
        signInPage.setUserName('');
        signInPage.setPassword('');
        signInPage.login();
        await signInPage.waitUntilHidden();
    });

    it('should render the page with table', async () => {
        await browser.get('/products/maint/sales-packages');
        const table = element(by.id('qa-sales-packages-table'));
        await waitUntilDisplayed(table);
        expect(table.isPresent()).to.be.true;
    });

    it('should render five rows by default', async () => {});

    it('should have pagination options', async () => {
        const paginationOptions = element(by.id('qa-table-pagination-options'));
        await waitUntilDisplayed(paginationOptions);
        expect(paginationOptions.isPresent()).to.be.true;
    });
});
