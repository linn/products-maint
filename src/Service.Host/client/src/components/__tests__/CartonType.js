import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import CartonType from '../CartonType';

describe('<CartonType />', () => {
    let wrapper;
    let props;

    const getPaper = () => wrapper.find('WithStyles(Paper)');
    const getLoading = () => wrapper.find('WithStyles(CircularLoading)');
    const getTypography = () => wrapper.find('WithStyles(Typography)');
    const getTextFields = () => wrapper.find('TextField');
    const getButtons = () => wrapper.find('WithStyles(Button)');

    const shallow = createShallow({ dive: true });

    beforeEach(() => {
        props = {
            loading: true
        };

        wrapper = shallow(<CartonType {...props} />);
    });

    describe('when loading', () => {
        it('should render paper container', () => {
            expect(getPaper()).toHaveLength(1);
        });

        it('should render loading spinner', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when carton type has loaded', () => {
        beforeEach(() => {
            wrapper.setProps({
                loading: false,
                cartonType: {
                    name: 'Carton 1',
                    numberOfSmallLabels: 1,
                    description: 'Carton description',
                    width: 3,
                    height: 2,
                    depth: 1,
                    links: [
                        {
                            rel: 'self',
                            href: '/products/maint/carton-types/1'
                        }
                    ]
                }
            });
        });

        it('should render paper container', () => {
            expect(getPaper()).toHaveLength(1);
        });

        it('should render title', () => {
            expect(getTypography()).toHaveLength(1);
        });

        it('should render text fields', () => {
            expect(getTextFields()).toHaveLength(5);
        });

        it('should render buttons', () => {
            expect(getButtons()).toHaveLength(3);
        });
    });
});
