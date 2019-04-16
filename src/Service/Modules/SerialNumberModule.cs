namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class SerialNumberModule : NancyModule
    {
        private readonly IFacadeService<SerialNumber, int, SerialNumberResource, SerialNumberResource> serialNumberService;

        public SerialNumberModule(IFacadeService<SerialNumber, int, SerialNumberResource, SerialNumberResource> serialNumberService)
        {
            this.serialNumberService = serialNumberService;
            this.Get("/products/maint/serial-numbers", _ => this.GetSerialNumbers());
            this.Get("/products/maint/serial-numbers/{sernosTRef}", parameters => this.GetSerialNumberByTRef(parameters.sernosTRef));
        }

        private object GetSerialNumberByTRef(int sernosTRef)
        {
            var result = this.serialNumberService.GetById(sernosTRef);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSerialNumbers()
        {
            var resource = this.Bind<SerialNumberQueryResource>();
            var result = this.serialNumberService.Search(resource.SernosNumber.ToString());
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}
