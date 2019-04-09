﻿namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public sealed class SalesPackageModule : NancyModule
    {
        private readonly IFacadeService<SalesPackage, int, SalesPackageResource, SalesPackageResource> salesPackageService;

        public SalesPackageModule(
            IFacadeService<SalesPackage, int, SalesPackageResource, SalesPackageResource> salesPackageService)
        {
            this.salesPackageService = salesPackageService;

            this.Get("/products/maint/sales-packages", _ => this.GetSalesPackages());
            this.Get("/products/maint/sales-packages/{id}", parameters => this.GetSalesPackage(parameters.id));
            this.Get("/products/maint/sales-packages/{pageNumber}/{pageSize}", parameters => this.GetSalesPackages(parameters.pageNumber, parameters.pageSize));
            this.Put("/products/maint/sales-packages/{id}", parameters => this.UpdateSalesPackage(parameters.id));
            this.Post("/products/maint/sales-packages", _ => this.AddSalesPackage());
        }

        private object AddSalesPackage()
        {
            this.RequiresAuthentication();
            var resource = this.Bind<SalesPackageResource>();

            var result = this.salesPackageService.Add(resource);

            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateSalesPackage(int id)
        {
            this.RequiresAuthentication();
            var resource = this.Bind<SalesPackageResource>();

            var result = this.salesPackageService.Update(id, resource);

            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSalesPackages()
        {
            return this.Negotiate.WithModel(this.salesPackageService.GetAll())
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object GetSalesPackages(int pageNumber, int pageSize)
        {
            return this.Negotiate.WithModel(this.salesPackageService.GetAll(pageNumber, pageSize))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object GetSalesPackage(int id)
        {
            var result = this.salesPackageService.GetById(id);
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}