namespace Linn.Products.Service.Modules
{
    using System;

    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class SACoreTypesModule : NancyModule
    {
        private readonly IFacadeService<SACoreType, int, SACoreTypeResource> sACoreTypeService;

        public SACoreTypesModule(IFacadeService<SACoreType, int, SACoreTypeResource> sACoreTypeService)
        {
            this.sACoreTypeService = sACoreTypeService;
            this.Get("/products/maint/sa-core-types", _ => this.GetSACoreTypes());
            this.Get("/products/maint/sa-core-types/{coreType}", parameters => this.GetSACoreType(parameters.coreType));
            this.Put("/products/maint/sa-core-types/{coreType}", parameters => this.UpdateSACoreType(parameters.coreType));
            this.Post("/products/maint/sa-core-types", _ => this.AddSACoreType());
        }

        private object GetSACoreTypes()
        {
            var result = this.sACoreTypeService.GetAll();
            return this.Negotiate.WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSACoreType(int coreType)
        {
            var result = this.sACoreTypeService.GetById(coreType);
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateSACoreType(int coreType)
        {
            var resource = this.Bind<SACoreTypeResource>();
            var result = this.sACoreTypeService.Update(coreType, resource);
            return this.Negotiate.WithModel(result);
        }

        private object AddSACoreType()
        {
            var resource = this.Bind<SACoreTypeResource>();
            var result = this.sACoreTypeService.Add(resource);
            return this.Negotiate.WithModel(result);
        }
    }
}