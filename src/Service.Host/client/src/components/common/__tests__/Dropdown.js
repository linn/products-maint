import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import Dropdown from '../Dropdown';

describe('<Dropdown />', () => {
    const getInputLabel = () => wrapper.find('WithStyles(WithFormControlContext(InputLabel))');
    const getMenuItems = () => wrapper.find('WithStyles(MenuItem)');
    const getSelect = () => wrapper.find('WithStyles(WithFormControlContext(Select))');
    const shallow = createShallow({ dive: true });
    let wrapper, props;

    beforeEach(() => {
        props = {
            items: [
                'one', 'two', 'three'
            ],
            value: 'val',
            label: 'dropdown label'
        };
        wrapper = shallow(<Dropdown {...props} />);
    })

    it('should render label', () => {
        expect(getInputLabel()).toHaveLength(1);
        expect(getInputLabel().props().children).toEqual('dropdown label');
    });

    it('should render menu items', () => {
        expect(getMenuItems()).toHaveLength(3);
        expect(getMenuItems().at(0).props().children).toEqual('one');
        expect(getMenuItems().at(1).props().children).toEqual('two');
        expect(getMenuItems().at(2).props().children).toEqual('three');
    });

    it('should render select', () => {
        expect(getSelect()).toHaveLength(1);
        expect(getSelect().props().value).toEqual('val');
    });
});