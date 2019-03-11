namespace Linn.Products.Service.Reports
{
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Facade.Services;
    using Linn.Products.Service.Models;

    using Nancy;

    public sealed class ProductsOnHoldReportModule : NancyModule
    {
        private readonly IProductsOnHoldReportService productsOnHoldService;

        public ProductsOnHoldReportModule(IProductsOnHoldReportService productsOnHoldService)
        {
            this.productsOnHoldService = productsOnHoldService;
            this.Get("/products/reports/products-on-hold/", parameters => this.GetProductsOnHold());
        }

        private object GetProductsOnHold()
        {
            var results = this.productsOnHoldService.GetProductsOnHoldReport();
            return this.Negotiate.WithModel(results).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}