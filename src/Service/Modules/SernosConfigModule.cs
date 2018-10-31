namespace Linn.Products.Service.Modules
{
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;

    public sealed class SernosConfigModule : NancyModule
    {
        private readonly IFacadeService<SernosConfig, string, SernosConfigResource, SernosConfigUpdateResource> sernosConfigService;

        public SernosConfigModule(IFacadeService<SernosConfig, string, SernosConfigResource, SernosConfigUpdateResource> sernosConfigService)
        {
            this.sernosConfigService = sernosConfigService;
            this.Get("/products/reports/sernos-config/{name}", parameters => this.GetSernosConfigByName(parameters.name));
        }

        private object GetSernosConfigByName(string name)
        {
            var result = this.sernosConfigService.GetById(name);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}