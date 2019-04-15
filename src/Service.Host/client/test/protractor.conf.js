const chaiAsPromised = require('chai-as-promised');

const chai = require('chai');

exports.config = {
    allScriptsTimeout: 20000,

    specs: ['./e2e/**/*.spec.js'],

    capabilities: {
        browserName: 'chrome',
        chromeOptions: {
            args: process.env.JHI_E2E_HEADLESS
                ? ['--headless', '--disable-gpu', '--window-size=800,600']
                : ['--disable-gpu', '--window-size=800,600']
        }
    },

    directConnect: true,

    baseUrl: 'http://localhost:3000/',

    framework: 'mocha',

    SELENIUM_PROMISE_MANAGER: false,

    mochaOpts: {
        reporter: 'spec',
        slow: 3000,
        ui: 'bdd',
        timeout: 30000
    },

    onPrepare() {
        let globals = require('protractor');
        let browser = globals.browser;
        // eslint-disable-next-line no-undef
        browser.driver
            .manage()
            .window()
            .setSize(1280, 1024);
        // eslint-disable-next-line no-undef
        browser.ignoreSynchronization = true;
        // Disable animations
        // eslint-disable-next-line no-undef
        browser.executeScript('document.body.className += " notransition";');
        chai.use(chaiAsPromised);
        global.chai = chai;
    }
};
