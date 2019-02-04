import React from 'react';
import { createShallow} from '@material-ui/core/test-utils';
import ProductRangesOptions from '../../reportOptions/ProductRangesOptions';

describe('<ProductRangesOptions />', () => {
    let wrapper;
    let history;
    const getButton = () => wrapper.find('WithStyles(Button)');
    const shallow = createShallow({ dive: true });

    beforeEach(() => {
        history = { push: jest.fn() };
        wrapper = shallow(<ProductRangesOptions history={history} />);
    });

    test('Should redirect with state parameters when button clicked', () => {
        wrapper.setState({ includePhasedOut: true });
        getButton().simulate('click');
        expect(history.push).toHaveBeenCalledWith({
            pathname: '/products/reports/product-ranges/report',
            search: '?includePhasedOut=true'
        });
    });
});
