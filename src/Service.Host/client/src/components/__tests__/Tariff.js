import React from 'react';
import { shallow } from 'enzyme';
import Tariff from '../Tariff';
import { Button, FormControl } from 'react-bootstrap';
import { Loading } from '../common/Loading';

describe('<Tariff />', () => {
    describe('Tariff', () => {
        let tariff = {
                tariffCode: '123',
                description: 'Test Tariff',
                links: [
                    {
                        href: "/products/maint/tariffs/1",
                        rel: "self"
                    }]
            },
            wrapper = shallow(<Tariff tariff={tariff} id="1" loading={false} />);

        test('Should not be loading', () => {
            expect(wrapper.find(Loading)).toHaveLength(0);
        });

        test('Should render edit and back buttons', () => {
            expect(wrapper.find(Button)).toHaveLength(2);
            expect(wrapper.find('#edit-button')).toHaveLength(1);
            expect(wrapper.find('#back-button')).toHaveLength(1);
        });

        test('Should display details', () => {
            expect(wrapper.html()).toContain("123");
            expect(wrapper.html()).toContain("Test Tariff");
        });
    });
});