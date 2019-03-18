namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;

    public sealed class SerialNumberModule : NancyModule
    {
        private readonly IFacadeService<SerialNumber, int, SerialNumberResource, SerialNumberResource> sernosService;

        public SerialNumberModule(IFacadeService<SerialNumber, int, SerialNumberResource, SerialNumberResource> sernosService)
        {
            this.sernosService = sernosService;
            this.Get("/products/maint/serial-numbers/{id}", parameters => this.GetSernos(parameters.id));
        }

        private object GetSernos(int id)
        {
            // TODO actually getting this by tref now - need a list from sernos number
            var result = this.sernosService.GetById(id);
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}
