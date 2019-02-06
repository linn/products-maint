import React from 'react';
import { createShallow } from '@material-ui/core/test-utils';
import EanCodes from '../../reports/EanCodes';

describe('<EanCodes />', () => {
    let wrapper;
    const getReportTable = () => wrapper.find('WithStyles(ReportTable)');
    const getExportButton = () => wrapper.find('WithStyles(ExportButton)');
    const getLoading = () => wrapper.find('Loading');
    const shallow = createShallow({ dive: true });

    const reportData = { results: [] };
    const config = { appRoot: '' };
    const options = { cartonisedOnly: true, includePhasedOut: false };

    beforeEach(() => {
        wrapper = shallow(
            <EanCodes options={options} loading={false} reportData={reportData} config={config} />
        );
    });

    test('Should render Table', () => {
        expect(getReportTable()).toHaveLength(1);
        expect(getLoading()).toHaveLength(0);
    });

    test('Should render export button', () => {
        expect(getExportButton()).toHaveLength(1);
        expect(getExportButton().props().href).toEqual(
            '/products/reports/sales-article-ean-codes/export?includePhasedOut=false&cartonisedOnly=true'
        );
    });

    describe('loading', () => {
        beforeEach(() => {
            wrapper = shallow(<EanCodes options={options} loading={true} reportData={reportData} config={config} />);
        });

        test('Should render Table and Loader when loading', () => {
            expect(getReportTable()).toHaveLength(1);
            expect(getLoading()).toHaveLength(1);
        });
    });
});
