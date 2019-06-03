namespace Linn.Products.Service.Modules
{
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
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
        private readonly IAuthorisationService authorisationService;

        public SerialNumberModule(
            ISerialNumberFacadeService serialNumberService,
            IAuthorisationService authorisationService)
        {
            this.serialNumberService = serialNumberService;
            this.authorisationService = authorisationService;
            this.Get("/products/maint/serial-numbers", _ => this.GetSerialNumbers());
            this.Get("/products/maint/serial-numbers/{sernosTRef}", parameters => this.GetSerialNumberByTRef(parameters.sernosTRef));
            this.Post("/products/maint/serial-numbers", _ => this.CreateSerialNumbers());
        }

        private object CreateSerialNumbers()
        {
            this.RequiresAuthentication();

            var privileges = this.Context.CurrentUser.GetPrivileges().ToList();

            if (!this.authorisationService.HasPermissionFor(AuthorisedAction.SerialNumberAdmin, privileges))
            {
                return this.Negotiate.WithModel(new UnauthorisedResult<ResponseModel<SerialNumber>>("You are not authorised to create or edit serial numbers"));
            }

            var resource = this.Bind<SerialNumberCreateResource>();
            resource.Links = new[] { new LinkResource("entered-by", this.Context.CurrentUser.GetEmployeeUri()) };            
            var results = new SerialNumberCreateResourceValidator().Validate(resource);

            // TODO, should I add privileges in here?
            var serialNumbers = this.serialNumberService.CreateSerialNumbers(resource);
            return results.IsValid
                       ? this.Negotiate.WithModel(serialNumbers)
                       : this.Negotiate.WithModel(results).WithStatusCode(HttpStatusCode.BadRequest);
        }

        private object GetSerialNumberByTRef(int sernosTRef)
        {
            var privileges = this.Context.CurrentUser.GetPrivileges();
            var result = this.serialNumberService.GetById(sernosTRef, privileges);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSerialNumbers()
        {
            // TODO use the new get for this
            var resource = this.Bind<SerialNumberQueryResource>();
            var result = this.serialNumberService.Search(resource.SernosNumber.ToString());
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}
