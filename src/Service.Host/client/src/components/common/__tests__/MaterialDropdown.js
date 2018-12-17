import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import { InputLabel, MenuItem } from '@material-ui/core';
import MaterialDropdown from '../MaterialDropdown';

describe('<MaterialDropdown />', () => {
    describe('when rendering', () => {
        const shallow = createShallow({ dive: true });

        const props = {
            items: [
                'one', 'two', 'three'
            ],
            value: 'val',
            label: 'dropdown label'
        }

        it('should render label', () => {
            const wrapper = shallow(<MaterialDropdown {...props} />);
            expect(wrapper.find(InputLabel)).toHaveLength(1);
            expect(wrapper.find(InputLabel).html()).toContain('dropdown label');
        });

        it('should render menu items', () => {
            const wrapper = shallow(<MaterialDropdown {...props} />);
            expect(wrapper.find(MenuItem)).toHaveLength(3);
            expect(wrapper.find(MenuItem).at(0).html()).toContain('one');
            expect(wrapper.find(MenuItem).at(1).html()).toContain('two');
            expect(wrapper.find(MenuItem).at(2).html()).toContain('three');
        });
    });
});