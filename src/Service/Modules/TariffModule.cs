namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;
    using Linn.Products.Resources.Validators;
    using Linn.Products.Service.Extensions;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public sealed class TariffModule : NancyModule
    {
        private readonly IFacadeService<Tariff, int, TariffResource, TariffResource> tariffService;

        public TariffModule(IFacadeService<Tariff, int, TariffResource, TariffResource> tariffService)
        {
            this.tariffService = tariffService;

            this.Get("/products/maint/tariffs", _ => this.GetTariffs());
            this.Get("/products/maint/tariffs/{id:int}", parameters => this.GetTariff(parameters.id));
            this.Put("/products/maint/tariffs/{id:int}", parameters => this.UpdateTariff(parameters.id));
            this.Post("/products/maint/tariffs", _ => this.AddTariff());
        }

        private object GetTariffs()
        {
            var resource = this.Bind<QueryResource>();
            var tariffs = string.IsNullOrEmpty(resource.SearchTerm)
                              ? this.tariffService.GetAll()
                              : this.tariffService.Search(resource.SearchTerm);

            return this.Negotiate.WithModel(tariffs).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetTariff(int id)
        {
            var tariff = this.tariffService.GetById(id);
            return this.Negotiate.WithModel(tariff).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateTariff(int id)
        {
            this.RequiresAuthentication();
            var employeeUri = this.Context.CurrentUser.GetEmployeeUri();

            var resource = this.Bind<TariffResource>();
            resource.Links = new[] { new LinkResource("changed-by", employeeUri) };
            var tariff = this.tariffService.Update(id, resource);
            return this.Negotiate.WithModel(tariff);
        }

        private object AddTariff()
        {
            this.RequiresAuthentication();
            var resource = this.Bind<TariffResource>();
            resource.Links = new[] { new LinkResource("entered-by", this.Context.CurrentUser.GetEmployeeUri()) };
            var results = new TariffValidator().Validate(resource);
            return results.IsValid
                       ? this.Negotiate.WithModel(this.tariffService.Add(resource))
                       : this.Negotiate.WithModel(results).WithStatusCode(HttpStatusCode.BadRequest);
        }
    }
}