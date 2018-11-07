import React, { Component } from 'react';
import { Provider } from 'react-redux';
import { Route, Redirect, Switch } from 'react-router';
import { OidcProvider } from 'redux-oidc';
import { Router } from 'react-router-dom';
import history from '../history';
import Navigation from './Navigation';
import App from './App';
import Callback from '../containers/Callback';
import userManager from '../helpers/userManager';
import EanCodesOptions from '../containers/reportOptions/EanCodesOptions';
import EanCodes from '../containers/reports/EanCodes';
import CartonDetailsOptions from '../components/reportOptions/CartonDetailsOptions';
import CartonDetails from '../containers/reports/CartonDetails';
import ProductRangesOptions from '../containers/reportOptions/ProductRangesOptions';
import ProductRanges from '../containers/reports/ProductRanges';
import SalesProductsByProductRange from '../containers/reports/SalesProductsByProductRange';
import CreateCartonType from '../containers/CreateCartonType';
import CartonType from '../containers/CartonType';
import SernosConfig from '../containers/sernosConfig/SernosConfig';
import SernosConfigs from '../containers/sernosConfig/SernosConfigs';
import CreateSernosConfig from '../containers/sernosConfig/CreateSernosConfig';
import CssBaseline from '@material-ui/core/CssBaseline';

class Root extends Component {
    render() {
        const { store } = this.props;

        return (
            <Provider store={store}>
                <OidcProvider store={store} userManager={userManager}>
                    <Router history={history}>
                        <div>
                            <CssBaseline />
                            <Navigation />

                            <Route path="/" render={() => { document.title = 'Products'; return false; }} />
                            <Route exact path="/" render={() => <Redirect to="/products/maint" />} />
                            <Route exact path="/products/maint" component={App} />
                            <Route exact path="/products/reports" component={App} />
                            <Route exact path="/products/maint/signin-oidc-client" component={Callback} />

                            <Route exact path="/products/reports/sales-article-ean-codes" component={EanCodesOptions} />
                            <Route exact path="/products/reports/sales-article-ean-codes/report" component={EanCodes} />

                            <Route exact path="/products/reports/carton-details" component={CartonDetailsOptions} />
                            <Route exact path="/products/reports/carton-details/report" component={CartonDetails} />

                            <Switch>
                                <Route exact path="/products/maint/carton-types/create" component={CreateCartonType} />
                                <Route exact path="/products/maint/carton-types/:cartonTypeId" component={CartonType} />
                                <Route exact path="/products/maint/carton-types" component={CartonDetails} />
                            </Switch>

                            <Switch>
                                <Route exact path="/products/maint/sernos-configs" component={SernosConfigs} />
                                <Route exact path="/products/maint/sernos-configs/create" component={CreateSernosConfig} />
                                <Route exact path="/products/maint/sernos-configs/:sernosConfigId" component={SernosConfig} />
                            </Switch>

                            <Route exact path="/products/reports/product-ranges" component={ProductRangesOptions} />
                            <Route exact path="/products/reports/product-ranges/report" component={ProductRanges} />
                            <Route exact path="/products/reports/sales-products-by-product-range" component={SalesProductsByProductRange} />
                        </div>
                    </Router>
                </OidcProvider>
            </Provider>
        );

    }
}

export default Root;