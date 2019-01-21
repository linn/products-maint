import React from 'react';
import { createShallow} from '@material-ui/core/test-utils';
import EanCodesOptions from '../../reportOptions/EanCodesOptions';

describe('<EanCodesOptions />', () => {
    const getButton = () => wrapper.find('WithStyles(Button)');
    const getCheckbox = () => wrapper.find('WithStyles(Checkbox)').first();
    const shallow = createShallow({ dive: true });

    let wrapper, history;

    beforeEach(() => { 
        history = { push: jest.fn() }; 
        wrapper = shallow(<EanCodesOptions history={history}  />)
    });

    test('Should redirect with state parameters when button clicked', () => {
        wrapper.setState({ includePhasedOut: true, cartonisedOnly: true});
        getButton().simulate("click");
        expect(history.push).toHaveBeenCalledWith({
            pathname: `/products/reports/sales-article-ean-codes/report`,
            search: "?includePhasedOut=true&cartonisedOnly=true"
        });
    });
});
