import React from 'react';
import SernosConfigs from '../SernosConfigs';
import { Link } from 'react-router-dom';
import ListItem from '@material-ui/core/ListItem';
import { mount } from 'enzyme';
import { BrowserRouter } from 'react-router-dom';

describe('<SernosConfigs />', () => {
    describe('View Sernos Configs', () => {
        let sernosConfigs = [{ name: 'name1', href: '/name1' }, { name: 'name2', href: 'name2' }];

        const wrapper = mount(
            <BrowserRouter>
                <SernosConfigs sernosConfigs={sernosConfigs} />
            </BrowserRouter>
        );

        test('Should render view', () => {
            expect(wrapper.find(ListItem)).toHaveLength(2);
            expect(wrapper.find(ListItem).at(0).html()).toContain('name1');
            expect(wrapper.find(ListItem).at(1).html()).toContain('name2');
        });

        test('Should render create link', () => {
            expect(wrapper.find(Link)).toHaveLength(3);
            expect(wrapper.find(Link).at(2).html()).toContain('Create new serial number config type');
        });
    });
});
