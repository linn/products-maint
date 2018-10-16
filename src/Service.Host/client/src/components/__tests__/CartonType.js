import React from 'react';
import { shallow, mount } from 'enzyme';
import CartonType from '../CartonType';
import { Button, FormControl, Alert } from 'react-bootstrap';

describe('<CartonType />', () => {
    describe('View Carton', () => {
        let updateCartonType = jest.fn(),
            addCartonType = jest.fn(),
            cartonType = { name: 'name1', description: 'd', height: 1, width: 2, depth: 3 },
            wrapper = shallow(<CartonType cartonType={cartonType} updateCartonType={updateCartonType} addCartonType={addCartonType} />);

        test('Should render view', () => {
            expect(wrapper.find(FormControl)).toHaveLength(0);
            expect(wrapper.find('#carton-type-name').html()).toContain('name1');
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
            wrapper = shallow(<CartonType cartonType={cartonType} updateCartonType={updateCartonType} addCartonType={addCartonType} errorMessage='We have an error' />);

            test('Should show Alert', () => {
                const alert = wrapper.find(Alert);

                expect(alert).toHaveLength(1);
                expect(alert.html()).toContain('We have an error');
            });
        });
    });

    describe('Edit Carton', () => {
        let updateCartonType = jest.fn(),
            addCartonType = jest.fn(),
            cartonType = { name: 'name1', description: 'd', height: 1, width: 2, depth: 3 },
            wrapper = shallow(<CartonType cartonType={cartonType} updateCartonType={updateCartonType} addCartonType={addCartonType} cartonTypeId='name1' editStatus='edit' />);

        test('Should render edit', () => {
            expect(wrapper.find(FormControl)).toHaveLength(4);
            expect(wrapper.find('#carton-type-name').html()).toContain('name1');
        });

        test('Should render save and cancel buttons', () => {
            expect(wrapper.find(Button)).toHaveLength(2);
            expect(wrapper.find('#save-button')).toHaveLength(1);
            expect(wrapper.find('#cancel-button')).toHaveLength(1);
        });

        test('Should update width', () => {
            const widthInput = wrapper.find(FormControl).at(1);
            widthInput.simulate('change', { target: { value: 55 } });
            expect(wrapper.state('cartonType').width).toBe(55);
        });

        test('Should call update when save button clicked', () => {
            const button = wrapper.find('#save-button');
            button.simulate('click');

            expect(updateCartonType.mock.calls.length).toBe(1);
            expect(updateCartonType.mock.calls[0][0]).toBe('name1');
            expect(updateCartonType.mock.calls[0][1]).toEqual({ "depth": 3, "description": "d", "height": 1, "name": "name1", "width": 55 });
        });
    });

    describe('Create Carton', () => {
        let updateCartonType = jest.fn(),
            addCartonType = jest.fn(),
            cartonType = {},
            wrapper = shallow(<CartonType cartonType={cartonType} updateCartonType={updateCartonType} addCartonType={addCartonType} editStatus='create' />);

        test('Should render create', () => {
            expect(wrapper.find(FormControl)).toHaveLength(5);
        });

        test('Should render save and cancel buttons', () => {
            expect(wrapper.find(Button)).toHaveLength(2);
            expect(wrapper.find('#save-button')).toHaveLength(1);
            expect(wrapper.find('#cancel-button')).toHaveLength(1);
        });

        test('Should set fields', () => {
            const name = wrapper.find(FormControl).at(0),
                description = wrapper.find(FormControl).at(1),
                width = wrapper.find(FormControl).at(2),
                height = wrapper.find(FormControl).at(3),
                depth = wrapper.find(FormControl).at(4);

            name.simulate('change', { target: { value: 'N' } });
            description.simulate('change', { target: { value: 'D' } });
            width.simulate('change', { target: { value: 1 } });
            depth.simulate('change', { target: { value: 2 } });
            height.simulate('change', { target: { value: 3 } });
           
            expect(wrapper.state('cartonType').name).toBe('N');
            expect(wrapper.state('cartonType').description).toBe('D');
            expect(wrapper.state('cartonType').width).toBe(1);
            expect(wrapper.state('cartonType').depth).toBe(2);
            expect(wrapper.state('cartonType').height).toBe(3);
        });

        test('Should call add carton type when save button clicked', () => {
            const button = wrapper.find('#save-button');
            button.simulate('click');

            expect(addCartonType.mock.calls.length).toBe(1);
            expect(addCartonType.mock.calls[0][0]).toEqual({ "depth": 2, "description": 'D', "height": 3, "name": 'N', "width": 1 });
        });
    });
});
