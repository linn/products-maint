namespace Linn.Products.Service.Modules
{
    using Facade.Services;
    using Nancy;

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
            var tariffs = this.tariffService.GetTariffs();

            return this.Negotiate.WithModel(tariffs);
        }
    }
}