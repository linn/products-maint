namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class SernosSequenceModule : NancyModule
    {
        private readonly IFacadeService<SernosSequence, string, SernosSequenceResource, SernosSequenceResource> sernosSequenceService;

        public SernosSequenceModule(IFacadeService<SernosSequence, string, SernosSequenceResource, SernosSequenceResource> sernosSequenceService)
        {
            this.sernosSequenceService = sernosSequenceService;
            this.Get("/products/maint/sernos-sequences/{sequenceName*}", parameters => this.GetSernosSequenceBySequenceName(parameters.sequenceName));
            this.Get("/products/maint/sernos-sequences/", _ => this.GetSernosSequences());
            this.Put("/products/maint/sernos-sequences/{sequenceName*}", parameters => this.UpdateSernosSequence(parameters.sequenceName));
            this.Post("/products/maint/sernos-sequences", _ => this.AddSernosSequence());
        }

        private object GetSernosSequences()
        {
            var result = this.sernosSequenceService.GetAll();
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSernosSequenceBySequenceName(string sequenceName)
        {
            var result = this.sernosSequenceService.GetById(sequenceName);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object AddSernosSequence()
        {
            var resource = this.Bind<SernosSequenceResource>();

            var result = this.sernosSequenceService.Add(resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateSernosSequence(string sequenceName)
        {
            var resource = this.Bind<SernosSequenceResource>();

            var result = this.sernosSequenceService.Update(sequenceName, resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}