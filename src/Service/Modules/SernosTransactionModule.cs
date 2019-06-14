namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    using Nancy;

    public sealed class SernosTransactionModule : NancyModule
    {
        private readonly IFacadeService<SernosTrans, string, SernosTransactionResource, SernosTransactionResource>
            sernosTransactionService;

        public SernosTransactionModule(IFacadeService<SernosTrans, string, SernosTransactionResource, SernosTransactionResource> sernosTransactionService)
        {
            this.sernosTransactionService = sernosTransactionService;
            this.Get("/products/maint/sernos-transactions", _ => this.GetSernosTransactions());
            this.Get("/products/maint/sernos-transactions/{transCode}", parameters => this.GetSernosTransactions(parameters.transCode));
        }

        private object GetSernosTransactions()
        {
            var results = this.sernosTransactionService.GetAll();
            return this.Negotiate.WithModel(results);
        }

        private object GetSernosTransactions(string transCode)
        {
            var result = this.sernosTransactionService.GetById(transCode);
            return this.Negotiate.WithModel(result);
        }
    }
}
