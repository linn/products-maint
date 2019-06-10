namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Service.Extensions;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

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
            if (this.Context.CurrentUser != null)
            {
                return this.Negotiate
                    .WithModel(this.rootProductService.GetById(name, this.Context.CurrentUser.GetPrivileges()))
                    .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
            }

            return this.Negotiate.WithModel(this.rootProductService.GetById(name))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
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
