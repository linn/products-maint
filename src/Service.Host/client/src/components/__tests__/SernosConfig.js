import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import SernosConfig from '../SernosConfig';

describe('<SernosConfig />', () => {
    const getPaper = () => wrapper.find('WithStyles(Paper)');
    const getLoading = () => wrapper.find('WithStyles(CircularLoading)');
    const getErrorCard = () => wrapper.find('WithStyles(ErrorCard)');
    const getTypography = () => wrapper.find('WithStyles(Typography)');
    const getTextFields = () => wrapper.find('TextField');
    const getButtons = () => wrapper.find('WithStyles(Button)');
    const shallow = createShallow({ dive: true });
    let wrapper, props;

    beforeEach(() => {
        props = {
            loading: true
        }

        wrapper = shallow(<SernosConfig {...props} />)
    });

    describe('when loading with no error message', () => {

        it('should render paper container', () => {
            expect(getPaper()).toHaveLength(1);
        });

        it('should render loading spinner', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when loading with error message', () => {
        beforeEach(() => {
            wrapper.setProps({ errorMessage: 'an error has occurred' });
        });

        it('should render paper container', () => {
            expect(getPaper()).toHaveLength(1);
        });

        it('should render error message', () => {
            expect(getErrorCard()).toHaveLength(1);
        });
    });

    describe('when sernos cofig has loaded without error message', () => {
        beforeEach(() => {
            wrapper.setProps({
                sernosConfig: {
                    name: 'P1',
                    description: 'Serial Numbered In Pairs, One Box',
                    serialNumbered: 'Y',
                    numberOfSernos: 2,
                    numberOfBoxes: 1,
                    startOn: 'Even'
                },
                loading: false,
                errorMessage: null
            });
        });

        it('should render paper container', () => {
            expect(getPaper()).toHaveLength(1);
        });

        it('should render title', () => {
            expect(getTypography()).toHaveLength(1);
        });

        it('should render text fields', () => {
            expect(getTextFields()).toHaveLength(6);
        });

        it('should render buttons', () => {
            expect(getButtons()).toHaveLength(3);
        });
    });
});
