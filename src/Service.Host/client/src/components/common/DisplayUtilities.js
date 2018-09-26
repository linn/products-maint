import React from 'react';
import { MarkdownModal } from './MarkdownModal'
import numeral from 'numeral'

export const format = (i, prefix, suffix, decimalPlaces) => {
    let decimalPlaceTemplate;

    if (!decimalPlaces || decimalPlaces === '0') {
        decimalPlaceTemplate = '';
    } else {
        decimalPlaceTemplate = '.' + Array(decimalPlaces + 1).join("0");
    }

    if (i || i === 0) {
        return (prefix ? prefix : '') + numeral(i).format(`0,0${decimalPlaceTemplate}`) + (suffix ? suffix : '');
    }

    return null;
}

export const formatTitle = (title, showTitle, loading, error, helpText) => {
    if (error) {
        return <strong>Error</strong>;
    }

    if (!showTitle) {
        return false;
    }

    let displayTitle;
    if (title && title.displayString) {
        displayTitle = title.displayString;
    }
    else {
        displayTitle = title;
    }

    if (loading) {
        return <h5>{`${displayTitle} (loading)`}</h5>;
    }

    return (
        <div className="row">
            <div className="col-xs-11">
                <h5>{setDrilldown(title)}</h5>
            </div>
            {helpText ? (
                <div className="col-xs-1">
                    <MarkdownModal helpText={helpText} />
                </div>) : ''}
        </div>);
}

export const setDrilldown = (item) => {
    let displayItem, href;
    if (item && item.hasOwnProperty('displayString')) {
        displayItem = item.displayString;
        if (item.drillDowns.length > 0) {
            href = item.drillDowns[0].href;
        }
    } else {
        displayItem = item;
    }

    if (href) {
        return <a className="link-display" href={href}>{displayItem}</a>;
    }

    return displayItem;
}

export const setValueDrilldown = (value) => {
    let displayItem;
    if (value && (value.displayValue || value.displayValue === 0)) {
        if (value.drillDowns && value.drillDowns.length > 0) {
            displayItem = <a className="link-value" href={value.drillDowns[0].href}>{format(value.displayValue, value.prefix, value.suffix, value.decimalPlaces)}</a>;
        } else {
            displayItem = format(value.displayValue, value.prefix, value.suffix, value.decimalPlaces);
        }
    } else {
        displayItem = null;
    }

    return displayItem;
}

export const setTextValueDrilldown = (value) => {
    let displayItem;
    if (value && value.textDisplayValue) {
        if (value.drillDowns && value.drillDowns.length > 0) {
            displayItem = <a className="link-value" href={value.drillDowns[0].href}>{value.textDisplayValue}</a>;
        } else {
            displayItem = value.textDisplayValue;
        }
    } else {
        displayItem = null;
    }

    return displayItem;
}

export const formatHeading = (title, showTitle, loading, error) => {
    if (!showTitle) {
        return false;
    }

    if (error) {
        return <strong>Error</strong>;
    }

    let displayTitle;
    if (title && title.displayString) {
        displayTitle = title.displayString;
    }
    else {
        displayTitle = title;
    }

    if (loading) {
        return <h5>{`${displayTitle} (loading)`}</h5>;
    }

    return <strong>{displayTitle}</strong>;
}

export const displayError = (message) => {
    return <h5 className="error-message">{message}</h5>;
}