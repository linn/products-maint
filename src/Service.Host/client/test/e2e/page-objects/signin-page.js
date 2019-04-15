const { $, browser } = require('protractor');

const BasePage = require('./base-component');

const selector = $('#sign-in');

class SignInPage extends BasePage {
    constructor() {
        super(selector);
        this.selector = selector;
        this.selector = undefined;

        this.username = this.selector.$('#UserName');

        this.password = this.selector.$('#Password');

        this.loginButton = this.selector.$('button[type=submit]');

        this.title = this.selector.$('#panel-title');
        console.info(this.title, this.loginButton, this.password, this.username);
    }

    async get() {
        await browser.get('#/login');
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

    async autoSignOut() {
        await browser.get('#/logout');
    }

    async login() {
        await this.loginButton.click();
    }
}

module.exports = SignInPage;
