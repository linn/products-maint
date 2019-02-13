import { connect } from 'react-redux';
import Menu from '../components/Menu';
import initialiseOnMount from './common/initialiseOnMount';
import fetchMenu from '../actions/fetchMenuActions';
import config from '../config';
import { getMenuSection, getMenuLoading } from '../selectors/menuSelectors';

const getsectionId = ownProps => ownProps.match.params.sectionId;

const mapStateToProps = (state, ownProps) => ({
    section: getMenuSection(state, getsectionId(ownProps)),
    loading: getMenuLoading(state),
    config
});

const initialise = state => dispatch => {
    dispatch(fetchMenu(state));
};

const mapDispatchToProps = {
    initialise
};

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(initialiseOnMount(Menu));
