import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import Navigation from '../components/Navigation';
import initialiseOnMount from './common/initialiseOnMount';
import fetchMenu from '../actions/fetchMenuActions';
import { getSections, getMenuLoading, getMyStuff } from '../selectors/menuSelectors';
import getUsername from '../selectors/userSelectors';

const mapStateToProps = state => ({
    sections: getSections(state),
    myStuff: getMyStuff(state),
    username: getUsername(state),
    loading: getMenuLoading(state),
    notifications: [
        {
            created: '/Date(1557928928312)/',
            labels: [],
            content: 'Thank You!',
            title: 'Please complete our Healthy Working Lives survey.',
            links: [
                {
                    rel: 'self',
                    href:
                        '/news/**_please_complete_our_healthy_working_lives_survey.__thank_you!_**'
                }
            ]
        },
        {
            created: '/Date(1558082701584)/',
            labels: [],
            content:
                'Good luck to Metalwork’s Chris Lister on his forthcoming wedding to Robyn on Saturday 25th May.',
            title: 'Good Luck!',
            links: [{ rel: 'self', href: '/news/good_luck!' }]
        }
    ],
    //getNews(state),
});

const initialise = state => dispatch => {
    dispatch(fetchMenu(state));
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
