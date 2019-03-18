namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    public class SernosNoteModule : NancyModule
    {
        private readonly IFacadeService<SernosNote, int, SernosNoteResource, SernosNoteResource> sernosNoteService;

        public SernosNoteModule(IFacadeService<SernosNote, int, SernosNoteResource, SernosNoteResource> sernosNoteService)
        {
            this.sernosNoteService = sernosNoteService;
            this.Get("/products/maint/serial-numbers/{sernosTref}/notes", parameters => this.GetSernosNotesByTref(parameters.sernosTref));
            this.Get("/products/maint/serial-numbers/{sernosTref}/notes/{sernosNoteId}", parameters => this.GetSernosNote(parameters.sernosTref, parameters.sernosNoteId));
        }

        private object GetSernosNote(int sernosTref, int sernosNoteId)
        {
            var result = this.sernosNoteService.GetById(sernosNoteId);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSernosNotesByTref(int sernosTref)
        {
            throw new System.NotImplementedException();
        }
    }
}
