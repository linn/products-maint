namespace Linn.Products.Service.Modules
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public sealed class RootProductModule : NancyModule
    {
        private readonly IFacadeService<RootProduct, string, RootProductResource, RootProductResource>
            rootProductService;

        public RootProductModule(
            IFacadeService<RootProduct, string, RootProductResource, RootProductResource> rootProductService)
        {
            this.rootProductService = rootProductService;

            this.Get("/products/maint/root-products", _ => this.GetRootProducts());
            this.Get("/products/maint/root-products/{name*}", parameters => this.GetRootProduct(parameters.name));
        }

        private object GetRootProduct(string name)
        {
            var result = this.rootProductService.GetById(name);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetRootProducts()
        {
            var resource = this.Bind<QueryResource>();
            var rootProducts = string.IsNullOrEmpty(resource.SearchTerm)
                              ? this.rootProductService.GetAll()
                              : this.rootProductService.Search(resource.SearchTerm);

            return this.Negotiate.WithModel(rootProducts).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}
