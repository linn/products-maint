import { connect } from 'react-redux';
import AmendSerialNumber from '../../components/AmendSerialNumber';
import initialiseOnMount from '../common/initialiseOnMount';
import serialNumberActions from '../../actions/serialNumberActions';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import serialNumberSelectors from '../../selectors/serialNumberSelectors';
import sernosNoteSelectors from '../../selectors/sernosNoteSelectors';
import salesArticleSelectors from '../../selectors/salesArticleSelectors';

const mapStateToProps = (state, { match }) => ({
    item: sernosNoteSelectors.getItem(state),
    sernosTRef: match.params.sernosTRef,
    sernosNumber: match.params.sernosNumber,
    editStatus: sernosNoteSelectors.getEditStatus(state),
    errorMessage: getSingleErrorMessage(state),
    serialNumber: serialNumberSelectors.getItem(state),
    salesArticle: salesArticleSelectors.getItem(state),

    serialNumberLoading: serialNumberSelectors.getLoading(state),
    salesArticleLoading: salesArticleSelectors.getLoading(state),
    sernosNoteLoading: sernosNoteSelectors.getLoading(state),

    snackbarVisible: serialNumberSelectors.getSnackbarVisible(state)
});

const initialise = ({ sernosTRef }) => dispatch => {
    dispatch(serialNumberActions.fetch(`${sernosTRef}`));
};

const mapDispatchToProps = {
    initialise,
    updateItem: serialNumberActions.update,
    setEditStatus: serialNumberActions.setEditStatus,
    setSnackbarVisible: serialNumberActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(AmendSerialNumber));
