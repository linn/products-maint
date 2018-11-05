namespace Linn.Products.Service.Modules
{
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class SernosConfigModule : NancyModule
    {
        private readonly IFacadeService<SernosConfig, string, SernosConfigResource> sernosConfigService;

        public SernosConfigModule(IFacadeService<SernosConfig, string, SernosConfigResource> sernosConfigService)
        {
            this.sernosConfigService = sernosConfigService;
            this.Get("/products/maint/sernos-configs/{name}", parameters => this.GetSernosConfigByName(parameters.name));
            this.Put("/products/maint/sernos-configs/{name}", parameters => this.UpdateSernosConfig(parameters.name));
            this.Post("/products/maint/sernos-configs", _ => this.AddSernosConfig());
        }

        private object GetSernosConfigByName(string name)
        {
            var result = this.sernosConfigService.GetById(name);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object AddSernosConfig()
        {
            var resource = this.Bind<SernosConfigResource>();

            var result = this.sernosConfigService.Add(resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateSernosConfig(string name)
        {
            var resource = this.Bind<SernosConfigResource>();

            var result = this.sernosConfigService.Update(name, resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}