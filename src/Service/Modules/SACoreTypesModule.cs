namespace Linn.Products.Service.Modules
{
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class SaCoreTypesModule : NancyModule
    {
        private readonly IFacadeService<SaCoreType, int, SaCoreTypeResource> saCoreTypeService;

        public SaCoreTypesModule(IFacadeService<SaCoreType, int, SaCoreTypeResource> saCoreTypeService)
        {
            this.saCoreTypeService = saCoreTypeService;
            this.Get("/products/maint/sa-core-types", _ => this.GetSaCoreTypes());
            this.Get("/products/maint/sa-core-types/{coreType}", parameters => this.GetSaCoreType(parameters.coreType));
            this.Put("/products/maint/sa-core-types/{coreType}", parameters => this.UpdateSaCoreType(parameters.coreType));
            this.Post("/products/maint/sa-core-types", _ => this.AddSaCoreType());
        }

        private object GetSaCoreTypes()
        {
            var result = this.saCoreTypeService.GetAll();
            return this.Negotiate.WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSaCoreType(int coreType)
        {
            var result = this.saCoreTypeService.GetById(coreType);
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateSaCoreType(int coreType)
        {
            var resource = this.Bind<SaCoreTypeResource>();
            var result = this.saCoreTypeService.Update(coreType, resource);
            return this.Negotiate.WithModel(result).WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object AddSaCoreType()
        {
            var resource = this.Bind<SaCoreTypeResource>();
            var result = this.saCoreTypeService.Add(resource);
            return this.Negotiate.WithModel(result);
        }
    }
}