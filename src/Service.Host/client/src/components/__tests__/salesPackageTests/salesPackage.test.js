import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import SalesPackage from '../../salesPackages/SalesPackage';

describe('<SalesPackage />', () => {
    let props;
    let wrapper;
    const getInputFields = () => wrapper.find('WithStyles(InputField)');
    const getLoading = () => wrapper.find('Loading');
    const getErrorCard = () => wrapper.find('WithStyles(ErrorCard)');
    const shallow = createShallow({ dive: false });
    wrapper = shallow(<SalesPackage {...props} />);

    describe('when loaded', () => {
        beforeEach(() => {
            wrapper.setProps({
                loading: false,
                item: {
                    salesPackageId: 'AudioKaro',
                    description: 'Sounds really good',
                    elements: [{ elementType: 'speakers', sequence: 1, quantity: 1 }]
                },
                editStatus: 'view'
            });
        });

        it('should render Input Fields', () => {
            expect(getInputFields()).toHaveLength(2);
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
