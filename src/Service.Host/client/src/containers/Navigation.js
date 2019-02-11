import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import Navbar from '../components/Navbar';

const mapStateToProps = () => ({});

const mapDispatchToProps = {};

export default withRouter(
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(Navbar)
);
