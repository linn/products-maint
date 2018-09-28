namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Service.Models;

    using Nancy;

    public sealed class CartonsModule : NancyModule
    {
        private readonly ICartonReportsService cartonReportsService;

        public CartonsModule(ICartonReportsService cartonReportsService)
        {
            this.cartonReportsService = cartonReportsService;

            this.Get("/products/reports/carton-details", _ => this.GetCartonDetails());
        }

        private object GetCartonDetails()
        {
            var results = this.cartonReportsService.GetCartonDetails();

            return this.Negotiate
                .WithModel(results)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}