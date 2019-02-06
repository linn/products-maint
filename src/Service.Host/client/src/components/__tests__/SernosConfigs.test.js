import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import SernosConfigs from '../SernosConfigs';

describe('<SernosConfigs />', () => {
    let wrapper;
    let props;
    const mockHistory = {
        push: jest.fn(),
        location: {
            pathname: '/a/test/path'
        }
    };
    const getEntityList = () => wrapper.find('EntityList');
    const getLoading = () => wrapper.find('Loading');
    const shallow = createShallow({ dive: false });

    describe('when loaded', () => {
        beforeEach(() => {
            props = {
                loading: false,
                sernosConfigs: [
                    {
                        name: 'P1',
                        description: 'Serial Numbered In Pairs, One Box',
                        href: '/products/main/sernos-configs/1'
                    },
                    {
                        name: 'P2',
                        description: 'Serial Numbered In Pairs, Two Boxes',
                        href: '/products/main/sernos-configs/1'
                    }
                ],
                history: mockHistory
            };
            wrapper = shallow(<SernosConfigs {...props} />);
        });

        it('should render EntityList', () => {
            expect(getEntityList()).toHaveLength(1);
        });
    });

    describe('when loading', () => {
        beforeEach(() => {
            props = {
                loading: true,
                sernosConfigs: null,
                history: mockHistory
            };
            wrapper = shallow(<SernosConfigs {...props} />);
        });

        it('should render Loading spinner', () => {
            wrapper = shallow(<SernosConfigs {...props} />);
            expect(getLoading()).toHaveLength(1);
        });
    });
});
