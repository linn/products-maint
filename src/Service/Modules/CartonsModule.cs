namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Service.Models;

    using Nancy;

    public sealed class CartonsModule : NancyModule
    {
        private readonly ICartonReportsService cartonReportsService;

        private readonly ICartonTypeService cartonTypeService;

        public CartonsModule(ICartonReportsService cartonReportsService, ICartonTypeService cartonTypeService)
        {
            this.cartonReportsService = cartonReportsService;
            this.cartonTypeService = cartonTypeService;

            this.Get("/products/reports/carton-details", _ => this.GetCartonDetails());
            this.Get("/products/maint/carton-types/{name}", parameters => this.GetCartonType(parameters.name));
        }

        private object GetCartonType(string name)
        {
            var result = this.cartonTypeService.GetCartonType(name);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
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