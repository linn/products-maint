import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import VatCode from '../VatCode';

describe('<VatCode />', () => {
    let wrapper;
    let props;
    const getLoading = () => wrapper.find('Loading');
    const getErrorCard = () => wrapper.find('WithStyles(ErrorCard)');
    const getInputFields = () => wrapper.find('WithStyles(InputField)');
    const getButtons = () => wrapper.find('WithStyles(SaveBackCancelButtons)');

    const shallow = createShallow({ dive: false });

    beforeEach(() => {
        props = {
            loading: true,
            history: {},
            editStatus: 'view'
        };

        wrapper = shallow(<VatCode {...props} />);
    });

    describe('when loading with no error message', () => {
        it('should render loading', () => {
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

    describe('when vat code has loaded without error message', () => {
        beforeEach(() => {
            wrapper.setProps({
                vatCode: {
                    code: 'A',
                    description: 'STD UK VAT RATE.',
                    rate: 20
                },
                loading: false,
                history: {},
                editStatus: 'view'
            });
        });

        it('should render input fields', () => {
            expect(getInputFields()).toHaveLength(4);
        });

        it('should render buttons', () => {
            expect(getButtons()).toHaveLength(1);
        });
    });
});
