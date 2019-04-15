const { ExpectedConditions, browser } = require('protractor');

const waitUntilDisplayedTimeout = 30000;

const checkSelectorExist = selector => selector !== undefined;

/**
 * @returns Function which resolves to boolean
 */
const isDisplayed = selector => {
    if (!checkSelectorExist(selector)) return;
    return ExpectedConditions.visibilityOf(selector);
};

const isHidden = selector => {
    if (!checkSelectorExist(selector)) return;
    return ExpectedConditions.invisibilityOf(selector);
};

/**
 * Wait until this page is displayed.
 */
const waitUntilDisplayed = async (
    selector,
    classname = '',
    timeout = waitUntilDisplayedTimeout
) => {
    console.info('wait until displayed');
    if (!checkSelectorExist(selector)) return;

    await browser.wait(
        isDisplayed(selector),
        timeout,
        `Failed while waiting for "${selector.locator()}" of Page Object Class '${classname}' to display.`
    );
};

const waitUntilHidden = async (selector, classname = '', timeout = waitUntilDisplayedTimeout) => {
    if (!checkSelectorExist(selector)) return;

    await browser.wait(
        isHidden(selector),
        timeout,
        `Failed while waiting for "${selector.locator()}" of Page Object Class '${classname}' to be hidden.`
    );
};

const waitForCount = (elementArrayFinder, expectedCount) => () =>
    elementArrayFinder.count().then(actualCount => expectedCount === actualCount);

const waitUntilCount = async (
    elementArrayFinder,
    expectedCount,
    timeout = waitUntilDisplayedTimeout
) => {
    await browser.wait(
        waitForCount(elementArrayFinder, expectedCount),
        timeout,
        `Failed while waiting for "${elementArrayFinder.locator()}" to have ${expectedCount} elements.`
    );
};

module.exports = [waitUntilDisplayed, waitUntilCount, waitForCount, waitUntilHidden];
