import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import ProductRanges from '../../reports/ProductRanges';

describe('<ProductRanges />', () => {

    const getReportTable = () => wrapper.find('WithStyles(ReportTable)');
    const getLoading = () => wrapper.find('Loading');
    const shallow = createShallow({ dive: true });

    let reportData = { results: [] },
        options = {  includePhasedOut: false },
        wrapper;
    
        beforeEach(() => {
        wrapper = shallow(<ProductRanges options={options} loading={false} reportData={reportData} />)
    });

    test('Should render Table', () => {
        expect(getReportTable()).toHaveLength(1);
        expect(getLoading()).toHaveLength(0);
    });

    describe('loading', () => {
        beforeEach(() => {
            wrapper = shallow(<ProductRanges options={options} loading={true} reportData={reportData}/>);
        });

        test('Should render Table and Loader when loading', () => {
            expect(getReportTable()).toHaveLength(1);
            expect(getLoading()).toHaveLength(1);
        });

    });
});
