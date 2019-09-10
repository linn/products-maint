import React from 'react';
import '@testing-library/jest-dom/extend-expect';
import { render, fireEvent, cleanup } from '../../../test-utils';
import TypeOfSale from '../../typesOfSale/TypeOfSale';

afterEach(cleanup);

const addMock = jest.fn();
const updateMock = jest.fn();
const setEditStatusMock = jest.fn();
const tos = {
    name: 'SACD',
    description: 'SALES OF LINN RECORDS SACDS',
    department: 'DUMMY',
    nominal: 'DUMMY',
    realSale: 'Y'
};

const defaultProps = {
    loading: false,
    itemId: 'SACD',
    item: tos,
    editStatus: 'view',
    addItem: addMock,
    updateItem: updateMock,
    setEditStatus: setEditStatusMock
};

describe('When Loading', () => {
    it('should display spinner', () => {
        const { getAllByRole } = render(<TypeOfSale {...defaultProps} loading />);
        expect(getAllByRole('progressbar').length).toBeGreaterThan(0);
    });

    it('should not display form fields', () => {
        const { queryByRole } = render(<TypeOfSale {...defaultProps} loading />);
        expect(queryByRole('input')).not.toBeInTheDocument();
    });
});

describe('When Snackbar Visible', () => {
    it('should render snackbar', () => {
        const { getByText } = render(<TypeOfSale {...defaultProps} snackbarVisible />);
        const item = getByText('Save Successful');
        expect(item).toBeInTheDocument();
    });
});

describe('When viewing', () => {
    it('should not display spinner', () => {
        const { queryByRole } = render(<TypeOfSale {...defaultProps} loading={false} />);
        expect(queryByRole('progressbar')).toBeNull();
    });

    test('Should display form fields', () => {
        const { getByDisplayValue } = render(<TypeOfSale {...defaultProps} />);
        const item = getByDisplayValue('SACD');
        expect(item).toBeInTheDocument();
    });

    test('Should have save button disabled', () => {
        const { getByText } = render(<TypeOfSale {...defaultProps} />);
        const item = getByText('Save');
        expect(item.closest('button')).toHaveAttribute('disabled');
    });

    test('should change to edit mode on input', () => {
        const { getByDisplayValue } = render(<TypeOfSale {...defaultProps} />);
        const input = getByDisplayValue('SALES OF LINN RECORDS SACDS');
        fireEvent.change(input, {
            target: { value: 'new value' }
        });
        expect(setEditStatusMock).toHaveBeenCalledWith('edit');
    });
});

describe('When Editing', () => {
    test('Should have save button enabled if input is Valid', () => {
        const { getByText } = render(<TypeOfSale {...defaultProps} editStatus="edit" />);
        const item = getByText('Save');
        expect(item).toBeInTheDocument();
        expect(item.closest('button')).not.toHaveAttribute('disabled');
    });

    test('Should have save button disabled and no description', () => {
        const noDescription = {
            ...tos,
            description: ''
        };

        const { getByText } = render(
            <TypeOfSale {...defaultProps} item={noDescription} editStatus="edit" />
        );
        const item = getByText('Save');
        expect(item).toBeInTheDocument();
        expect(item.closest('button')).toHaveAttribute('disabled');
    });
});

describe('When updating', () => {
    test('Should call updateItem and change set edit status to view', () => {
        const { getByText } = render(<TypeOfSale {...defaultProps} editStatus="edit" />);
        fireEvent(
            getByText('Save'),
            new MouseEvent('click', {
                bubbles: true,
                cancelable: true
            })
        );
        expect(updateMock).toHaveBeenCalledWith('SACD', tos);
        expect(setEditStatusMock).toHaveBeenLastCalledWith('view');
    });
});

describe('When creating', () => {
    test('Should have save button disabled if fields blank', () => {
        const { getByText } = render(
            <TypeOfSale {...defaultProps} item={{}} editStatus="create" />
        );
        const saveButton = getByText('Save');
        expect(saveButton.closest('button')).toHaveAttribute('disabled');
    });

    test('Should call addTypeOfSale when save clicked if data is valid', () => {
        const { getByText, getAllByDisplayValue } = render(
            <TypeOfSale {...defaultProps} item={{}} editStatus="create" />
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
        expect(addMock).toHaveBeenCalled();
    });
});
