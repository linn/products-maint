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
                page: {
                    elements: [
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
                    ],
                    pageNumber: 0,
                    pageSize: 5,
                    totalItemCount: 3
                }
            };
            wrapper = shallow(<SalesPackages {...props} />);
        });
        it('should render a table', () => {
            console.log(wrapper.debug());
            expect(wrapper.find('PaginatedTable')).toHaveLength(1);
        });
    });

    describe('when sales packages have not loaded', () => {
        beforeEach(() => {
            const props = {
                loading: true,
                page: { elements: [] }
            };
            wrapper = shallow(<SalesPackages {...props} />);
        });

        it('should render the loading dialog', () => {
            expect(wrapper.find('Loading')).toHaveLength(1);
        });
    });
});
