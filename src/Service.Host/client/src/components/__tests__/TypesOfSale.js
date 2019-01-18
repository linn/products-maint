import React from 'react';
import TypesOfSale from '../TypesOfSale';
import { createShallow } from '@material-ui/core/test-utils';

describe('<TypesOfSale />', () => {
    const getListItems = () => wrapper.find('WithStyles(ListItem)');
    const getLoading = () => wrapper.find('WithStyles(CircularLoading)');
    const getPaper = () => wrapper.find('WithStyles(Paper)');
    const getErrorCard = () => wrapper.find('WithStyles(ErrorCard)');    
    const shallow = createShallow({ dive: true });
    let wrapper, props;

    beforeEach(() => {
        props = {
            loading: true,
            typesOfSale: null
        }

        wrapper = shallow(<TypesOfSale {...props} />);
    });

    describe('when loading', () => {
        it('should render paper container', () => {
            expect(getPaper()).toHaveLength(1);
        });

        it('should render loading spinner', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when there is an error message', () => {
        beforeEach(() => {
            wrapper.setProps({ errorMessage: 'an error has occurred' });
        });

        it('should render paper container', () => {
            expect(getPaper()).toHaveLength(1);
        });

        it('should render error message', () => {
            expect(getErrorCard()).toHaveLength(1);
            expect(getErrorCard().props().errorMessage).toEqual('an error has occurred');
        });
    });

    describe('when types of sale have loaded without error', () => {
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
            expect(getListItems()).toHaveLength(3);
        });
    });
});
