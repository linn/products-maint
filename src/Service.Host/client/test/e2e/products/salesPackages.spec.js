import { browser, element, by } from 'protractor';
import { waitUntilDisplayed } from '../util/utils';

const { expect } = require('chai');

describe('Sales Packages', () => {
    before(async () => {
        console.info('we got to here');
        await browser.get('http://localhost:3000/products/maint');
        await browser.get('/products/maint/sales-packages');
        console.info('we finished here');
        it('should load a list of sales packages', async () => {
            const page = element(by.id('qa-sales-packages-page'));
            await waitUntilDisplayed(page);
            // Title should be equal to 'Users'
            expect(await page.isPresent()).to.be.true;
        });
    });
});
