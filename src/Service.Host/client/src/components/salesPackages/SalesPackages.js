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

function SalesPackages({ page, loading, pageLoad, pageSortedLoad, errorMessage, history }) {
    const [pageOptions, setPageOptions] = useTablePagination(pageLoad, pageSortedLoad);

    const handleRowLinkClick = href => history.push(href);

    const columns = { salesPackageId: 'Sales Package Id', description: 'Description' };

    const rows = page.elements.map(e => ({
        ...e,
        elements: e.elements.map(el => ({
            Type: el.elementType,
            Sequence: el.sequence,
            Quantity: el.quantity
        }))
    }));

    return (
        <Page>
            <Title text="Sales Packages" />
            {errorMessage && <ErrorCard errorMessage={errorMessage} />}

            {loading || !page ? (
                <Loading />
            ) : (
                <Fragment>
                    <CreateButton createUrl="/products/maint/sales-packages/create" />

                    <PaginatedTable
                        columns={columns}
                        handleRowLinkClick={handleRowLinkClick}
                        rows={rows}
                        sortable
                        expandable
                        pageOptions={pageOptions}
                        setPageOptions={setPageOptions}
                        totalItemCount={page.totalItemCount}
                    />
                </Fragment>
            )}
        </Page>
    );
}

SalesPackages.propTypes = {
    page: PropTypes.PropTypes.shape({ elements: PropTypes.array, totalItemCount: PropTypes.number })
        .isRequired,
    loading: PropTypes.bool.isRequired,
    pageLoad: PropTypes.func.isRequired,
    pageSortedLoad: PropTypes.func.isRequired,
    errorMessage: PropTypes.string,
    history: PropTypes.shape({ push: PropTypes.func }).isRequired
};

SalesPackages.defaultProps = {
    errorMessage: ''
};

export default SalesPackages;
