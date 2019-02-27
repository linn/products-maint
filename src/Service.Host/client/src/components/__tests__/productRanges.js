import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import ProductRanges from '../productRanges/ProductRanges';

describe('<ProductRanges />', () => {
    let wrapper;
    let props;
    const mockHistory = {
        push: jest.fn()
    };
    const getEntityList = () => wrapper.find('EntityList');
    const getLoading = () => wrapper.find('Loading');
    const shallow = createShallow({ dive: false });

    describe('when loaded', () => {
        beforeEach(() => {
            props = {
                loading: false,
                items: [
                    {
                        rangeName: 'name',
                        rangeDescription: 'desc',
                        href: '/1'
                    }
                ],
                history: mockHistory
            };
            wrapper = shallow(<ProductRanges {...props} />);
        });

        it('should render EntityList', () => {
            expect(getEntityList()).toHaveLength(1);
        });
    });

    describe('when loading', () => {
        beforeEach(() => {
            props = {
                loading: true,
                items: null,
                history: mockHistory
            };
            wrapper = shallow(<ProductRanges {...props} />);
        });

        it('should render Loading', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });
});
