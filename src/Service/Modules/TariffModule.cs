namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class TariffModule : NancyModule
    {
        private readonly ITariffService tariffService;

        public TariffModule(ITariffService tariffService)
        {
            this.tariffService = tariffService;
            this.Get("/products/maint/tariffs", _ => this.GetTariffs());
            this.Get("/products/maint/tariffs/{id:int}", parameters => this.GetTariff(parameters.id));
            this.Put("/products/maint/tariffs/{id:int}", parameters => this.UpdateTariff(parameters.id));
            this.Post("/products/maint/tariffs", _ => this.AddTariff());
        }

        private object GetTariffs()
        {
            var resource = this.Bind<TariffQueryResource>();
            var tariffs = this.tariffService.GetTariffs(resource.SearchTerm);

            return this.Negotiate.WithModel(tariffs);
        }

        private object GetTariff(int id)
        {
            var tariff = this.tariffService.GetTariff(id);
            return this.Negotiate.WithModel(tariff);
        }

        private object UpdateTariff(int id)
        {
            var tariff = this.tariffService.GetTariff(id);
            return this.Negotiate.WithModel(tariff);
        }

        private object AddTariff()
        {
            var resource = this.Bind<TariffResource>();

            var result = this.tariffService.AddTariff(resource);

            return this.Negotiate.WithModel(result);
        }
    }
}