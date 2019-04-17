namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Resources.Validators;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class SernosNoteModule : NancyModule
    {
        private readonly IFacadeService<SernosNote, int, SernosNoteCreateResource, SernosNoteResource> sernosNoteService;

        public SernosNoteModule(IFacadeService<SernosNote, int, SernosNoteCreateResource, SernosNoteResource> sernosNoteService)
        {
            this.sernosNoteService = sernosNoteService;
            this.Get("/products/maint/serial-numbers/notes", _ => this.GetSernosNotes());
            this.Get("/products/maint/serial-numbers/notes/{id}", parameters => this.GetSernosNoteById(parameters.id));
            this.Post("/products/maint/serial-numbers/notes", _ => this.AddSernosNote());
            this.Put("/products/maint/serial-numbers/notes/{id}", parameters => this.UpdateSernosNote(parameters.id));
        }

        private object GetSernosNoteById(int id)
        {
            var result = this.sernosNoteService.GetById(id);
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
            var resource = this.Bind<SernosNoteCreateResource>();

            var validator = new SernosNoteCreateResourceValidator();

            return validator.Validate(resource).IsValid
                       ? this.Negotiate.WithModel(this.sernosNoteService.Add(resource))
                           .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                       : this.Negotiate.WithModel(resource).WithStatusCode(HttpStatusCode.BadRequest);
        }

        private object UpdateSernosNote(int id)
        {
            var resource = this.Bind<SernosNoteResource>();

            var validator = new SernosNoteResourceValidator();

            return validator.Validate(resource).IsValid
                       ? this.Negotiate.WithModel(this.sernosNoteService.Update(id, resource))
                           .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index")
                       : this.Negotiate.WithModel(resource).WithStatusCode(HttpStatusCode.BadRequest);
        }
    }
}