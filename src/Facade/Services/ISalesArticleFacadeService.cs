namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public interface ISalesArticleFacadeService : IFacadeService<SalesArticle, string, SalesArticleResource, SalesArticleResource>
    {
        ResponseModel<SalesArticlesReallocator> Reallocate(int oldTariffId, int newTariffId);
    }
}