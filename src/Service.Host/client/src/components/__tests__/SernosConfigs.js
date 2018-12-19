import React from 'react';
import SernosConfigs from '../SernosConfigs';
import { createShallow } from '@material-ui/core/test-utils';

describe('<SernosConfigs />', () => {
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
            sernosConfigs: null
        }

        wrapper = shallow(<SernosConfigs {...props} />);
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

    describe('when sernos configs have loaded without error', () => {
        beforeEach(() => {
            wrapper.setProps({
                sernosConfigs: [
                    {
                        name: 'P1',
                        description: 'Serial Numbered In Pairs, One Box',
                        href: '/products/main/sernos-configs/1'
                    },
                    {
                        name: 'P2',
                        description: 'Serial Numbered In Pairs, Two Boxes',
                        href: '/products/main/sernos-configs/1'
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
            expect(getListItems().at(0).props().children).toEqual(['P1', ' - ', 'Serial Numbered In Pairs, One Box']);
            expect(getListItems().at(1).props().children).toEqual(['P2', ' - ', 'Serial Numbered In Pairs, Two Boxes']);
        });

        it('should render create link', () => {
            expect(getLinks()).toHaveLength(1);
            expect(getLinks().at(0).props().children).toEqual('Create new serial number config type');
        });
    });
});
