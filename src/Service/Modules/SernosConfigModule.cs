namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class SernosConfigModule : NancyModule
    {
        private readonly IFacadeService<SernosConfig, string, SernosConfigResource, SernosConfigResource> sernosConfigService;

        private readonly IFacadeService<SernosTrans, string, SernosTransactionResource, SernosTransactionResource> sernosTransactionService;

        private readonly IFacadeService<SernosCount, string, SernosCountResource, SernosCountResource> sernosCountFacadeService;

        public SernosConfigModule(
            IFacadeService<SernosConfig, string, SernosConfigResource, SernosConfigResource> sernosConfigService,
            IFacadeService<SernosTrans, string, SernosTransactionResource, SernosTransactionResource> sernosTransactionService,
            IFacadeService<SernosCount, string, SernosCountResource, SernosCountResource> sernosCountFacadeService)
        {
            this.sernosConfigService = sernosConfigService;
            this.sernosTransactionService = sernosTransactionService;
            this.sernosCountFacadeService = sernosCountFacadeService;
            this.Get("/products/maint/sernos-configs/{name}", parameters => this.GetSernosConfigByName(parameters.name));
            this.Get("/products/maint/sernos-configs/", _ => this.GetSernosConfigs());
            this.Put("/products/maint/sernos-configs/{name}", parameters => this.UpdateSernosConfig(parameters.name));
            this.Post("/products/maint/sernos-configs", _ => this.AddSernosConfig());

            this.Get("/products/maint/serial-number-transactions", _ => this.GetTransCodes());
            this.Get("/products/maint/serial-number-transactions/{pageNumber}/{pageSize}", parameters => this.GetTransCodes(parameters.pageNumber, parameters.pageSize));
            this.Get("/products/maint/serial-number-transactions/{id}", parameters => this.GetTransCode(parameters.id));
            this.Post("/products/maint/serial-number-transactions", _ => this.AddTransCode());
            this.Put("/products/maint/serial-number-transactions/{id}", parameters => this.UpdateTransCode(parameters.id));

            this.Get("/products/maint/serial-number-counts", _ => this.GetSernosCounts());
        }

        private object GetSernosCounts()
        {
            var results = this.sernosCountFacadeService.GetAll();
            return this.Negotiate
                .WithModel(results)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetTransCodes()
        {
            var results = this.sernosTransactionService.GetAll();
            return this.Negotiate
                .WithModel(results)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetTransCodes(int pageNumber, int pageSize)
        {
            return this.Negotiate.WithModel(this.sernosTransactionService.GetAll(pageNumber, pageSize))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object UpdateTransCode(string transCode)
        {
            var resource = this.Bind<SernosTransactionResource>();

            var result = this.sernosTransactionService.Update(transCode, resource);
            return this.Negotiate.WithModel(result);
        }

        private object AddTransCode()
        {
            var resource = this.Bind<SernosTransactionResource>();

            var result = this.sernosTransactionService.Add(resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetTransCode(string transCode)
        {
            var result = this.sernosTransactionService.GetById(transCode);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSernosConfigs()
        {
            var result = this.sernosConfigService.GetAll();
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSernosConfigByName(string name)
        {
            var result = this.sernosConfigService.GetById(name);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object AddSernosConfig()
        {
            var resource = this.Bind<SernosConfigResource>();

            var result = this.sernosConfigService.Add(resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateSernosConfig(string name)
        {
            var resource = this.Bind<SernosConfigResource>();

            var result = this.sernosConfigService.Update(name, resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}