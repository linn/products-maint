import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import CheckboxWithLabel from '../CheckboxWithLabel';

describe('<CheckboxWithLabel />', () => {
    const getFormControlLabel = () => wrapper.find('WithStyles(WithFormControlContext(FormControlLabel))');
    const shallow = createShallow({ dive: true });
    let wrapper, props;

    beforeEach(() => {
        props = {
            label: 'checkbox label'
        }
        wrapper = shallow(<CheckboxWithLabel {...props} />);
    });

    it('should render label', () => {
        expect(getFormControlLabel()).toHaveLength(1);
        expect(getFormControlLabel().props().label).toEqual('checkbox label');
    });
});