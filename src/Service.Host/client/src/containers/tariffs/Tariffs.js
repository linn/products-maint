import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import Tariffs from '../../components/tariffs/Tariffs';
import getSingleErrorMessage from '../../selectors/fetchErrorSelectors';
import tariffsActions from '../../actions/tariffs';
import initialiseOnMount from '../common/initialiseOnMount';
import tariffsSelectors from '../../selectors/tariffsSelectors';

const mapStateToProps = state => ({
    tariffs: tariffsSelectors.getSearchItems(state),
    loading: tariffsSelectors.getSearchLoading(state),
    errorMessage: getSingleErrorMessage(state)
});

const mapDispatchToProps = {
    fetchItems: tariffsActions.search,
    clearSearch: tariffsActions.clearSearch,
    classes: {}
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(withRouter(initialiseOnMount(Tariffs)));
