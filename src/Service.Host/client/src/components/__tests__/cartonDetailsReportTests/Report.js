import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import CartonDetails from '../../reports/CartonDetails';

describe('<CartonDetails />', () => {
    let wrapper;
    const getReportTable = () => wrapper.find('ReportTable');
    const getLoading = () => wrapper.find('Loading');
    const shallow = createShallow({ dive: false });

    const reportData = { results: [] };
    const config = { appRoot: '' };

    beforeEach(() => {
        wrapper = shallow(
            <CartonDetails loading={false} reportData={reportData} config={config} />
        );
    });

    test('Should render Table', () => {
        expect(getReportTable()).toHaveLength(1);
        expect(getLoading()).toHaveLength(0);
    });

    describe('loading', () => {
        beforeEach(() => {
            wrapper = shallow(<CartonDetails loading reportData={reportData} config={config} />);
        });

        test('Should render Table and Loader when loading', () => {
            expect(getReportTable()).toHaveLength(1);
            expect(getLoading()).toHaveLength(1);
        });
    });
});
