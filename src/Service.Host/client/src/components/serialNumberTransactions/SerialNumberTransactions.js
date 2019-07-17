import React, { Fragment } from 'react';
import PropTypes from 'prop-types';
import {
    Loading,
    CreateButton,
    ErrorCard,
    Title,
    PaginatedTable,
    useTablePagination
} from '@linn-it/linn-form-components-library';
import Page from '../../containers/Page';

function SerialNumberTransactions({ page, loading, pageLoad, errorMessage, history }) {
    const [pageOptions, setPageOptions] = useTablePagination(pageLoad);

    const handleRowLinkClick = href => history.push(href);

    const columns = ['Trans Code', 'Description'];

    const rows = page.elements.map(el => ({
        transCode: el.transCode,
        description: el.description,
        links: el.links
    }));

    return (
        <Page>
            <Title text="Serial Number Transactions" />
            {errorMessage && <ErrorCard errorMessage={errorMessage} />}

            {loading || !page ? (
                <Loading />
            ) : (
                <Fragment>
                    <CreateButton createUrl="/products/maint/serial-number-transactions/create" />

                    <PaginatedTable
                        columns={columns}
                        handleRowLinkClick={handleRowLinkClick}
                        rows={rows}
                        pageOptions={pageOptions}
                        setPageOptions={setPageOptions}
                        totalItemCount={page.totalItemCount}
                    />
                </Fragment>
            )}
        </Page>
    );
}

SerialNumberTransactions.propTypes = {
    page: PropTypes.PropTypes.shape({ elements: PropTypes.array, totalItemCount: PropTypes.number })
        .isRequired,
    loading: PropTypes.bool.isRequired,
    pageLoad: PropTypes.func.isRequired,
    history: PropTypes.shape({ push: PropTypes.func }).isRequired,
    errorMessage: PropTypes.string
};

SerialNumberTransactions.defaultProps = {
    errorMessage: ''
};

export default SerialNumberTransactions;
