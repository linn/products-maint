import { ExpectedConditions, browser } from 'protractor';

const waitUntilDisplayedTimeout = 30000;

export const checkSelectorExist = selector => selector !== undefined;

/**
 * @returns Function which resolves to boolean
 */
export const isDisplayed = selector => {
    if (!checkSelectorExist(selector)) return;
    return ExpectedConditions.visibilityOf(selector);
};

export const isHidden = selector => {
    if (!checkSelectorExist(selector)) return;
    return ExpectedConditions.invisibilityOf(selector);
};

/**
 * Wait until this page is displayed.
 */
export const waitUntilDisplayed = async (
    selector,
    classname = '',
    timeout = waitUntilDisplayedTimeout
) => {
    if (!checkSelectorExist(selector)) return;

    await browser.wait(
        isDisplayed(selector),
        timeout,
        `Failed while waiting for "${selector.locator()}" of Page Object Class '${classname}' to display.`
    );
};

export const waitUntilHidden = async (
    selector,
    classname = '',
    timeout = waitUntilDisplayedTimeout
) => {
    if (!checkSelectorExist(selector)) return;

    await browser.wait(
        isHidden(selector),
        timeout,
        `Failed while waiting for "${selector.locator()}" of Page Object Class '${classname}' to be hidden.`
    );
};

export const waitForCount = (elementArrayFinder, expectedCount) => () =>
    elementArrayFinder.count().then(actualCount => expectedCount === actualCount);

export const waitUntilCount = async (
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
