namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class SACoreTypesModule : NancyModule
    {
        private readonly ISACoreTypeService sACoreTypeService;

        public SACoreTypesModule(ISACoreTypeService sACoreTypeService)
        {
            this.sACoreTypeService = sACoreTypeService;
            this.Get("/products/maint/core-types", _ => this.GetSACoreTypes());
            this.Get("/products/maint/core-types/{coreType}", parameters => this.GetSACoreType(parameters.coreType));
            this.Put("/products/maint/core-types/{coreType}", parameters => this.UpdateSACoreType(parameters.coreType));
            this.Post("/products/maint/core-types", _ => this.AddSACoreType());
        }

        private object GetSACoreTypes()
        {
            var result = this.sACoreTypeService.GetAllSACoreTypes();
            return this.Negotiate.WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSACoreType(int coreType)
        {
            var result = this.sACoreTypeService.GetSACoreType(coreType);
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateSACoreType(int coreType)
        {
            var resource = this.Bind<SACoreTypeResource>();
            var result = this.sACoreTypeService.UpdateSACoreType(coreType, resource);
            return this.Negotiate.WithModel(result);
        }

        private object AddSACoreType()
        {
            var resource = this.Bind<SACoreTypeResource>();
            var result = this.sACoreTypeService.AddSACoreType(resource);
            return this.Negotiate.WithModel(result);
        }
    }
}