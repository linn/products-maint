import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import ProductRange from '../../productRanges/ProductRange';

describe('<ProductRange />', () => {
    let wrapper;
    let props;
    const getInputFields = () => wrapper.find('WithStyles(InputField)');
    const getLoading = () => wrapper.find('Loading');
    const getErrorCard = () => wrapper.find('WithStyles(ErrorCard)');
    const shallow = createShallow({ dive: false });

    describe('when loaded', () => {
        beforeEach(() => {
            props = {
                id: 1,
                loading: false,
                productRange: {
                    id: 1,
                    rangeName: 'name',
                    rangeDescription: 'desc'
                },
                history: {
                    push: () => {}
                },
                editStatus: 'view',
                setEditStatus: () => {}
            };
            wrapper = shallow(<ProductRange {...props} />);
        });

        it('should render Input Fields', () => {
            expect(getInputFields()).toHaveLength(4);
        });
    });

    describe('when loading', () => {
        beforeEach(() => {
            wrapper = shallow(<ProductRange {...props} loading />);
        });

        it('should render loading', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when error', () => {
        beforeEach(() => {
            wrapper = shallow(<ProductRange {...props} errorMessage="error" />);
        });

        it('should render ErrorCard', () => {
            expect(getErrorCard()).toHaveLength(1);
        });
    });
});
