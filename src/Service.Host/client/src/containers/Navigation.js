import { connect } from 'react-redux';
import { withRouter } from 'react-router';

import Navbar from '../components/Navbar';
import initialiseOnMount from './common/initialiseOnMount';
import fetchMenu from '../actions/fetchMenuActions';
import config from '../config';
import { getMenuData, getMenuLoading } from '../selectors/menuSelectors';

const mapStateToProps = state => ({
    menu: getMenuData(state),
    loading: getMenuLoading(state),
    config
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
    )(initialiseOnMount(Navbar))
);
