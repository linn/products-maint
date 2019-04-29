const chaiAsPromised = require('chai-as-promised');

const chai = require('chai');

const protractor = require('protractor');

exports.config = {
    allScriptsTimeout: 20000,

    specs: ['./e2e/**/**/*.integration.js'],

    capabilities: {
        browserName: 'chrome'
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
        const { browser } = protractor;
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
