import { connect } from 'react-redux';
import { withRouter } from 'react-router';

import Navbar from '../components/Navbar';
import initialiseOnMount from './common/initialiseOnMount';
import fetchMenu from '../actions/fetchMenuActions';
import { getMenuData, getMenuLoading } from '../selectors/menuSelectors';
import getUsername from '../selectors/userSelectors';

const mapStateToProps = state => ({
    menu: getMenuData(state),
    username: getUsername(state),
    loading: getMenuLoading(state)
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
