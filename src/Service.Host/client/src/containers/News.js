import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import Notifications from '../components/News';
import initialiseOnMount from './common/functionalInitialiseOnMount';
import fetchNews from '../actions/newsActions';
import { getNews, getNewsLoading } from '../selectors/newsSelectors';

const mapStateToProps = state => ({
    news: {
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
        ]
    },
    //getNews(state),
    loading: getNewsLoading(state)
});

const initialise = () => dispatch => {
    dispatch(fetchNews());
};

const mapDispatchToProps = {
    initialise
};

export default withRouter(
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(initialiseOnMount(Notifications))
);
