
namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    using PagedList.Core;

    public class SernosTransactionsPaginatedResourceBuilder : IResourceBuilder<IPagedList<SernosTrans>>
    {
        private readonly SernosTransactionResourceBuilder sernosTransactionResourceBuilder = new SernosTransactionResourceBuilder();

        public PaginatedResource<SernosTransactionResource> Build(IPagedList<SernosTrans> serialNumberTransactions)
        {
            return new PaginatedResource<SernosTransactionResource>
                       {
                           Elements = serialNumberTransactions.Select(a => this.sernosTransactionResourceBuilder.Build(a)).AsQueryable(),
                           PageCount = serialNumberTransactions.PageCount,
                           PageSize = serialNumberTransactions.PageSize,
                           PageNumber = serialNumberTransactions.PageNumber,
                           TotalItemCount = serialNumberTransactions.TotalItemCount,
                           HasNextPage = serialNumberTransactions.HasNextPage,
                           HasPreviousPage = serialNumberTransactions.HasPreviousPage,
                           IsFirstPage = serialNumberTransactions.IsFirstPage,
                           IsLastPage = serialNumberTransactions.IsLastPage,
                           FirstItemOnPage = serialNumberTransactions.FirstItemOnPage,
                           LastItemOnPage = serialNumberTransactions.LastItemOnPage
                       };
        }

        object IResourceBuilder<IPagedList<SernosTrans>>.Build(IPagedList<SernosTrans> serialNumberTransactions) =>
            this.Build(serialNumberTransactions);

        public string GetLocation(IPagedList<SernosTrans> serialNumberTransactions)
        {
            throw new NotImplementedException();
        }
    }
}
