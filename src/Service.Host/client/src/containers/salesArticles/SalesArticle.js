import { connect } from 'react-redux';
import SalesArticle from '../../components/salesArticles/SalesArticle';
import { withRouter } from 'react-router'
import salesArticlesActions from '../../actions/salesArticles';
import initialiseOnMount from '../common/initialiseOnMount';
import salesArticlesSelectors from '../../selectors/salesArticlesSelectors';
import queryString from 'query-string';

const getArticle = ownProps => (ownProps.location.search ? queryString.parse(ownProps.location.search) : null);

const mapStateToProps = (state, ownProps) => ({
    item: { id: getArticle(ownProps).articleNumber }
});

const mapDispatchToProps = {
};

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(initialiseOnMount(SalesArticle)));
