namespace Linn.Products.Service.Modules
{
    using Linn.Common.Resources;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Resources.Validators;
    using Linn.Products.Service.Extensions;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public sealed class SerialNumberModule : NancyModule
    {
        private readonly ISerialNumberFacadeService serialNumberService;

        public SerialNumberModule(ISerialNumberFacadeService serialNumberService)
        {
            this.serialNumberService = serialNumberService;
            this.Get("/products/maint/serial-numbers", _ => this.GetSerialNumbers());
            this.Get("/products/maint/serial-numbers/{sernosTRef}", parameters => this.GetSerialNumberByTRef(parameters.sernosTRef));
            this.Post("/products/maint/serial-numbers", _ => this.CreateSerialNumber());
        }

        private object CreateSerialNumber()
        {
            this.RequiresAuthentication();
            var resource = this.Bind<SerialNumberResource>();
            resource.Links = new[] { new LinkResource("entered-by", this.Context.CurrentUser.GetEmployeeUri()) };

            var results = new SerialNumberResourceValidator().Validate(resource);

            return results.IsValid
                       ? this.Negotiate.WithModel(this.serialNumberService.Add(resource))
                       : this.Negotiate.WithModel(results).WithStatusCode(HttpStatusCode.BadRequest);
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
