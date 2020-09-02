namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;
    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SalesArticlesReallocatorResourceBuilder : IResourceBuilder<ResponseModel<SalesArticlesReallocator>>
    {
        public SalesArticlesReallocatorResource Build(ResponseModel<SalesArticlesReallocator> salesArticlesReallocator)
        {
            return new SalesArticlesReallocatorResource
            {
                OldTariffId = salesArticlesReallocator.ResponseData.OldTariffId.ToString(),
                NewTariffId = salesArticlesReallocator.ResponseData.NewTariffId.ToString(),
                Links = this.BuildLinks(salesArticlesReallocator).ToArray()
            };
        }

        object IResourceBuilder<ResponseModel<SalesArticlesReallocator>>.Build(ResponseModel<SalesArticlesReallocator> salesArticlesReallocatorResponseModel) => this.Build(salesArticlesReallocatorResponseModel);

        public string GetLocation(ResponseModel<SalesArticlesReallocator> salesArticleResponseModel)
        {
            return $"/products/maint/sales-articles-reallocate";
        }

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<SalesArticlesReallocator> salesArticleResponseModel)
        {
            yield return new LinkResource("self", GetLocation(salesArticleResponseModel));
        }
    }
}
