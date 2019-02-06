import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { Breadcrumbs } from '@linn-it/linn-form-components-library';

const mapStateToProps = () => ({});

const mapDispatchToProps = {};

export default withRouter(
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(Breadcrumbs)
);
