import React from 'react';
import { shallow, mount } from 'enzyme';
import SernosConfig from '../SernosConfig';
import { Button, Input, Alert } from 'reactstrap';

describe('<SernosConfig />', () => {
    describe('View Sernos Config', () => {
        let updateSernosConfig = jest.fn(),
            addSernosConfig = jest.fn(),
            sernosConfig = { name: 'name1', description: 'd' },
            wrapper = shallow(<SernosConfig sernosConfig={sernosConfig} updateSernosConfig={updateSernosConfig} addSernosConfig={addSernosConfig} />);

        test('Should render view', () => {
            expect(wrapper.find(Input)).toHaveLength(0);
            expect(wrapper.find('#sernos-config-name').html()).toContain('name1');
        });

        test('Should render edit and back buttons', () => {
            expect(wrapper.find(Button)).toHaveLength(2);
            expect(wrapper.find('#edit-button')).toHaveLength(1);
            expect(wrapper.find('#back-button')).toHaveLength(1);
        });

        test('Should change state when edit button clicked', () => {
            const button = wrapper.find('#edit-button');
            button.simulate('click');

            expect(wrapper.state('editStatus')).toBe('edit');
        });

        describe('with errors', () => {
            wrapper = shallow(<SernosConfig sernosConfig={sernosConfig} updateSernosConfig={updateSernosConfig} addSernosConfig={addSernosConfig} errorMessage='We have an error' />);

            test('Should show Alert', () => {
                const alert = wrapper.find(Alert);

                expect(alert).toHaveLength(1);
                expect(alert.html()).toContain('We have an error');
            });
        });
    });

    describe('Edit Sernos Config', () => {
        let updateSernosConfig = jest.fn(),
            addSernosConfig = jest.fn(),
            sernosConfig = { name: 'name1', description: 'd' },
            wrapper = shallow(<SernosConfig sernosConfig={sernosConfig} updateSernosConfig={updateSernosConfig} addSernosConfig={addSernosConfig} sernosConfigId='name1' editStatus='edit' />);

        test('Should render edit', () => {
            expect(wrapper.find(Input)).toHaveLength(5);
            expect(wrapper.find('#sernos-config-name').html()).toContain('name1');
        });

        test('Should render save and cancel buttons', () => {
            expect(wrapper.find(Button)).toHaveLength(2);
            expect(wrapper.find('#save-button')).toHaveLength(1);
            expect(wrapper.find('#cancel-button')).toHaveLength(1);
        });

        test('Should update width', () => {
            const desc = wrapper.find(Input).at(0);
            desc.simulate('change', { target: { value: 'new desc' } });
            expect(wrapper.state('sernosConfig').description).toBe('new desc');
        });

        test('Should call update when save button clicked', () => {
            const button = wrapper.find('#save-button');
            button.simulate('click');

            expect(updateSernosConfig.mock.calls.length).toBe(1);
            expect(updateSernosConfig.mock.calls[0][0]).toBe('name1');
            expect(updateSernosConfig.mock.calls[0][1]).toEqual({ "description": "new desc", "name": "name1" });
        });
    });

    describe('Create Sernos Config', () => {
        let updateSernosConfig = jest.fn(),
            addSernosConfig = jest.fn(),
            sernosConfig = {},
            wrapper = shallow(<SernosConfig sernosConfig={sernosConfig} updateSernosConfig={updateSernosConfig} addSernosConfig={addSernosConfig} editStatus='create' />);

        test('Should render create', () => {
            expect(wrapper.find(Input)).toHaveLength(6);
        });

        test('Should render save and cancel buttons', () => {
            expect(wrapper.find(Button)).toHaveLength(2);
            expect(wrapper.find('#save-button')).toHaveLength(1);
            expect(wrapper.find('#cancel-button')).toHaveLength(1);
        });

        test('Should set fields', () => {
            const name = wrapper.find(Input).at(0),
                description = wrapper.find(Input).at(1);

            name.simulate('change', { target: { value: 'N' } });
            description.simulate('change', { target: { value: 'D' } });
           
            expect(wrapper.state('sernosConfig').name).toBe('N');
            expect(wrapper.state('sernosConfig').description).toBe('D');
        });

        test('Should call add when save button clicked', () => {
            const button = wrapper.find('#save-button');
            button.simulate('click');

            expect(addSernosConfig.mock.calls.length).toBe(1);
            expect(addSernosConfig.mock.calls[0][0]).toEqual({ 'description': 'D', 'name': 'N' });
        });
    });
});
