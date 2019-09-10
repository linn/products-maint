import React from 'react';
import { Provider } from 'react-redux';
import { Route, Redirect, Switch } from 'react-router';
import { OidcProvider } from 'redux-oidc';
import { Router } from 'react-router-dom';
import CssBaseline from '@material-ui/core/CssBaseline';
import PropTypes from 'prop-types';
import { Navigation, linnTheme } from '@linn-it/linn-form-components-library';
import { ThemeProvider } from '@material-ui/styles';
import history from '../history';
import App from './App';
import Callback from '../containers/Callback';
import Tariff from '../containers/tariffs/Tariff';
import Tariffs from '../containers/tariffs/Tariffs';
import CreateTariff from '../containers/tariffs/CreateTariff';
import userManager from '../helpers/userManager';
import EanCodesOptions from '../containers/reportOptions/EanCodesOptions';
import EanCodes from '../containers/reports/EanCodes';
import CartonDetailsOptions from './reportOptions/CartonDetailsOptions';
import CartonDetails from '../containers/reports/CartonDetails';
import ProductRangesOptions from '../containers/reportOptions/ProductRangesOptions';
import ProductRangesReport from '../containers/reports/ProductRanges';
import StockTriggerLevelParts from '../containers/reports/StockTriggerLevelParts';
import StockTriggerLevelsByPart from '../containers/reports/StockTriggerLevelsByPart';
import SalesProductsByProductRange from '../containers/reports/SalesProductsByProductRange';
import CreateCartonType from '../containers/CartonType/CreateCartonType';
import CartonType from '../containers/CartonType/CartonType';
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
import SaHoldStory from '../containers/saHoldStories/SaHoldStory';
import CloseSaHoldStory from '../containers/saHoldStories/CloseSaHoldStory';
import SalesArticleCoreTypesOptions from './reportOptions/SalesArticleCoreTypesOptions';
import SalesArticleCoreTypes from '../containers/reports/SalesArticleCoreTypes';
import SerialNumbers from '../containers/serialNumbers/SerialNumbers';
import CreateSerialNumber from '../containers/serialNumbers/CreateSerialNumber';
import SernosSequences from '../containers/sernosSequences/SernosSequences';
import SernosSequence from '../containers/sernosSequences/SernosSequence';
import CreateSernosSequence from '../containers/sernosSequences/CreateSernosSequence';
import ProductRanges from '../containers/productRanges/ProductRanges';
import ProductRange from '../containers/productRanges/ProductRange';
import CreateProductRange from '../containers/productRanges/CreateProductRange';
import CreateSaHoldStory from '../containers/saHoldStories/CreateSaHoldStory';
import ProductsOnHold from '../containers/reports/ProductsOnHold';
import SalesPackages from '../containers/salesPackages/SalesPackages';
import SalesPackage from '../containers/salesPackages/SalesPackage';
import CreateSalesPackage from '../containers/salesPackages/CreateSalesPackage';
import RootProducts from '../containers/rootProducts/RootProducts';
import RootProduct from '../containers/rootProducts/RootProduct';
import SernosUsedOnInvoice from '../containers/reports/SernosUsedOnInvoice';
import sernosUsedOnInvoiceOptions from '../containers/reportOptions/SernosUsedOnInvoiceOptions';
import SerialNumberTransactions from '../containers/serialNumberTransactions/SerialNumberTransactions';
import SerialNumberTransaction from '../containers/serialNumberTransactions/SerialNumberTransaction';
import CreateSerialNumberTransaction from '../containers/serialNumberTransactions/CreateSerialNumberTransaction';
import NotFound from './NotFound';
import SalesArticlesByTariff from '../containers/reports/SalesArticlesByTariff';
import OrdersByNominal from '../containers/reports/OrdersByNominalReport';
import OrdersByNominalReport from '../containers/reports/OrdersByNominalReport';

