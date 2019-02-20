namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public sealed class ProductRangeModule : NancyModule
    {
        private readonly IFacadeService<ProductRange, int, ProductRangeResource, ProductRangeUpdateResource> productRangeService;

        public ProductRangeModule(IFacadeService<ProductRange, int, ProductRangeResource, ProductRangeUpdateResource> productRangeService)
        {
            this.productRangeService = productRangeService;

            this.Get("/products/maint/product-ranges", _ => this.GetProductRanges());
            this.Get("/products/maint/product-ranges/{id}", parameters => this.GetProductRange(parameters.id));
            this.Put("/products/maint/product-ranges/{id}", parameters => this.UpdateProductRange(parameters.id));
        }

        private object GetProductRange(int id)
        {
            return this.Negotiate
                .WithModel(this.productRangeService.GetById(id))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateProductRange(int id)
        {
            this.RequiresAuthentication();
            var resource = this.Bind<ProductRangeUpdateResource>();

            var result = this.productRangeService.Update(id, resource);

            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetProductRanges()
        {
            return this.Negotiate
                .WithModel(this.productRangeService.GetAll())
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}