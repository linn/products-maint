import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import { Typography, Card } from '@material-ui/core';
import { Error } from '@material-ui/icons';
import ErrorCard from '../ErrorCard';

describe('<ErrorCard />', () => {
    describe('when rendering', () => {
        const shallow = createShallow({ dive: true });

        const props = {
            errorMessage: 'there is an error'
        }

        it('should render card container', () => {
            const wrapper = shallow(<ErrorCard {...props} />);
            expect(wrapper.find(Card)).toHaveLength(1);
        });

        it('should render error icon', () => {
            const wrapper = shallow(<ErrorCard {...props} />);
            expect(wrapper.find(Error)).toHaveLength(1);
        });

        it('should render correct message', () => {
            const wrapper = shallow(<ErrorCard {...props} />);
            expect(wrapper.find(Typography)).toHaveLength(1);
            expect(wrapper.find(Typography).html()).toContain('there is an error');
        });

    });
});