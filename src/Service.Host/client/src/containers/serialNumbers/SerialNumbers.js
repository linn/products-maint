import { connect } from 'react-redux';
import queryString from 'query-string';
import SerialNumbers from '../../components/SerialNumbers';
import initialiseOnMount from '../common/initialiseOnMount';
import serialNumbersActions from '../../actions/serialNumbersActions';
import sernosNoteActions from '../../actions/sernosNoteActions';
import salesArticlesSelectors from '../../selectors/salesArticlesSelectors';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import serialNumbersSelectors from '../../selectors/serialNumbersSelectors';
import sernosNotesSelectors from '../../selectors/sernosNotesSelectors';

const mapStateToProps = state => ({
    items: serialNumbersSelectors.getItems(state),
    loading: serialNumbersSelectors.getLoading(state),
    errorMessage: getSingleErrorMessage(state),
    salesArticles: salesArticlesSelectors.getItems(state),
    sernosNotes: sernosNotesSelectors.getItems(state)
});

const initialise = props => dispatch => {
    const { sernosNumber } = queryString.parse(props.location.search);

    if (sernosNumber) {
        dispatch(serialNumbersActions.fetchByQueryString('sernosNumber', sernosNumber));
    }
};

const mapDispatchToProps = {
    initialise,
    fetchItems: serialNumbersActions.fetchByQueryString,
    addSernosNote: sernosNoteActions.add,
    updateSernosNote: sernosNoteActions.update
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(SerialNumbers));
