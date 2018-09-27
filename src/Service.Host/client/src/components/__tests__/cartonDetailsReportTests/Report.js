import React from 'react';
import { shallow } from 'enzyme';
import CartonDetails from '../../reports/CartonDetails';
import Table from '../../common/Table';
import { Loading } from '../../common/Loading';

describe('<CartonDetails />', () => {
    let reportData = {},
        config = { appRoot: '' },
        wrapper;

    test('Should render Table', () => {
        wrapper = shallow(<CartonDetails loading={false} reportData={reportData} config={config} />);
        expect(wrapper.find(Table)).toHaveLength(1);
        expect(wrapper.find(Loading)).toHaveLength(0);
    });

    describe('loading', () => {

        test('Should render Table and Loader when loading', () => {
            wrapper = shallow(<CartonDetails loading={true} reportData={reportData} config={config} />);
            expect(wrapper.find(Table)).toHaveLength(1);
            expect(wrapper.find(Loading)).toHaveLength(1);
        });

    });
});
