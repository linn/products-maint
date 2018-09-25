import React, { Component } from 'react';
import { reportResultType } from './PropTypes';
import { formatTitle, displayError, setDrilldown, setValueDrilldown, setTextValueDrilldown } from './DisplayUtilities';
import classnames from 'classnames';
import PropTypes from 'prop-types';

const getCellClassName = (isVarianceColumn, isTotalColumn, value, textValue, defaults = []) => classnames(
    defaults,
    { 'variance-positive': (isVarianceColumn && value > 0) },
    { 'variance-negative': (isVarianceColumn && value < 0) },
    { 'success total': (isTotalColumn) },
    { 'text-right': (!textValue) }
);

const getTableClassNames = (containsSubtotals, defaults = []) => classnames(
    defaults, 'table', 'table-condensed', 'table-bordered', 'small',
    { 'table-striped': !containsSubtotals }
);

const getTableRowClassNames = (rowType, containsSubtotals, defaults = []) => classnames(
    defaults,
    { 'subtotal-row active': containsSubtotals && rowType === 'Subtotal' },
    { 'success': rowType === 'Total' }
);

const getTableHeaderClassNames = (cellHeader, fixColumnWidth, isTextColumn, defaults = []) => classnames(
    defaults,
    { 'col-xs-1': fixColumnWidth && cellHeader },
    { 'col-xs-2': fixColumnWidth && !cellHeader },
    { 'text-right': !(isTextColumn) }
);

const Placeholder = ({ rows, columns }) => (
    <table className="table placeholder table-placeholder">
        <tbody>
            {
                [...Array(rows).keys()].map((row) => (
                    <tr key={row}>
                        {[...Array(columns).keys()].map((column) => (
                            <td key={column}></td>
                        ))}
                    </tr>
                ))
            }
        </tbody>
    </table>);

const Table = (
    {
        reportData,
        title,
        showTitle = true,
        showTotals = true,
        placeholderRows = 5,
        placeholderColumns = 6,
        containsSubtotals = false,
        fixColumnWidths = false,
        showRowTitles = true
    }) => (
        <div>
            {formatTitle(title, showTitle, !reportData, reportData && reportData.error, reportData ? reportData.reportHelpText : null)}
            {!reportData
                ? <Placeholder rows={placeholderRows} columns={placeholderColumns} /> :
                reportData.error ? displayError(reportData.message)
                    : <div>
                        <table className={getTableClassNames(containsSubtotals)}>
                            <tbody>
                                <tr key="headers">
                                    {showRowTitles ? (<th className={getTableHeaderClassNames(false, fixColumnWidths, '')}></th>) : null}
                                    {reportData.headers.columnHeaders
                                        .map((header, i) => (<th className={getTableHeaderClassNames(true, fixColumnWidths, reportData.headers.textColumns.includes(i), [])} key={i}>{header}</th>))}
                                </tr>

                                {reportData.results.map((item, j) => (
                                    <tr className={getTableRowClassNames(item.rowType, containsSubtotals, ['report-data-row'])} key={j} >
                                        {showRowTitles ? (<td className="single-line-field" data-tip={item.rowTitle.displayString}>{setDrilldown(item.rowTitle)}</td>) : null}
                                        {item.values
                                            .map((value, i) => (<td className={getCellClassName(reportData.headers.varianceColumns.includes(i) || reportData.headers.varianceRows.includes(j), reportData.headers.totalColumns.includes(i), value.displayValue, value.textDisplayValue, [])} key={i}>{setValueDrilldown(value)}{setTextValueDrilldown(value)}</td>))}
                                    </tr>
                                ))}

                                {showTotals
                                    ? (<tr className={getTableRowClassNames(reportData.totals.rowType, containsSubtotals, ['report-totals'])} key="totals">
                                        {showRowTitles ? (<td>{reportData.totals.rowTitle.displayString}</td>) : null}
                                        {reportData.totals.values
                                            .map((value, i) => (<td className={getCellClassName(reportData.headers.varianceColumns.includes(i), reportData.headers.totalColumns.includes(i), value.displayValue, value.textDisplayValue, ['total'])} key={i}>{setValueDrilldown(value)}</td>))}
                                    </tr>)
                                    : false
                                }
                            </tbody>
                        </table>
                    </div>
            }
        </div>
    );

Table.PropTypes = {
    reportData: reportResultType,
    title: PropTypes.object,
    showTitle: PropTypes.boolean,
    showTotals: PropTypes.boolean,
    placeholderRows: PropTypes.number,
    placeholderColumns: PropTypes.number
}

export default Table;
