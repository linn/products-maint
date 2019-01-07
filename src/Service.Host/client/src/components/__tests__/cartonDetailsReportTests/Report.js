import React from 'react';
import CartonDetails from '../../reports/CartonDetails';
import { createShallow } from '@material-ui/core/test-utils';
import { Loading } from '../../common/Loading';

describe('<CartonDetails />', () => {
    const getReportTable = () => wrapper.find('WithStyles(ReportTable)');
    const getLoading = () => wrapper.find('Loading');
    const shallow = createShallow({ dive: true });

    let reportData = { results: [] },
        config = { appRoot: '' },
        wrapper;

    beforeEach(() => {
        wrapper = shallow(<CartonDetails loading={false} reportData={reportData} config={config} />);
    });

    test('Should render Table', () => {
        expect(getReportTable()).toHaveLength(1);
        expect(getLoading()).toHaveLength(0);
    });

    describe('loading', () => {

        beforeEach(() => {
            wrapper = shallow(<CartonDetails loading={true} reportData={reportData} config={config} />);
        });

        test('Should render Table and Loader when loading', () => {
            expect(getReportTable()).toHaveLength(1);
            expect(getLoading()).toHaveLength(1);
        });
    });
});
