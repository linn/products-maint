﻿import { connect } from 'react-redux';
import vatCodeActions from '../../actions/vatCodeActions';
import VatCode from '../../components/VatCode';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';

const mapStateToProps = state => ({
    vatCode: {},
    editStatus: 'create',
    errorMessage: getSingleErrorMessage(state)
});

const mapDispatchToProps = {
    addItem: vatCodeActions.add,
    setEditStatus: vatCodeActions.setEditStatus
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(VatCode);
