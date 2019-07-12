import React from 'react';
import '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import { render, fireEvent, cleanup } from '../../../test-utils';
import Tariff from '../../tariffs/Tariff';

//afterEach(cleanup);

const addTariffMock = jest.fn();
const updateTariffMock = jest.fn();
const setEditStatusMock = jest.fn();
const tariff = {
    tariffCode: 'P1',
    description: 'tariff description for a black box',
    usTariffCode: 'code',
    duty: 1,
    dateInvalid: null
};

const defaultProps = {
    loading: false,
    itemId: 1,
    item: tariff,
    editStatus: 'view',
    addTariff: addTariffMock,
    updateTariff: updateTariffMock,
    setEditStatus: setEditStatusMock
};

describe('When Loading', () => {
    it('should display spinner', () => {
        const { getAllByRole } = render(<Tariff {...defaultProps} loading />);
        expect(getAllByRole('progressbar').length).toBeGreaterThan(0);
    });

    it('should not display form fields', () => {
        const { queryByRole } = render(<Tariff {...defaultProps} loading />);
        expect(queryByRole('input')).not.toBeInTheDocument();
    });
});

describe('When Snackbar Visible', () => {
    it('should render snackbar', () => {
        const { getByText } = render(<Tariff {...defaultProps} snackbarVisible />);
        const item = getByText('Save Successful');
        expect(item).toBeInTheDocument();
    });
});

describe('When viewing', () => {
    it('should not display spinner', () => {
        const { queryByRole } = render(<Tariff {...defaultProps} loading={false} />);
        expect(queryByRole('progressbar')).toBeNull();
    });

    test('Should display form fields', () => {
        const { getByDisplayValue } = render(<Tariff {...defaultProps} />);
        const item = getByDisplayValue('P1');
        expect(item).toBeInTheDocument();
    });

    test('Should have save button disabled', () => {
        const { getByText } = render(<Tariff {...defaultProps} />);
        const item = getByText('Save');
        expect(item.closest('button')).toHaveAttribute('disabled');
    });

    test('should change to edit mode on input', () => {
        const { getByDisplayValue } = render(<Tariff {...defaultProps} />);
        const input = getByDisplayValue('tariff description for a black box');
        fireEvent.change(input, {
            target: { value: 'new value' }
        });
        expect(setEditStatusMock).toHaveBeenCalledWith('edit');
    });
});

describe('When Editing', () => {
    test('Should have save button enabled if input is Valid', () => {
        const { getByText } = render(<Tariff {...defaultProps} editStatus="edit" />);
        const item = getByText('Save');
        expect(item).toBeInTheDocument();
        expect(item.closest('button')).not.toHaveAttribute('disabled');
    });

    test('Should have save button disabled and no description', () => {
        const noDescription = {
            tariffCode: 'P1',
            description: '',
            usTariffCode: 'code',
            duty: 1,
            dateInvalid: null
        };

        const { getByText } = render(
            <Tariff {...defaultProps} item={noDescription} editStatus="edit" />
        );
        const item = getByText('Save');
        expect(item).toBeInTheDocument();
        expect(item.closest('button')).toHaveAttribute('disabled');
    });
});

describe('When updating', () => {
    test('Should call updateTariff and change set edit status to view', () => {
        const { getByText } = render(<Tariff {...defaultProps} editStatus="edit" />);
        fireEvent(
            getByText('Save'),
            new MouseEvent('click', {
                bubbles: true,
                cancelable: true
            })
        );
        expect(updateTariffMock).toHaveBeenCalledWith(1, tariff);
        expect(setEditStatusMock).toHaveBeenLastCalledWith('view');
    });
});

describe('When creating', () => {
    test('Should show help text and have save button disabled if no tariffCode', () => {
        const noTariffCode = {
            tariffCode: 'P1',
            description: '',
            usTariffCode: 'code',
            duty: 1,
            dateInvalid: null
        };
        const { getByText } = render(
            <Tariff {...defaultProps} item={noTariffCode} editStatus="create" />
        );
        const saveButton = getByText('Save');
        const helperText = getByText('This field is required');
        expect(helperText).toBeInTheDocument();
        expect(saveButton.closest('button')).toHaveAttribute('disabled');
    });

    test('Should call addTariff', () => {
        const { getByText, getAllByDisplayValue } = render(
            <Tariff {...defaultProps} item={null} editStatus="create" />
        );

        // we need to fill the inputs before we are allowed to click save
        const inputs = getAllByDisplayValue('');
        inputs.forEach(input => {
            fireEvent.change(input, {
                target: { value: 'new value' }
            });
        });

        // now click save
        fireEvent(
            getByText('Save'),
            new MouseEvent('click', {
                bubbles: true,
                cancelable: true
            })
        );
        expect(addTariffMock).toHaveBeenCalled();
    });
});
