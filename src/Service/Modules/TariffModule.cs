namespace Linn.Products.Service.Modules
{
    using Facade.Services;
    using Nancy;
    using Nancy.ModelBinding;
    using Resources;

    public sealed class TariffModule : NancyModule
    {
        private readonly ITariffService tariffService;

        public TariffModule(ITariffService tariffService)
        {
            this.tariffService = tariffService;
            this.Get("/products/maint/tariffs", _ => this.GetTariffs());
        }

        private object GetTariffs()
        {
            var resource = this.Bind<TariffQueryResource>();
            var tariffs = this.tariffService.GetTariffs(resource.SearchTerm);

            return this.Negotiate.WithModel(tariffs);
        }
    }
}