import React from 'react';
import { shallow } from 'enzyme';
import SernosConfigs from '../SernosConfigs';
import { Link } from 'react-router-dom';
import ListItem from '@material-ui/core/ListItem';

describe('<SernosConfigs />', () => {
    describe('View Sernos Configs', () => {
        let sernosConfigs = [{ name: 'name1' }, { name: 'name2' }],
            wrapper = shallow(<SernosConfigs sernosConfigs={sernosConfigs} />).dive();

        test('Should render view', () => {
            expect(wrapper.find(ListItem)).toHaveLength(2);
            expect(wrapper.find(ListItem).at(0).html()).toContain('name1');
            expect(wrapper.find(ListItem).at(1).html()).toContain('name2');
        });

        test('Should render create link', () => {
            expect(wrapper.find(Link)).toHaveLength(1);
        });
    });
});
