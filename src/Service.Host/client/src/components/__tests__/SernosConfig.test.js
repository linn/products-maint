import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import SernosConfig from '../SernosConfig';

describe('<SernosConfig />', () => {
    let wrapper;
    let props;
    const getInputFields = () => wrapper.find('WithStyles(InputField)');
    const getDropdowns = () => wrapper.find('Dropdown');
    const getLoading = () => wrapper.find('Loading');
    const getErrorCard = () => wrapper.find('WithStyles(ErrorCard)');
    const shallow = createShallow({ dive: false });

    describe('when loaded', () => {
        beforeEach(() => {
            props = {
                loading: false,
                sernosConfig: {
                    name: 'P1',
                    description: 'Serial Numbered In Pairs, One Box',
                    serialNumbered: 'Y',
                    numberOfSernos: 1,
                    numberOfBoxes: 1,
                    startOn: 'Odd'
                },
                history: {
                    push: () => {},
                    location: {
                        pathname: '/a/test/path'
                    }
                },
                editStatus: 'view'
            };
            wrapper = shallow(<SernosConfig {...props} />);
        });

        it('should render Input Fields', () => {
            expect(getInputFields()).toHaveLength(4);
            expect(getDropdowns()).toHaveLength(2);
        });
    });

    describe('when loading', () => {
        beforeEach(() => {
            wrapper = shallow(<SernosConfig {...props} loading />);
        });

        it('should render loading Spinner', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when error', () => {
        beforeEach(() => {
            wrapper = shallow(<SernosConfig {...props} errorMessage="error" />);
        });

        it('should render ErrorCard', () => {
            expect(getErrorCard()).toHaveLength(1);
        });
    });
});
