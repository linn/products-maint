const { ExpectedConditions, browser } = require('protractor');

const waitUntilDisplayedTimeout = 30000;

const UtilityService = {
    checkSelectorExist: selector => selector !== undefined,

    /**
     * @returns Function which resolves to boolean
     */
    isDisplayed: selector => {
        if (!UtilityService.checkSelectorExist(selector)) return new Promise(false);
        // eslint-disable-next-line consistent-return
        return ExpectedConditions.visibilityOf(selector);
    },

    isHidden: selector => {
        if (!UtilityService.checkSelectorExist(selector)) return new Promise(false);
        return ExpectedConditions.invisibilityOf(selector);
    },
    /**
     * Wait until this page is displayed.
     */
    waitUntilDisplayed: async (selector, classname = '', timeout = waitUntilDisplayedTimeout) => {
        if (!UtilityService.checkSelectorExist(selector)) return;

        await browser.wait(
            UtilityService.isDisplayed(selector),
            timeout,
            `Failed while waiting for "${selector.locator()}" of Page Object Class '${classname}' to display.`
        );
    },

    waitUntilHidden: async (selector, classname = '', timeout = waitUntilDisplayedTimeout) => {
        if (!UtilityService.checkSelectorExist(selector)) return;

        await browser.wait(
            UtilityService.isHidden(selector),
            timeout,
            `Failed while waiting for "${selector.locator()}" of Page Object Class '${classname}' to be hidden.`
        );
    },

    waitForCount: (elementArrayFinder, expectedCount) => () =>
        elementArrayFinder.count().then(actualCount => expectedCount === actualCount),

    waitUntilCount: async (
        elementArrayFinder,
        expectedCount,
        timeout = waitUntilDisplayedTimeout
    ) => {
        await browser.wait(
            UtilityService.waitForCount(elementArrayFinder, expectedCount),
            timeout,
            `Failed while waiting for "${elementArrayFinder.locator()}" to have ${expectedCount} elements.`
        );
    }
};

module.exports = UtilityService;
