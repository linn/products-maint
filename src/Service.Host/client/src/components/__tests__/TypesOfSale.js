import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import TypesOfSale from '../TypesOfSale';

describe('<TypesOfSale />', () => {
    let wrapper;
    let props;
    const getEntityList = () => wrapper.find('EntityList');
    const getLoading = () => wrapper.find('Loading');
    const shallow = createShallow({ dive: false });

    beforeEach(() => {
        props = {
            loading: true,
            typesOfSale: []
        };

        wrapper = shallow(<TypesOfSale {...props} />);
    });

    describe('when loading', () => {
        it('should render loading spinner', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when there is an error message', () => {
        beforeEach(() => {
            wrapper.setProps({ errorMessage: 'an error has occurred' });
        });
    });

    describe('when types of sale', () => {
        beforeEach(() => {
            wrapper.setProps({
                typesOfSale: [
                    {
                        name: 'LSLPL',
                        description: 'LINNSIGHT SALE OF LINN PRODUCTS',
                        href: '/products/main/types-of-sale/1'
                    },
                    {
                        name: 'DL',
                        description: 'SALES OF LINN RECORDS DOWNLOADS',
                        href: '/products/main/types-of-sale/2'
                    }
                ],
                loading: false,
                errorMessage: null
            });
        });

        it('should render list items', () => {
            expect(getEntityList()).toHaveLength(1);
        });
    });
});
