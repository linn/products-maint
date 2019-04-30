const { browser, element, by } = require('protractor');
const chai = require('chai');

const { expect } = chai;
const { waitUntilDisplayed } = require('../util/utils');
const SignInPage = require('../page-objects/signin-page');

describe('Product Ranges', () => {
    it('should first login', async () => {
        await browser.get('/signin');
        const signInPage = new SignInPage();
        await signInPage.waitUntilDisplayed();
        signInPage.setUserName(process.env.TEST_USER_NAME);
        signInPage.setPassword(process.env.TEST_USER_PWD);
        signInPage.login();
        await signInPage.waitUntilHidden();
    });

    it('should render the product ranges title', async () => {
        await browser.get('/products/maint/product-ranges');
        const title = element(by.className('MuiTypography-h4-85'));
        await waitUntilDisplayed(title);
        return expect(title.getText()).to.eventually.equal('Product Ranges');
    });

    it('should render the product ranges list', async () => {
        const list = element(by.tagName('ul'));
        await waitUntilDisplayed(list);
        return expect(list.isPresent()).to.eventually.be.true;
    });

    it('should navigate to the create product range', async () => {
        const createButton = element(by.className('CreateButton-root-140'));
        await waitUntilDisplayed(createButton);
        return expect(createButton.getText()).to.eventually.equal('CREATE');
    });

    it('should show the create product range view', async () => {
        const createButton = element(by.className('CreateButton-root-140'));
        await waitUntilDisplayed(createButton);
        createButton.click();

        const createProductRangeTitle = element(by.tagName('h4'));
        await waitUntilDisplayed(createProductRangeTitle);
        return expect(createProductRangeTitle.isPresent()).to.eventually.be.true;
    });

    it('should have an id field', async () => {
        const idField = element(by.className('MuiInputLabel-disabled-296'));
        await waitUntilDisplayed(idField);
        return expect(idField.getText()).to.eventually.equal('Id');
    });

    it('should navigate to the view product range', async () => {
        browser.get('/products/maint/product-ranges');
        const listItem = element(by.tagName('a'));
        await waitUntilDisplayed(listItem);
        return expect(listItem.isPresent()).to.eventually.be.true;
        // const createProductRangeTitle = element(by.id('qa-product-range-title'));
        // await waitUntilDisplayed(createProductRangeTitle);
        // expect(createProductRangeTitle.isPresent()).to.be.true;
        // const idField = element(by.id('qa-product-range-id'));
        // expect(idField.isPresent()).to.be.true;
        // expect(idField.isEnabled()).to.be.false;
        // browser.get('/products/maint/product-ranges');
    });
});
