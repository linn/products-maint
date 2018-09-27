import React, { Component } from 'react';
import { Provider } from 'react-redux';
import { Route, Redirect } from 'react-router';
import { OidcProvider } from 'redux-oidc';
import { ConnectedRouter as Router } from 'react-router-redux';
import history from '../history';
import Navigation from './Navigation';
import App from './App';
import Callback from '../containers/Callback';
import Tariffs from '../containers/Tariffs';
import userManager from '../helpers/userManager';
import EanCodesOptions from '../containers/reportOptions/EanCodesOptions';
import EanCodes from '../containers/reports/EanCodes';

class Root extends Component {
    render() {
        const { store } = this.props;

        return (
            <Provider store={store}>
                <OidcProvider store={store} userManager={userManager}>
                    <Router history={history}>
                        <div>
                            <Navigation />

                            <Route path="/" render={() => { document.title = 'Products'; return false; }} />
                            <Route exact path="/" render={() => <Redirect to="/products/maint" />} />
                            <Route exact path="/products/maint" component={App} />
                            <Route exact path="/products/maint/signin-oidc-client" component={Callback} />
                            <Route exact path="/products/maint/tariffs" component={Tariffs} />
                            <Route exact path="/products/reports" component={App} />							
                            <Route exact path="/products/reports/sales-article-ean-codes" component={EanCodesOptions} />
                            <Route exact path="/products/reports/sales-article-ean-codes/report" component={EanCodes} />
                        </div>
                    </Router>
                </OidcProvider>
            </Provider>
        );

    }
}

export default Root;