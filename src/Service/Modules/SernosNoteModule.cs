﻿namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public class SernosNoteModule : NancyModule
    {
        private readonly ISernosNoteService sernosNoteService;
        
        public SernosNoteModule(ISernosNoteService sernosNoteService)
        {
            this.sernosNoteService = sernosNoteService;
            this.Get("/products/maint/serial-numbers/notes", _ => this.GetSernosNote());
            this.Get("/products/maint/serial-numbers/notes/{id}", parameters => this.GetSernosNoteById(parameters.id));
            this.Post("/products/maint/serial-numbers/notes", _ => this.AddSernosNote());
            this.Put("/products/maint/serial-numbers/notes/{id}", parameters => this.UpdateSernosNote(parameters.id));
        }

        private object GetSernosNoteById(int id)
        {
            var result = this.sernosNoteService.GetSernosNoteById(id);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSernosNote()
        {
            var resource = this.Bind<SernosNoteQueryResource>();
            var result = this.sernosNoteService.GetSernosNote(
                resource.SernosGroup,
                resource.SernosNumber,
                resource.TransCode);

            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object AddSernosNote()
        {
            var resource = this.Bind<SernosNoteCreateResource>();

            var result = this.sernosNoteService.Add(resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
        
        private object UpdateSernosNote(int id)
        {
            var resource = this.Bind<SernosNoteResource>();

            var result = this.sernosNoteService.Update(id, resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}