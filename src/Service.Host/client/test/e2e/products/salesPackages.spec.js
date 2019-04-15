const { browser, element, by } = require('protractor');
const chai = require('chai');

const { expect } = chai;
const signInPage = require('../page-objects/signin-page');
const waitUntilDisplayed = require('../util/utils');

describe('Sales Packages', () => {
    it('should fail to login with bad password', async () => {
        await browser.get('/products/maint/');

        const loginPageTitle = 'Sign In';

        // Login page should appear
        console.info(signInPage.getTitle());
        expect(await signInPage.getTitle()).to.eq(loginPageTitle);

        await signInPage.username.sendKeys('admin');
        await signInPage.password.sendKeys('foo');
        await signInPage.loginButton.click();

        // Login page should stay open when login fails
        expect(await signInPage.getTitle()).to.eq(loginPageTitle);
    });

    it('should render the page', async () => {
        await browser.get('/products/maint/sales-packages');
        const userName = 'peterma';
        const psswrd = '';

        const userNameInput = element(by.id('UserName'));
        const pwdInput = element(by.id('Password'));

        const idColumnHeader = element(by.id('qa-sales-package-id-column-header'));
        await waitUntilDisplayed(idColumnHeader);
        expect(await idColumnHeader.isPresent()).to.be.true;
    });
});
