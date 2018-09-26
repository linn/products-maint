import React from 'react';
import { shallow } from 'enzyme';
import EanCodesOptions from '../../reportOptions/EanCodesOptions';
import { Checkbox, Button } from 'react-bootstrap';

describe('<EanCodesOptions />',
    () => {
        let history = { push : jest.fn() },
            prevOptions = { cartonisedOnly: true, includePhasedOut: false },
            wrapper = shallow(<EanCodesOptions prevOptions={prevOptions} history={history} />);

        test('Should render two checkboxes', () => {
                expect(wrapper.find(Checkbox)).toHaveLength(2);
            });

        test('Should render button', () => {
            expect(wrapper.find(Button)).toHaveLength(1);
        });

        test('Should redirect when button clicked', () => {
            let button = wrapper.find(Button);
            button.simulate("click");

            expect(history.push).toHaveBeenCalledWith({
                pathname: `/products/reports/sales-article-ean-codes/report`,
                search: `?includePhasedOut=false&cartonisedOnly=true`
            });
        });
    });
