namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class ProductsModule : NancyModule
    {
        private readonly IProductsReportsService productsReportsService;

        public ProductsModule(IProductsReportsService productsReportsService)
        {
            this.productsReportsService = productsReportsService;

            this.Get("/products/reports/product-ranges", _ => this.GetProductRanges());
            this.Get("/products/reports/sales-products-by-product-range", _ => this.GetSalesProductByRange());
        }

        private object GetProductRanges()
        {
            var resource = this.Bind<IncludePhasedOutRequestResource>();
            var results = this.productsReportsService.GetProductRanges(resource.IncludePhasedOut);

            return this.Negotiate
                .WithModel(results)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSalesProductByRange()
        {
            var resource = this.Bind<SalesProductReportRequestResource>();
            var results = this.productsReportsService.GetSalesProductByProductRange(
                resource.ProductRangeId,
                resource.IncludePhasedOut);

            return this.Negotiate
                .WithModel(results)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}