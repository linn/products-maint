import React from 'react';
import { connect } from 'react-redux';
import { viewReport } from '../actions/eanCodeReport';
import { saveParameters } from '../actions/eanCodeReport';
import EanCodeReportOptions from '../components/reportOptions/EanCodeReportOptions';

const mapStateToProps = state => ({
    lastParameters: state.eanCodeReport.parameters
});

const mapDispatchToProps = {
    onViewReport: viewReport,
    saveParameters
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(EanCodeReportOptions);