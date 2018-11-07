import React from 'react';
import { shallow } from 'enzyme';
import EditTariff from '../EditTariff';
import { Button, FormControl, Alert } from 'react-bootstrap';
import { Loading } from '../common/Loading';

describe('<EditTariff />', () => {
    describe('Edit Tariff', () => {
        let updateTariff = jest.fn().mockResolvedValue({}),
            addTariff = jest.fn(),
            history = {
                push: jest.fn() 
            },
            tariff = {
                tariffCode: '123',
                description: 'Test Tariff',
                links: [
                    {
                        href: "/products/maint/tariffs/1",
                        rel: "self"
                    }]
            },
            wrapper = shallow(<EditTariff tariff={tariff} id="1" loading={false} updateTariff={updateTariff} addTariff={addTariff} editStatus="edit" history={history}/>);

        test('Should not be loading', () => {
            expect(wrapper.find(Loading)).toHaveLength(0);
        });

        test('Should render save and cancel buttons', () => {
            expect(wrapper.find(Button)).toHaveLength(2);
            expect(wrapper.find('#save-button')).toHaveLength(1);
            expect(wrapper.find('#cancel-button')).toHaveLength(1);
        });

        test('Should display edit', () => {
            expect(wrapper.find(FormControl)).toHaveLength(5);
            expect(wrapper.find(FormControl).at(0).html()).toContain("123");
            expect(wrapper.find(FormControl).at(1).html()).toContain("Test Tariff");
        });

        test('Should go back when cancel clicked', () => {
            const button = wrapper.find('#cancel-button');

            button.simulate('click');

            expect(history.push.mock.calls.length).toBe(1);
        });

        test('Should call update when save button clicked', () => {
            const button = wrapper.find('#save-button');
            button.simulate('click');

            expect(updateTariff.mock.calls.length).toBe(1);
            expect(updateTariff.mock.calls[0][0]).toBe("1");
            expect(updateTariff.mock.calls[0][1]).toEqual({
                "tariffCode": "123", "description": "Test Tariff",
                "links": [{
                    href: "/products/maint/tariffs/1",
                    rel: "self" }]});
        });

        describe('Add Tariff', () => {
            let updateTariff = jest.fn(),
                addTariff = jest.fn().mockResolvedValue({}),
                history = {
                    push: jest.fn()
                },
                tariff = {
                    tariffCode: '123',
                    description: 'Test Tariff'
                },
                wrapper = shallow(<EditTariff tariff={tariff} id="1" loading={false} updateTariff={updateTariff} addTariff={addTariff} editStatus="create" history={history} />);

            test('Should not be loading', () => {
                expect(wrapper.find(Loading)).toHaveLength(0);
            });

            test('Should render save and cancel buttons', () => {
                expect(wrapper.find(Button)).toHaveLength(2);
                expect(wrapper.find('#save-button')).toHaveLength(1);
                expect(wrapper.find('#cancel-button')).toHaveLength(1);
            });

            test('Should go back when cancel clicked', () => {
                const button = wrapper.find('#cancel-button');

                button.simulate('click');

                expect(history.push.mock.calls.length).toBe(1);
            });

            test('Should call add when save button clicked', () => {
                const button = wrapper.find('#save-button');
                button.simulate('click');

                expect(addTariff.mock.calls.length).toBe(1);
                expect(addTariff.mock.calls[0][0]).toEqual({
                    "tariffCode": "123",
                    "description": "Test Tariff"
                });
            });
        });
    });
});