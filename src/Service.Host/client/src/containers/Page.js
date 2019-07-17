import { connect } from 'react-redux';
import { withRouter } from 'react-router';
import { Page } from '@linn-it/linn-form-components-library';

const mapStateToProps = (state, props) => ({
    width: props.width
});

const mapDispatchToProps = {};

export default withRouter(
    connect(
        mapStateToProps,
        mapDispatchToProps
    )(Page)
);
