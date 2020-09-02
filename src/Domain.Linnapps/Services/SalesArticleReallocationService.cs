namespace Linn.Products.Domain.Linnapps.Services
{
    using System;
    using System.Linq;
    using Linn.Common.Domain.Exceptions;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;

    public class SalesArticleReallocationService : ISalesArticleReallocationService
    {
        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        public SalesArticleReallocationService(IRepository<SalesArticle, string> salesArticleRepository)
        {
            this.salesArticleRepository = salesArticleRepository;
        }

        SalesArticlesReallocator ISalesArticleReallocationService.Reallocate(int oldTariffId, int newTariffId)
        {
            if (oldTariffId == 0 || newTariffId == 0)
            {
                throw new DomainException("Tariff Id cannot be 0");
            }

            var articlesForReallocation =
                this.salesArticleRepository.FindAll().Where(x => x.TariffId == oldTariffId);

            var count = articlesForReallocation.Count();

            try
            {
                foreach (var salesArticle in articlesForReallocation)
                {
                    salesArticle.TariffId = newTariffId;
                }
            }
            catch (Exception ex)
            {
                throw new DomainException(
                    "An error has occurred when trying to reallocate the relevant sales articles");
            }

            return new SalesArticlesReallocator { OldTariffId = oldTariffId, NewTariffId = newTariffId, Count = count };
        }
    }
}
