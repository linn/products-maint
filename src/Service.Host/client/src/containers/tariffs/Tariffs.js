import { connect } from 'react-redux';
import { fetchErrorSelectors } from '@linn-it/linn-form-components-library';
import { withRouter } from 'react-router';
import Tariffs from '../../components/tariffs/Tariffs';
import tariffsActions from '../../actions/tariffs';
import initialiseOnMount from '../common/initialiseOnMount';
import tariffsSelectors from '../../selectors/tariffsSelectors';

const mapStateToProps = state => ({
    items: tariffsSelectors.getSearchItems(state),
    loading: tariffsSelectors.getSearchLoading(state),
    errorMessage: fetchErrorSelectors(state)
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
