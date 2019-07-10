import React from 'react';
import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles';
import configureMockStore from 'redux-mock-store';
import { MemoryRouter } from 'react-router-dom';
import { createMount } from '@material-ui/core/test-utils';
import { Provider } from 'react-redux';
import Tariff from '../../tariffs/Tariff';

describe('<Tariff />', () => {
    let mount;
    const mockStore = configureMockStore();
    const store = mockStore({});

    const mountWithProps = props =>
        mount(
            <Provider store={store}>
                <MuiThemeProvider theme={createMuiTheme()}>
                    <MemoryRouter>
                        <Tariff {...props} />
                    </MemoryRouter>
                </MuiThemeProvider>
            </Provider>
        );

    let wrapper;

    const defaultProps = {
        loading: false,
        item: {
            tariffCode: 'P1',
            description: 'tariff description for a black box',
            duty: 1
        },
        editStatus: 'view'
    };

    beforeEach(() => {
        mount = createMount();
    });

    const getInputFields = () => wrapper.find('InputField');
    const getLoading = () => wrapper.find('Loading');
    const getErrorCard = () => wrapper.find('WithStyles(ErrorCard)');

    describe('when loaded', () => {
        beforeEach(() => {
            wrapper = mountWithProps(defaultProps);
        });

        it('should render Form Elements', () => {
            expect(getInputFields()).toHaveLength(5);
        });

        it('should have save button disabled', () => {
            const SaveButton = wrapper.find('ForwardRef(Button)').at(2);
            expect(SaveButton.props().disabled).toBe(true);
        });
    });

    describe('when loading', () => {
        beforeEach(() => {
            wrapper = mountWithProps({ ...defaultProps, loading: true });
        });

        it('should render loading Spinner', () => {
            expect(getLoading()).toHaveLength(1);
        });
    });

    describe('when there is an error', () => {
        beforeEach(() => {
            wrapper = mountWithProps({ ...defaultProps, errorMessage: 'some error' });
        });

        it('should render ErrorCard', () => {
            expect(getErrorCard()).toHaveLength(1);
        });
    });

    describe('when state changes', () => {
        beforeEach(() => {
            const setState = jest.fn();
            const useStateSpy = jest.spyOn(React, 'useState');
            useStateSpy.mockImplementation(init => [init, setState]);
        });
    });
});
