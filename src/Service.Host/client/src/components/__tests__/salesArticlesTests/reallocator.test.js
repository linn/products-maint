import React from 'react';
import '@testing-library/jest-dom/extend-expect';
import { cleanup } from '@testing-library/react';
import render from '../../../test-utils';
import Reallocator from '../../salesArticles/Reallocator';

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
    it('should render snackbar', () => {
        const { getByText } = render(<Reallocator {...defaultProps} snackbarVisible />);
        const item = getByText('products reallocated!');
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
