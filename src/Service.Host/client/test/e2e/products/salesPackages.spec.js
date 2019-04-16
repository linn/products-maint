const { browser, element, by, ExpectedConditions } = require('protractor');
const chai = require('chai');

const { expect } = chai;
const waitUntilDisplayed = require('../util/utils');

describe('Sales Packages', () => {
    it('should render the page', async () => {
        browser.get('/products/maint/sales-packages');
        const userName = 'peterma';
        const psswrd = 'Products1';
        const until = ExpectedConditions;
        browser.wait(
            until.presenceOf(element(by.className('sign-in'))),
            10000,
            'Element taking too long to appear in the DOM'
        );

        const userNameInput = element(by.id('Username'));
        await waitUntilDisplayed(userNameInput);

        const pwdInput = element(by.id('Password'));
        await waitUntilDisplayed(pwdInput);

        const submit = element(by.className('btn-primary'));
        await waitUntilDisplayed(submit);

        userNameInput.sendKeys(userName);
        pwdInput.sendKeys(psswrd);
        submit.click();

        const idColumnHeader = element(by.id('qa-sales-package-id-column-header'));

        await waitUntilDisplayed(idColumnHeader);
        expect(await idColumnHeader.isPresent()).to.be.true;
    });

    it('should render five rows by default', async () => {});
});
