import React from 'react';
import { shallow } from 'enzyme';
import ExportButton from '../ExportButton';
import { Button } from 'reactstrap';

describe('<ExportButton />', () => {
    const
        href = '/app.linn.co.uk/get/data/export',
        wrapper = shallow(<ExportButton href={href} />);

    test('Should render export button', () => {
        expect(wrapper.find(Button)).toHaveLength(1);
        expect(wrapper.find(Button).props().href).toEqual(href);
    });
});
