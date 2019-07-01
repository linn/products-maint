import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import {
    Navigation,
    fetchMenu,
    markNotificationSeen,
    fetchNews,
    getSections,
    getMenuLoading,
    getMyStuff,
    getSeenNotifications,
    getUnseenNotifications
} from '@linn-it/linn-form-components-library';
import initialiseOnMount from './common/initialiseOnMount';
import getUsername from '../selectors/userSelectors';
import config from '../config';

const mapStateToProps = state => ({
    sections: getSections(state),
    myStuff: getMyStuff(state),
    username: getUsername(state),
    loading: getMenuLoading(state),
    seenNotifications: getSeenNotifications(state),
    unseenNotifications: getUnseenNotifications(state),
    authRoot: config.authorityUri
});

const initialise = state => dispatch => {
    dispatch(fetchMenu(state, config.proxyRoot));
    dispatch(fetchNews(state, config.proxyRoot));
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
