import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import TypeOfSale from '../../typesOfSale/TypeOfSale';

describe('<TypeOfSale />', () => {
    let wrapper;
    let props;
    const getLoading = () => wrapper.find('Loading');
    const getErrorCard = () => wrapper.find('WithStyles(ErrorCard)');
    const getInputFields = () => wrapper.find('InputField');
    const getOnOffSwitch = () => wrapper.find('OnOffSwitch');
    const getButtons = () => wrapper.find('SaveBackCancelButtons');
    const shallow = createShallow({ dive: false });
    beforeEach(() => {
        props = {
            loading: true,
            history: {},
            editStatus: 'view'
        };

        wrapper = shallow(<TypeOfSale {...props} />);
    });

    describe('when loading with no error message', () => {
        it('should render loading spinner', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when loading with error message', () => {
        beforeEach(() => {
            wrapper.setProps({ errorMessage: 'an error has occurred' });
        });

        it('should render error message', () => {
            expect(getErrorCard()).toHaveLength(1);
        });
    });

    describe('when sernos cofig has loaded without error message', () => {
        beforeEach(() => {
            wrapper.setProps({
                typeOfSale: {
                    name: 'LSLPL',
                    description: 'LINNSIGHT SALE OF LINN PRODUCTS',
                    nominal: 'DUMMY',
                    department: 'DUMMY',
                    realSale: 'Y'
                },
                loading: false,
                errorMessage: null
            });
        });

        it('should render text fields', () => {
            expect(getInputFields()).toHaveLength(4);
        });

        it('should render switch', () => {
            expect(getOnOffSwitch()).toHaveLength(1);
        });

        it('should render buttons', () => {
            expect(getButtons()).toHaveLength(1);
        });
    });
});
