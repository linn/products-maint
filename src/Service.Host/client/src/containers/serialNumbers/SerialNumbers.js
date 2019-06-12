import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import SerialNumbers from '../../components/SerialNumbers';
import initialiseOnMount from '../common/initialiseOnMount';
import serialNumbersActions from '../../actions/serialNumbersActions';
import sernosNoteActions from '../../actions/sernosNoteActions';
import salesArticlesSelectors from '../../selectors/salesArticlesSelectors';
import serialNumbersSelectors from '../../selectors/serialNumbersSelectors';
import sernosNotesSelectors from '../../selectors/sernosNotesSelectors';
import sernosNoteSelectors from '../../selectors/sernosNoteSelectors';
import getPrivileges from '../../selectors/getPrivileges';

const mapStateToProps = state => ({
    items: serialNumbersSelectors.getItems(state),
    loading: serialNumbersSelectors.getLoading(state),
    errorMessage: fetchErrorSelectors(state),
    privileges: getPrivileges(state),
    salesArticles: salesArticlesSelectors.getItems(state),
    sernosNotes: sernosNotesSelectors.getItems(state),
    snackbarVisible: sernosNoteSelectors.getSnackbarVisible(state),
    sernosNoteLoading: sernosNoteSelectors.getLoading(state),
    sernosNotesLoading: sernosNotesSelectors.getLoading(state)
});

const mapDispatchToProps = {
    fetchItems: serialNumbersActions.fetchByQueryString,
    addSernosNote: sernosNoteActions.add,
    updateSernosNote: sernosNoteActions.update,
    setSnackbarVisible: sernosNoteActions.setSnackbarVisible
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SerialNumbers));
