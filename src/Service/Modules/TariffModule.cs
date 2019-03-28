using Linn.Common.Facade;
using Linn.Products.Domain.Linnapps.Products;

namespace Linn.Products.Service.Modules
{
    using System.Collections.Generic;

    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;
    using Nancy;
    using Nancy.ModelBinding;

    public sealed class TariffModule : NancyModule
    {
        private readonly IFacadeService<Tariff, int, TariffResource, TariffResource> tariffService;

        private readonly ITariffRepository tariffRepository;

        public TariffModule(
            IFacadeService<Tariff, int, TariffResource, TariffResource> tariffService, 
            ITariffRepository tariffRepository)
        {
            this.tariffService = tariffService;
            this.tariffRepository = tariffRepository;

            this.Get("/products/maint/tariffs", _ => this.GetTariffs());
            this.Get("/products/maint/tariffs/{id:int}", parameters => this.GetTariff(parameters.id));
            this.Put("/products/maint/tariffs/{id:int}", parameters => this.UpdateTariff(parameters.id));
            this.Post("/products/maint/tariffs", _ => this.AddTariff());
        }

        private object GetTariffs()
        {
            var resource = this.Bind<QueryResource>();
            IResult<IEnumerable<Tariff>> tariffs;
            if (string.IsNullOrEmpty(resource.SearchTerm))
            {
                tariffs = this.tariffService.GetAll();
            }
            else
            {
                tariffs = new SuccessResult<IEnumerable<Tariff>>(this.tariffRepository.SearchTariffs(resource.SearchTerm));
            }

            return this.Negotiate.WithModel(tariffs)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetTariff(int id)
        {
            var tariff = this.tariffService.GetById(id);
            return this.Negotiate.WithModel(tariff)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateTariff(int id)
        {
            var resource = this.Bind<TariffResource>();
            var tariff = this.tariffService.Update(id, resource);
            return this.Negotiate.WithModel(tariff);
        }

        private object AddTariff()
        {
            var resource = this.Bind<TariffResource>();

            var result = this.tariffService.Add(resource);

            return this.Negotiate.WithModel(result);
        }
    }
}