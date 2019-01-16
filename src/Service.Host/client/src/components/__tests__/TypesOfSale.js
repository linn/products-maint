import React from 'react';
import TypesOfSale from '../TypesOfSale';
import { createShallow } from '@material-ui/core/test-utils';

describe('<TypesOfSale />', () => {
    const getListItems = () => wrapper.find('WithStyles(ListItem)');
    const getLinks = () => wrapper.find('Link');
    const getLoading = () => wrapper.find('WithStyles(CircularLoading)');
    const getPaper = () => wrapper.find('WithStyles(Paper)');
    const getErrorCard = () => wrapper.find('WithStyles(ErrorCard)');
    const getTypography = () => wrapper.find('WithStyles(Typography)');
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

        it('should render title', () => {
            expect(getTypography()).toHaveLength(1);
        });

        it('should render list items', () => {
            expect(getListItems()).toHaveLength(2);
            expect(getListItems().at(0).props().children).toEqual(['LSLPL', ' - ', 'LINNSIGHT SALE OF LINN PRODUCTS']);
            expect(getListItems().at(1).props().children).toEqual(['DL', ' - ', 'SALES OF LINN RECORDS DOWNLOADS']);
        });

        it('should render create link', () => {
            expect(getLinks()).toHaveLength(1);
            expect(getLinks().at(0).props().children).toEqual('Create new Type of Sale');
        });
    });
});
