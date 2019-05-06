const { isDisplayed, isHidden, waitUntilDisplayed, waitUntilHidden } = require('../util/utils');

/**
 * Base ui component class that other components should inherit from.
 */
class BasePage {
    constructor(selector) {
        if (!selector) {
            this.selector = undefined;
        }
        this.selector = selector;
    }

    checkSelectorExist() {
        if (this.selector === undefined) {
            throw new TypeError(
                `Class '${this.constructor.name}' ` +
                    `extends 'UIComponent' and has to implement abstract property 'selector' ` +
                    `when 'isDisplayed' or 'waitUntilDisplayed' are used`
            );
        }
    }

    /**
     * @returns Function which resolves to boolean
     */
    isDisplayed() {
        this.checkSelectorExist();
        return isDisplayed(this.selector);
    }

    isHidden() {
        this.checkSelectorExist();
        return isHidden(this.selector);
    }

    /**
     * Wait until this page is displayed.
     */
    async waitUntilDisplayed() {
        this.checkSelectorExist();
        await waitUntilDisplayed(this.selector, this.constructor.name);
    }

    async waitUntilHidden() {
        this.checkSelectorExist();
        await waitUntilHidden(this.selector, this.constructor.name);
    }
}

module.exports = BasePage;
