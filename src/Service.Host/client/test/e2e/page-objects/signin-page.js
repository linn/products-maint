const { $, browser } = require('protractor');

const BasePage = require('./base-component');

const selector = $('.card');

class SignInPage extends BasePage {
    constructor() {
        super(selector);
        this.selector = selector;
        this.username = this.selector.$('#Username');

        this.password = this.selector.$('#Password');

        this.loginButton = this.selector.$('.btn-primary');

        this.title = this.selector.$('#panel-title');
    }

    async get() {
        await browser.get('#/products/maint');
        await this.waitUntilDisplayed();
    }

    async getTitle() {
        return this.title.getAttribute('id');
    }

    async setUserName(username) {
        await this.username.sendKeys(username);
    }

    async clearUserName() {
        await this.username.clear();
    }

    async setPassword(password) {
        await this.password.sendKeys(password);
    }

    async clearPassword() {
        await this.password.clear();
    }

    async autoSignInUsing(username, password) {
        await this.setUserName(username);
        await this.setPassword(password);
        await this.login();
    }

    async login() {
        await this.loginButton.click();
    }
}

module.exports = SignInPage;
