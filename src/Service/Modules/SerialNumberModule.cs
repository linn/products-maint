namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Service.Models;

    using Nancy;

    public sealed class SerialNumberModule : NancyModule
    {
        private readonly ISerialNumberService serialNumberService;

        public SerialNumberModule(ISerialNumberService serialNumberService)
        {
            this.serialNumberService = serialNumberService;
            this.Get("/products/maint/serial-numbers/{sernosNumber}", parameters => this.GetSerialNumbersBySernosNumber(parameters.sernosNumber));
            this.Get("/products/maint/serial-numbers/{sernosNumber}/tref/{sernosTRef}", parameters => this.GetSerialNumberByTRef(parameters.sernosTRef));
        }

        private object GetSerialNumberByTRef(int sernosTRef)
        {
            var result = this.serialNumberService.GetByTRef(sernosTRef);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSerialNumbersBySernosNumber(int sernosNumber)
        {
            var result = this.serialNumberService.GetBySernosNumber(sernosNumber);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}
