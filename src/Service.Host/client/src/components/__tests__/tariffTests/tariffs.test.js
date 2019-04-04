import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import Tariffs from '../../tariffs/Tariffs';

describe('<Tariffs />', () => {
    let wrapper;
    let props;
    const shallow = createShallow({ dive: false });

    beforeEach(() => {
        props = {
            tariffs: [
                {
                    tariffCode: 'A',
                    description: 'Description of the product needed to explain tariff code',
                    duty: 20
                },
                {
                    tariffCode: 'B',
                    description: 'Description of the product needed to explain tariff code',
                    duty: 10
                }
            ],
            loading: false
        };

        wrapper = shallow(<Tariffs {...props} />);
    });

    describe('when tariifs have loaded', () => {
        it('should render typeahead list', () => {
            expect(wrapper.find('WithStyles(Typeahead)')).toHaveLength(1);
        });
        it('should render a create button', () => {
            expect(wrapper.find('WithStyles(CreateButton)')).toHaveLength(1);
        });
    });
});
