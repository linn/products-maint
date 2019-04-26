const { browser, element, by } = require('protractor');
const chai = require('chai');

const { expect } = chai;
const { waitUntilDisplayed } = require('../util/utils');
const SignInPage = require('../page-objects/signin-page');

describe('Sales Articles', () => {
    it('should first login', async () => {
        await browser.get('/signin');
        const signInPage = new SignInPage();
        await signInPage.waitUntilDisplayed();
        signInPage.setUserName('');
        signInPage.setPassword('');
        signInPage.login();
        await signInPage.waitUntilHidden();
    });

    it('should render the sales articles when a search is made', async () => {
        await browser.get('/products/maint/sales-articles');
        const typeahead = element(by.id('qa-sales-articles-typeahead'));
        typeahead.sendKeys('ra');
        const list = element(by.tagName('List'));
        await waitUntilDisplayed(list);
        expect(list.isPresent()).to.be.true;
    });

    it('should allow navigation to an individual sales article', async () => {
        const listItem = element(by.tagName(''));
        await waitUntilDisplayed(listItem);
        listItem.click();
    });
});
