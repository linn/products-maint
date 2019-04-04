import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import SalesPackages from '../../salesPackages/SalesPackages';

describe('<SalesPackages />', () => {
    const shallow = createShallow({ dive: false });
    let wrapper;
    describe('when sales packages have loaded', () => {
        beforeEach(() => {
            const props = {
                loading: false,
                items: [
                    {
                        salesPackageId: 'AudioQoui1',
                        description: 'Description of the sound',
                        links: [{ rel: 'self', href: 'localhost/part/part' }],
                        elements: [{ elementType: 'Type', sequence: 1, quantity: 2 }]
                    },
                    {
                        salesPackageId: 'AudioQoui2',
                        description: 'Description of the sound',
                        links: [{ rel: 'self', href: 'localhost/part/part' }],
                        elements: [{ elementType: 'Type', sequence: 1, quantity: 2 }]
                    },
                    {
                        salesPackageId: 'AudioQoui3',
                        description: 'Description of the sound',
                        links: [{ rel: 'self', href: 'localhost/part/part' }],
                        elements: [{ elementType: 'Type', sequence: 1, quantity: 2 }]
                    }
                ]
            };
            wrapper = shallow(<SalesPackages {...props} />);
        });
        it('should render a table', () => {
            expect(wrapper.find('WithStyles(Table)')).toHaveLength(1);
        });
        it('should render a table with four rows including the header', () => {
            expect(wrapper.find('WithStyles(TableRow)')).toHaveLength(4);
        });
    });

    describe('when sales packages have not loaded', () => {
        beforeEach(() => {
            const props = {
                loading: true,
                items: []
            };
            wrapper = shallow(<SalesPackages {...props} />);
        });

        it('should render the loading dialog', () => {
            expect(wrapper.find('Loading')).toHaveLength(1);
        });
    });
});
