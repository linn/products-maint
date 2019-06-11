import { connect } from 'react-redux';
import { fetchErrorSelectors, initialiseOnMount } from '@linn-it/linn-form-components-library';
import VatCodes from '../../components/vatCodes/VatCodes';
import vatCodesActions from '../../actions/vatCodesActions';
import vatCodesSelectors from '../../selectors/vatCodesSelectors';
import getPrivileges from '../../selectors/getPrivileges';

const mapStateToProps = state => ({
    vatCodes: vatCodesSelectors.getItems(state),
    loading: vatCodesSelectors.getLoading(state),
    privileges: getPrivileges(state),
    errorMessage: fetchErrorSelectors(state)
});

const initialise = () => dispatch => {
    dispatch(vatCodesActions.fetch());
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(VatCodes));
