import React from 'react';
import { shallow } from 'enzyme';
import EanCodes from '../../reports/EanCodes';
import Table from '../../common/Table';
import { Loading } from '../../common/Loading';
import ExportButton from '../../common/ExportButton';

describe('<EanCodes />', () => {
    let reportData = {},
        config = { appRoot: '' },
        options = { cartonisedOnly: true, includePhasedOut: false },
        wrapper;
    beforeEach(() => {
        wrapper = shallow(<EanCodes options={options} loading={false} reportData={reportData} config={config} />);
    });

    test('Should render Table', () => {
        expect(wrapper.find(Table)).toHaveLength(1);
        expect(wrapper.find(Loading)).toHaveLength(0);
    });

    test('Should render export button', () => {
        expect(wrapper.find(ExportButton)).toHaveLength(1);
        expect(wrapper.find(ExportButton).props().href).toEqual('/products/reports/sales-article-ean-codes/export?includePhasedOut=false&cartonisedOnly=true');
    });

    describe('loading', () => {
        beforeEach(() => {
            wrapper = shallow(<EanCodes options={options} loading={true} reportData={reportData} config={config} />);
        });

        test('Should render Table and Loader when loading', () => {
            expect(wrapper.find(Table)).toHaveLength(1);
            expect(wrapper.find(Loading)).toHaveLength(1);
        });

    });
});
