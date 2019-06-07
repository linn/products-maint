import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import Navigation from '../components/Navigation';
import initialiseOnMount from './common/initialiseOnMount';
import fetchMenu from '../actions/fetchMenuActions';
import fetchNews from '../actions/newsActions';
import { getSections, getMenuLoading, getMyStuff } from '../selectors/menuSelectors';
import { getNews } from '../selectors/newsSelectors';
import getUsername from '../selectors/userSelectors';

const mapStateToProps = state => ({
    sections: getSections(state),
    myStuff: getMyStuff(state),
    username: getUsername(state),
    loading: getMenuLoading(state),
    notifications: getNews(state)
});

const initialise = state => dispatch => {
    dispatch(fetchMenu(state));
    dispatch(fetchNews(state));
};

const mapDispatchToProps = {
    initialise
};

export default withRouter(
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(initialiseOnMount(Navigation))
);
