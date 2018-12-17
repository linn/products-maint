import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import SernosConfig from '../SernosConfig';
import { Typography, TextField, Paper, Button } from '@material-ui/core';
import MaterialCheckbox from '../common/MaterialCheckbox';
import MaterialDropdown from '../common/MaterialDropdown';
import MaterialLoading from '../common/MaterialLoading';
import ErrorCard from '../common/ErrorCard';


describe('<SernosConfig />', () => {
    const shallow = createShallow({ dive: true });

    describe('when sernos config is loading', () => {

        it('should show loading component', () => {
            const wrapper = shallow(<SernosConfig loading={true} />);
            expect(wrapper.find(Paper)).toHaveLength(1);
            expect(wrapper.find(MaterialLoading)).toHaveLength(1);
        });

        it('should show error message if present', () => {
            const wrapper = shallow(<SernosConfig loading={true} errorMessage={'error'} />);
            expect(wrapper.find(Paper)).toHaveLength(1);
            expect(wrapper.find(ErrorCard)).toHaveLength(1);
        });
    });

    describe('when sernos config has loaded', () => {

        const props = {
            sernosConfig: {
                name: 'sernos config',
                description: 'sernos description',
                serialNumbered: 'Y',
                numberOfSernos: 2,
                numberOfBoxes: 1,
                startOn: 'Even'
            },
            loading: false
        }

        const wrapper = shallow(<SernosConfig {...props} />);

        it('should render paper container', () => {
            expect(wrapper.find(Paper)).toHaveLength(1);
        });

        it('should render title', () => {
            expect(wrapper.find(Typography)).toHaveLength(1);
            expect(wrapper.find(Typography).html()).toContain('Sernos Config');
        });

        it('should render text fields', () => {
            expect(wrapper.find(TextField)).toHaveLength(4);
            expect(wrapper.find(TextField).first().html()).toContain('sernos config');
            expect(wrapper.find(TextField).at(1).html()).toContain('sernos description');
            expect(wrapper.find(TextField).at(2).html()).toContain('2');
            expect(wrapper.find(TextField).at(3).html()).toContain('1');
        });

        it('should render checkbox', () => {
            expect(wrapper.find(MaterialDropdown)).toHaveLength(1);
            expect(wrapper.find(MaterialDropdown).html()).toContain('Even');
        });

        it('should render dropdown', () => {
            expect(wrapper.find(MaterialCheckbox)).toHaveLength(1);
        });

        it('should render buttons', () => {
            expect(wrapper.find(Button)).toHaveLength(3);
        });
    });
});
