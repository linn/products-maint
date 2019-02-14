import React from 'react';
import { Provider } from 'react-redux';
import { Route, Redirect, Switch } from 'react-router';
import { OidcProvider } from 'redux-oidc';
import { Router } from 'react-router-dom';
import CssBaseline from '@material-ui/core/CssBaseline';
import history from '../history';
import Navigation from '../containers/Navigation';
import MenuPage from '../containers/Menu';
import App from './App';
import Callback from '../containers/Callback';
import Tariff from '../containers/Tariff';
import Tariffs from '../containers/Tariffs';
import userManager from '../helpers/userManager';
import EanCodesOptions from '../containers/reportOptions/EanCodesOptions';
import EanCodes from '../containers/reports/EanCodes';
import CartonDetailsOptions from './reportOptions/CartonDetailsOptions';
import CartonDetails from '../containers/reports/CartonDetails';
import ProductRangesOptions from '../containers/reportOptions/ProductRangesOptions';
import ProductRanges from '../containers/reports/ProductRanges';
import StockTriggerLevelParts from '../containers/reports/StockTriggerLevelParts';
import StockTriggerLevelsByPart from '../containers/reports/StockTriggerLevelsByPart';
import SalesProductsByProductRange from '../containers/reports/SalesProductsByProductRange';
import CreateCartonType from '../containers/CreateCartonType';
import CartonType from '../containers/CartonType';
import SernosConfig from '../containers/sernosConfig/SernosConfig';
import SernosConfigs from '../containers/sernosConfig/SernosConfigs';
import CreateSernosConfig from '../containers/sernosConfig/CreateSernosConfig';
import SaCoreTypes from '../containers/saCoreType/SaCoreTypes';
import SaCoreType from '../containers/saCoreType/SaCoreType';
import CreateSaCoreType from '../containers/saCoreType/CreateSaCoreType';
import TypesOfSale from '../containers/typesOfSale/TypesOfSale';
import TypeOfSale from '../containers/typesOfSale/TypeOfSale';
import CreateTypeOfSale from '../containers/typesOfSale/CreateTypeOfSale';
import VatCodes from '../containers/vatCodes/VatCodes';
import VatCode from '../containers/vatCodes/VatCode';
import CreateVatCode from '../containers/vatCodes/CreateVatCode';
import 'typeface-roboto';
import SalesArticles from '../containers/salesArticles/SalesArticles';
import SalesArticle from '../containers/salesArticles/SalesArticle';

const Root = ({ store }) => (
    <div>
        <div style={{ paddingTop: '40px' }}>
            <Provider store={store}>
                <OidcProvider store={store} userManager={userManager}>
                    <Router history={history}>
                        <div>
                            <Navigation />
                            <CssBaseline />

                            <Route
                                path="/"
                                render={() => {
                                    document.title = 'Products';
                                    return false;
                                }}
                            />
                            <Route
                                exact
                                path="/"
                                render={() => <Redirect to="/products/maint" />}
                            />
                            <Route exact path="/products/maint" component={App} />
                            <Route
                                exact
                                path="/products/maint/signin-oidc-client"
                                component={Callback}
                            />

                            <Switch>
                                <Route
                                    exact
                                    path="/products/maint/tariffs/:id"
                                    component={Tariff}
                                />
                                <Route exact path="/products/maint/tariffs" component={Tariffs} />
                            </Switch>

                            <Route exact path="/products/reports" component={App} />
                            <Route
                                exact
                                path="/products/reports/sales-article-ean-codes"
                                component={EanCodesOptions}
                            />
                            <Route
                                exact
                                path="/products/reports/sales-article-ean-codes/report"
                                component={EanCodes}
                            />

                            <Route
                                exact
                                path="/products/reports/carton-details"
                                component={CartonDetailsOptions}
                            />
                            <Route
                                exact
                                path="/products/reports/carton-details/report"
                                component={CartonDetails}
                            />

                            <Switch>
                                <Route
                                    exact
                                    path="/products/maint/sales-articles"
                                    component={SalesArticles}
                                />
                                <Route
                                    exact
                                    path="/products/maint/sales-articles/:articleNumber"
                                    component={SalesArticle}
                                />
                            </Switch>

                            <Switch>
                                <Route
                                    exact
                                    path="/products/maint/carton-types/create"
                                    component={CreateCartonType}
                                />
                                <Route
                                    exact
                                    path="/products/maint/carton-types/:cartonTypeId"
                                    component={CartonType}
                                />
                                <Route
                                    exact
                                    path="/products/maint/carton-types"
                                    component={CartonDetails}
                                />
                            </Switch>

                            <Switch>
                                <Route
                                    exact
                                    path="/products/maint/sernos-configs"
                                    component={SernosConfigs}
                                />
                                <Route
                                    exact
                                    path="/products/maint/sernos-configs/create"
                                    component={CreateSernosConfig}
                                />
                                <Route
                                    exact
                                    path="/products/maint/sernos-configs/:sernosConfigId"
                                    component={SernosConfig}
                                />
                            </Switch>

                            <Switch>
                                <Route
                                    exact
                                    path="/products/maint/sa-core-types"
                                    component={SaCoreTypes}
                                />
                                <Route
                                    exact
                                    path="/products/maint/sa-core-types/create"
                                    component={CreateSaCoreType}
                                />
                                <Route
                                    exact
                                    path="/products/maint/sa-core-types/:coreType"
                                    component={SaCoreType}
                                />
                            </Switch>

                            <Switch>
                                <Route
                                    exact
                                    path="/products/maint/types-of-sale"
                                    component={TypesOfSale}
                                />
                                <Route
                                    exact
                                    path="/products/maint/types-of-sale/create"
                                    component={CreateTypeOfSale}
                                />
                                <Route
                                    exact
                                    path="/products/maint/types-of-sale/:typeOfSaleId"
                                    component={TypeOfSale}
                                />
                            </Switch>

                            <Switch>
                                <Route
                                    exact
                                    path="/products/maint/vat-codes"
                                    component={VatCodes}
                                />
                                <Route
                                    exact
                                    path="/products/maint/vat-codes/create"
                                    component={CreateVatCode}
                                />
                                <Route
                                    exact
                                    path="/products/maint/vat-codes/:vatCodeId"
                                    component={VatCode}
                                />
                            </Switch>

                            <Route
                                exact
                                path="/products/reports/product-ranges"
                                component={ProductRangesOptions}
                            />
                            <Route
                                exact
                                path="/products/reports/product-ranges/report"
                                component={ProductRanges}
                            />
                            <Route
                                exact
                                path="/products/reports/sales-products-by-product-range"
                                component={SalesProductsByProductRange}
                            />

                            <Route
                                exact
                                path="/products/reports/parts-at-location/:locationId"
                                component={StockTriggerLevelParts}
                            />
                            <Route
                                exact
                                path="/products/reports/stock-trigger-levels/:locationId/:partNumber"
                                component={StockTriggerLevelsByPart}
                            />
                            <Route exact path="/:sectionId" component={MenuPage} />
                        </div>
                    </Router>
                </OidcProvider>
            </Provider>{' '}
        </div>{' '}
    </div>
);

export default Root;
