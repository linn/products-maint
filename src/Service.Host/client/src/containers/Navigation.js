import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import Navigation from '../components/Navigation';
import initialiseOnMount from './common/initialiseOnMount';
import fetchMenu from '../actions/fetchMenuActions';
import { markNotificationSeen, fetchNews } from '../actions/newsActions';
import { getSections, getMenuLoading, getMyStuff } from '../selectors/menuSelectors';
import { getSeenNotifications, getUnseenNotifications } from '../selectors/newsSelectors';
import getUsername from '../selectors/userSelectors';

const mapStateToProps = state => ({
    sections: getSections(state),
    myStuff: getMyStuff(state),
    username: getUsername(state),
    loading: getMenuLoading(state),
    seenNotifications: getSeenNotifications(state),
    unseenNotifications: getUnseenNotifications(state)
});

const initialise = state => dispatch => {
    dispatch(fetchMenu(state));
    dispatch(fetchNews(state));
};

const mapDispatchToProps = {
    initialise,
    markNotificationSeen
};

export default withRouter(
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(initialiseOnMount(Navigation))
);
