import React, { Component } from 'react';

const initialiseOnUpdate = ComposedComponent => class extends Component {

    componentDidMount() {
        const { initialise } = this.props;
        if (initialise) {
            initialise(this.props, true);
        }
    }

    componentWillReceiveProps(nextProps) {
        const { initialise } = this.props;
        if (initialise) {
            initialise(nextProps);
        }
    }

    render() {
        return <ComposedComponent {...this.props} />;
    }
}

export default initialiseOnUpdate;