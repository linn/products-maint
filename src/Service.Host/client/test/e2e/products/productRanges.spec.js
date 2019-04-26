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

    it('should render the product ranges title', async () => {
        await browser.get('/products/maint/product-ranges');
        const title = element(by.id('qa-product-ranges-title'));
        await waitUntilDisplayed(title);
        expect(title.isPresent()).to.be.true;
    });

    it('should render the product ranges list', async () => {
        const list = element(by.tagName('List'));
        await waitUntilDisplayed(list);
        expect(list.isPresent()).to.be.true;
    });

    it('should navigate to the create product range', async () => {
        const createButton = element(by.tagName('CreateButton'));
        await waitUntilDisplayed(createButton);
        expect(createButton.isPresent()).to.be.true;
        createButton.click();
        const createProductRangeTitle = element(by.id('qa-product-range-title'));
        await waitUntilDisplayed(createProductRangeTitle);
        expect(createProductRangeTitle.isPresent()).to.be.true;
        const idField = element(by.id('qa-product-range-id'));
        expect(idField.isEnabled()).to.be.true;
        browser.get('/products/maint/product-ranges');
    });

    it('should navigate to the view product range', async () => {
        const listItem = element(by.tagName('ListItem'));
        await waitUntilDisplayed(listItem);
        expect(listItem.isPresent()).to.be.true;
        listItem.click();
        const createProductRangeTitle = element(by.id('qa-product-range-title'));
        await waitUntilDisplayed(createProductRangeTitle);
        expect(createProductRangeTitle.isPresent()).to.be.true;
        const idField = element(by.id('qa-product-range-id'));
        expect(idField.isPresent()).to.be.true;
        expect(idField.isEnabled()).to.be.false;
        browser.get('/products/maint/product-ranges');
    });
});
