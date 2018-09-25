import PropTypes from 'prop-types';

const headersType = PropTypes.shape({
    rowHeader: PropTypes.string.isRequired,
    columnHeaders: PropTypes.arrayOf(PropTypes.string).isRequired,
    varianceColumns: PropTypes.arrayOf(PropTypes.number).isRequired
});

const resultDetailsType = PropTypes.shape({
    rowTitle: PropTypes.string.isRequired,
    rowSortOrder: PropTypes.number,
    values: PropTypes.arrayOf(PropTypes.number).isRequired
});

export const reportResultType = PropTypes.shape({
    title: PropTypes.object.isRequired,
    resultType: PropTypes.string.isRequired,
    reportValueType: PropTypes.string.isRequired,
    headers: headersType.isRequired,
    results: PropTypes.arrayOf(resultDetailsType).isRequired,
    totals: resultDetailsType.isRequired
});
