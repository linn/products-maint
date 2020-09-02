namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public interface ISalesArticleFacadeService : IFacadeService<SalesArticle, string, SalesArticleResource, SalesArticleResource>
    {
        IResult<ResponseModel<SalesArticlesReallocator>> Reallocate(int oldTariffId, int newTariffId, IEnumerable<string> privileges);
    }
}
