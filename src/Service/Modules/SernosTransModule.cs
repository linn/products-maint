namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;

    public class SernosTransModule : NancyModule
    {
        private readonly IFacadeService<SernosTrans, string, SernosTransResource, SernosTransResource>
            sernosTransService;

        public SernosTransModule(IFacadeService<SernosTrans, string, SernosTransResource, SernosTransResource> sernosTransService)
        {
            this.sernosTransService = sernosTransService;
            this.Get("/products/maint/sernos-trans", _ => this.GetSernosTranses());
            this.Get("/products/maint/sernos-trans/{transCode}", parameters => this.GetSernosTrans(parameters.transCode));
        }

        private object GetSernosTranses()
        {
            var results = this.sernosTransService.GetAll();
            return this.Negotiate.WithModel(results);
        }

        private object GetSernosTrans(string transCode)
        {
            var result = this.sernosTransService.GetById(transCode);
            return this.Negotiate.WithModel(result);
        }
    }
}
