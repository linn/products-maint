namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class SerialNumberModule : NancyModule
    {
        private readonly ISerialNumberService serialNumberService;

        public SerialNumberModule(ISerialNumberService serialNumberService)
        {
            this.serialNumberService = serialNumberService;
            this.Get("/products/maint/serial-numbers", _ => this.GetSerialNumbers());
            this.Get("/products/maint/serial-numbers/{sernosTRef}", parameters => this.GetSerialNumberByTRef(parameters.sernosTRef));
        }

        private object GetSerialNumberByTRef(int sernosTRef)
        {
            var result = this.serialNumberService.GetByTRef(sernosTRef);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSerialNumbers()
        {
            var resource = this.Bind<SerialNumberQueryResource>();
            var result = this.serialNumberService.GetBySernosNumber(resource.SernosNumber);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}
