import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import VatCodes from '../VatCodes';

describe('<TypesOfSale />', () => {
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
        it('should render loading spinner', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when there is an error message', () => {
        beforeEach(() => {
            wrapper.setProps({ errorMessage: 'an error has occurred' });
        });
    });

    describe('when types of sale', () => {
        beforeEach(() => {
            wrapper.setProps({
                vatCodes: [
                    {
                        code: 'A',
                        description: 'STD UK VAT RATE.',
                        rate: 20
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

        it('should render list items', () => {
            expect(getEntityList()).toHaveLength(1);
        });
    });
});
