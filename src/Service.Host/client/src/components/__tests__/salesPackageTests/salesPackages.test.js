import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import SalesPackages from '../../salesPackages/SalesPackages';

describe('<SalesPackages />', () => {
    let wrapper;
    let props;
    const getTable = () => wrapper.find('WithStyles(Table)');
    const getRows = () => wrapper.find('WithStyles(TableRow)');
    const shallow = createShallow({ dive: false });

    describe('when sales packages have loaded', () => {
        beforeEach(() => {
            props = {
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
            }
            wrapper = shallow(<SalesPackages {...props} />);
        });
        it('should render a table', () => {
            expect(getTable()).toHaveLength(1);
        });
        it('should render a table with four rows including the header', () => {
            expect(getRows()).toHaveLength(4);
        });
    });
});
