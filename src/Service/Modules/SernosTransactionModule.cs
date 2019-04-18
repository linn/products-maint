namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;

    public class SernosTransactionModule : NancyModule
    {
        private readonly IFacadeService<SernosTransaction, string, SernosTransactionResource, SernosTransactionResource>
            sernosTransactionService;

        public SernosTransactionModule(IFacadeService<SernosTransaction, string, SernosTransactionResource, SernosTransactionResource> sernosTransactionService)
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
