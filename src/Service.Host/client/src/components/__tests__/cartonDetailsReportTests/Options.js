import React from 'react';
import { shallow } from 'enzyme';
import CartonDetailsOptions from '../../reportOptions/CartonDetailsOptions';
import { Button } from 'react-bootstrap';

describe('<CartonDetailsOptions />', () => {
    let history = { push : jest.fn() },
        wrapper = shallow(<CartonDetailsOptions history={history} />);

    test('Should render button', () => {
        expect(wrapper.find(Button)).toHaveLength(1);
    });

    test('Should redirect when button clicked', () => {
        let button = wrapper.find(Button);
        button.simulate("click");

        expect(history.push).toHaveBeenCalledWith({
            pathname: `/products/reports/carton-details/report`
        });
    });
});
