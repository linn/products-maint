import React from 'react';
import SernosConfigs from '../SernosConfigs';
import { createShallow } from '@material-ui/core/test-utils';

describe('<SernosConfigs />', () => {
    const getListItems = () => wrapper.find('WithStyles(ListItem)');
    const getLinks = () => wrapper.find('Link');
    const shallow = createShallow({ dive: true });;
    let wrapper, props;

    beforeEach(() => {
        props = {
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
            ]
        }

        wrapper = shallow(<SernosConfigs {...props} />);
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
