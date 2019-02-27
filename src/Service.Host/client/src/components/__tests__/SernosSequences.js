import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import SernosSequences from '../SernosSequences';

describe('<SernosSequences />', () => {
    let wrapper;
    let props;
    const getEntityList = () => wrapper.find('EntityList');
    const getLoading = () => wrapper.find('Loading');
    const shallow = createShallow({ dive: false });

    beforeEach(() => {
        props = {
            loading: true,
            sernosSequences: []
        };

        wrapper = shallow(<SernosSequences {...props} />);
    });

    describe('when loading', () => {
        it('should render loading', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when sernos sequences are present', () => {
        beforeEach(() => {
            wrapper.setProps({
                sernosSequences: [
                    {
                        sequenceName: 'KRYSTAL',
                        description: 'KRYSTAL MOVING COIL CARTRIDGE',
                        nextSerialNumber: 1940,
                        dateClosed: '2010-02-21T14:48:00.000Z'
                    },
                    {
                        sequenceName: 'QNAP',
                        description: 'QNAP NAS (TS210)',
                        nextSerialNumber: 10000,
                        dateClosed: null
                    }
                ],
                loading: false,
                errorMessage: null
            });
        });

        it('should display entitiy list', () => {
            expect(getEntityList()).toHaveLength(1);
        });
    });
});
