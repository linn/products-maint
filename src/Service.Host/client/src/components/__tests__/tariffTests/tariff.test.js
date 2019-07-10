import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import Tariff from '../../tariffs/Tariff';

describe('<Tariff />', () => {
    let props;
    let wrapper;
    const getInputFields = () => wrapper.find('InputField');
    const getLoading = () => wrapper.find('Loading');
    const getErrorCard = () => wrapper.find('WithStyles(ErrorCard)');
    const shallow = createShallow({ dive: false });
    wrapper = shallow(<Tariff {...props} />);

    describe('when loaded', () => {
        beforeEach(() => {
            wrapper.setProps({
                loading: false,
                item: {
                    tariffCode: 'P1',
                    description: 'tariff description for a black box',
                    duty: 1
                },
                editStatus: 'view'
            });
        });

        it('should render Input Fields', () => {
            expect(getInputFields()).toHaveLength(5);
        });
    });

    describe('when loading', () => {
        beforeEach(() => {
            wrapper.setProps({ loading: true });
        });

        it('should render loading Spinner', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when there is an error', () => {
        beforeEach(() => {
            wrapper.setProps({ errorMessage: 'an error has occurred', loading: false });
        });

        it('should render ErrorCard', () => {
            expect(getErrorCard()).toHaveLength(1);
        });
    });
});
