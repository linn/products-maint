import React from 'react';
import '@testing-library/jest-dom/extend-expect';
import { cleanup } from '@testing-library/react';
import render from '../../../test-utils';
import Reallocator from '../../tariffs/Reallocator';

afterEach(cleanup);

const reallocateMock = jest.fn();
const searchForTariffMock = jest.fn();
const searchForOldTariffMock = jest.fn();
const clearTariffSearchMock = jest.fn();
const clearOldTariffSearchMock = jest.fn();

const defaultProps = {
    reallocate: reallocateMock,
    loading: false,
    tariffSearchLoading: false,
    searchForTariff: searchForTariffMock,
    clearTariffSearch: clearTariffSearchMock,
    oldTariffSearchLoading: false,
    searchForOldTariff: searchForOldTariffMock,
    clearOldTariffSearch: clearOldTariffSearchMock
};

describe('When Loading', () => {
    it('should display spinner', () => {
        const { getAllByRole } = render(<Reallocator {...defaultProps} loading />);
        expect(getAllByRole('progressbar').length).toBeGreaterThan(0);
    });

    it('should not display form fields', () => {
        const { queryByRole } = render(<Reallocator {...defaultProps} loading />);
        expect(queryByRole('input')).not.toBeInTheDocument();
    });
});

describe('When Snackbar Visible', () => {
    it('should render snackbar + tell user count of products reallocated', () => {
        const props = { ...defaultProps, item: { count: 10 } };
        const { getByText } = render(<Reallocator {...props} snackbarVisible />);
        const item = getByText('10 products reallocated!');
        expect(item).toBeInTheDocument();
    });
});

describe('When viewing', () => {
    it('should not display spinner', () => {
        const { queryByRole } = render(<Reallocator {...defaultProps} loading={false} />);
        expect(queryByRole('progressbar')).toBeNull();
    });

    test('Should display form fields and should have save button disabled', () => {
        const { getByText } = render(<Reallocator {...defaultProps} />);
        const item = getByText('Reallocate products');
        expect(item.closest('button')).toHaveAttribute('disabled');
    });
});
