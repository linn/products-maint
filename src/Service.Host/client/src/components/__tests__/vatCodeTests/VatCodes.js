import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import VatCodes from '../../vatCodes/VatCodes';

describe('<VatCodes />', () => {
    let wrapper;
    let props;
    const getEntityList = () => wrapper.find('EntityList');
    const getLoading = () => wrapper.find('Loading');
    const shallow = createShallow({ dive: false });

    beforeEach(() => {
        props = {
            loading: true,
            vatCodes: []
        };

        wrapper = shallow(<VatCodes {...props} />);
    });

    describe('when loading', () => {
        it('should render loading', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when vat codes have loaded', () => {
        beforeEach(() => {
            wrapper.setProps({
                vatCodes: [
                    {
                        code: 'A',
                        description: 'STD UK VAT RATE.',
                        rate: 20,
                        links: []
                    },
                    {
                        code: 'B',
                        description: 'UK VAT ZERO RATE',
                        rate: 0
                    }
                ],
                loading: false,
                errorMessage: null
            });
        });

        it('should render entity list', () => {
            expect(getEntityList()).toHaveLength(1);
        });
    });
});