const Root = ({ store }) => (
    <div>
        <div style={{ paddingTop: '40px' }}>
            <Provider store={store}>
                <OidcProvider store={store} userManager={userManager}>
                    <ThemeProvider theme={linnTheme}>
                        <Router history={history}>
                            <div>
                                <Navigation />
                                <CssBaseline />

                                <Route
                                    exact
                                    path="/"
                                    render={() => <Redirect to="/products/maint" />}
                                />

                                <Route
                                    exact
                                    path="/products"
                                    render={() => <Redirect to="/products/maint" />}
                                />

                                <Route
                                    path="/"
                                    render={() => {
                                        document.title = 'Products';
                                        return false;
                                    }}
                                />

                                <Switch>
                                    <Route exact path="/products/maint" component={App} />

                                    <Route
                                        exact
                                        path="/products/maint/signin-oidc-client"
                                        component={Callback}
                                    />

                                    <Route
                                        exact
                                        path="/products/maint/tariffs/create"
                                        component={CreateTariff}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/tariffs/:id"
                                        component={Tariff}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/tariffs"
                                        component={Tariffs}
                                    />

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

                                    <Route
                                        exact
                                        path="/products/reports/sales-article-core-types"
                                        component={SalesArticleCoreTypesOptions}
                                    />
                                    <Route
                                        exact
                                        path="/products/reports/sales-article-core-types/report"
                                        component={SalesArticleCoreTypes}
                                    />

                                    <Route
                                        exact
                                        path="/products/maint/serial-number-transactions"
                                        component={SerialNumberTransactions}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/serial-number-transactions/create"
                                        component={CreateSerialNumberTransaction}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/serial-number-transactions/:id"
                                        component={SerialNumberTransaction}
                                    />
                                    <Route
                                        exact
                                        path="/products/reports/sales-articles/get-by-tariff"
                                        component={SalesArticlesByTariff}
                                    />

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

                                    <Route
                                        exact
                                        path="/products/maint/product-ranges/create"
                                        component={CreateProductRange}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/product-ranges"
                                        component={ProductRanges}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/product-ranges/:id"
                                        component={ProductRange}
                                    />

                                    <Route
                                        exact
                                        path="/products/maint/sales-packages/create"
                                        component={CreateSalesPackage}
                                    />

                                    <Route
                                        exact
                                        path="/products/maint/sales-packages/:id"
                                        component={SalesPackage}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/sales-packages"
                                        component={SalesPackages}
                                    />

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

                                    <Route
                                        exact
                                        path="/products/maint/serial-numbers/create"
                                        component={CreateSerialNumber}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/serial-numbers"
                                        component={SerialNumbers}
                                    />

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

                                    <Route
                                        exact
                                        path="/products/maint/sernos-sequences"
                                        component={SernosSequences}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/sernos-sequences/create"
                                        component={CreateSernosSequence}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/sernos-sequences/:sequenceName"
                                        component={SernosSequence}
                                    />

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

                                    <Route
                                        exact
                                        path="/products/reports/product-ranges"
                                        component={ProductRangesOptions}
                                    />
                                    <Route
                                        exact
                                        path="/products/reports/product-ranges/report"
                                        component={ProductRangesReport}
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
                                    <Route
                                        exact
                                        path="/products/reports/sa-hold-stories/:holdStoryId"
                                        component={SaHoldStory}
                                    />
                                    <Route
                                        exact
                                        path="/products/reports/products-on-hold"
                                        component={ProductsOnHold}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/put-product-on-hold/:articleNumber"
                                        component={CreateSaHoldStory}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/close-hold-story/:holdStoryId"
                                        component={CloseSaHoldStory}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/root-products"
                                        component={RootProducts}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/root-products/:name"
                                        component={RootProduct}
                                    />
                                    <Route
                                        exact
                                        path="/products/maint/root-products/:name/put-on-hold"
                                        component={CreateSaHoldStory}
                                    />
                                    <Route
                                        exact
                                        path="/products/reports/sernos-used-on-invoice"
                                        component={sernosUsedOnInvoiceOptions}
                                    />
                                    <Route
                                        exact
                                        path="/products/reports/sernos-used-on-invoice/report"
                                        component={SernosUsedOnInvoice}
                                    />
                                    <Route
                                        exact
                                        path="/products/reports/orders-by-nominal"
                                        component={OrdersByNominalReport}
                                    />
                                    <Route component={NotFound} />
                                </Switch>
                            </div>
                        </Router>
                    </ThemeProvider>
                </OidcProvider>
            </Provider>
        </div>
    </div>
);

Root.propTypes = {
    store: PropTypes.shape({}).isRequired
};

export default Root;
