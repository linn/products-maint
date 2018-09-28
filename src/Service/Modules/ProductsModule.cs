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
    }
}