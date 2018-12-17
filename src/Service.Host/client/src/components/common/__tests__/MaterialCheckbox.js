import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import { FormControlLabel } from '@material-ui/core';
import MaterialCheckbox from '../MaterialCheckbox';

describe('<MaterialCheckbox />', () => {
    describe('when rendering', () => {
        const shallow = createShallow({ dive: true });

        const props = {
            label: 'checkbox label'
        }

        it('should render label', () => {
            const wrapper = shallow(<MaterialCheckbox {...props} />);
            expect(wrapper.find(FormControlLabel)).toHaveLength(1);
            expect(wrapper.find(FormControlLabel).html()).toContain('checkbox label');
        });

    });
});