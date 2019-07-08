import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import CartonType from '../CartonType';

describe('<CartonType />', () => {
    let wrapper;
    let props;

    const getLoading = () => wrapper.find('Loading');
    const getInputFields = () => wrapper.find('InputField');
    const getButtons = () => wrapper.find('SaveBackCancelButtons');

    const shallow = createShallow({ dive: false });

    beforeEach(() => {
        props = {
            loading: true,
            editStatus: 'view',
            history: {}
        };

        wrapper = shallow(<CartonType {...props} />);
    });

    describe('when loading', () => {
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

        it('should render text fields', () => {
            expect(getInputFields()).toHaveLength(5);
        });

        it('should render buttons', () => {
            expect(getButtons()).toHaveLength(1);
        });
    });
});
