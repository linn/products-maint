namespace Linn.Products.Service.Modules
{
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Resources.Validators;
    using Linn.Products.Service.Extensions;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public sealed class SernosNoteModule : NancyModule
    {
        private readonly IFacadeService<SernosNote, int, SernosNoteCreateResource, SernosNoteResource> sernosNoteService;

        private readonly IAuthorisationService authorisationService;

        public SernosNoteModule(
            IFacadeService<SernosNote, int, SernosNoteCreateResource, SernosNoteResource> sernosNoteService, 
            IAuthorisationService authorisationService)
        {
            this.sernosNoteService = sernosNoteService;
            this.authorisationService = authorisationService;
            this.Get("/products/maint/serial-numbers/notes", _ => this.GetSernosNotes());
            this.Get("/products/maint/serial-numbers/notes/{id}", parameters => this.GetSernosNoteById(parameters.id));
            this.Post("/products/maint/serial-numbers/notes", _ => this.AddSernosNote());
            this.Put("/products/maint/serial-numbers/notes/{id}", parameters => this.UpdateSernosNote(parameters.id));
        }

        private object GetSernosNoteById(int id)
        {
            this.RequiresAuthentication();
            var privileges = this.Context.CurrentUser.GetPrivileges().ToList();

            var result = this.sernosNoteService.GetById(id, privileges);
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSernosNotes()
        {
            var resource = this.Bind<SernosNoteQueryResource>();
            var results = this.sernosNoteService.Search(resource.SernosNumber.ToString());
            return this.Negotiate.WithModel(results).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object AddSernosNote()
        {
            this.RequiresAuthentication();
            var privileges = this.Context.CurrentUser.GetPrivileges().ToList();

            if (!this.authorisationService.HasPermissionFor(AuthorisedAction.SerialNumberAdmin, privileges))
            {
                return this.Negotiate.WithModel(new UnauthorisedResult<ResponseModel<SerialNumber>>("You are not authorised to create or edit serial numbers"));
            }

            var resource = this.Bind<SernosNoteCreateResource>();
            var results = new SernosNoteCreateResourceValidator().Validate(resource);
            return results.IsValid
                       ? this.Negotiate.WithModel(this.sernosNoteService.Add(resource))
                           .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                       : this.Negotiate.WithModel(results).WithStatusCode(HttpStatusCode.BadRequest);
        }

        private object UpdateSernosNote(int id)
        {
            var privileges = this.Context.CurrentUser.GetPrivileges().ToList();

            if (!this.authorisationService.HasPermissionFor(AuthorisedAction.SerialNumberAdmin, privileges))
            {
                return this.Negotiate.WithModel(new UnauthorisedResult<ResponseModel<SerialNumber>>("You are not authorised to create or edit serial numbers"));
            }

            var resource = this.Bind<SernosNoteResource>();
            var results = new SernosNoteResourceValidator().Validate(resource);
            return results.IsValid
                       ? this.Negotiate.WithModel(this.sernosNoteService.Update(id, resource))
                           .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index")
                       : this.Negotiate.WithModel(results).WithStatusCode(HttpStatusCode.BadRequest);
        }
    }
}