import { connect } from 'react-redux';
import Menu from '../components/Menu';
import { getMenuSection, getMenuLoading } from '../selectors/menuSelectors';

const getsectionId = ownProps => ownProps.match.params.sectionId;

const mapStateToProps = (state, ownProps) => ({
    section: getMenuSection(state, getsectionId(ownProps)),
    loading: getMenuLoading(state)
});

export default connect(mapStateToProps)(Menu);
