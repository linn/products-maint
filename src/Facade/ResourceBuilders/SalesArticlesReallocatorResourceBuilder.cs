namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;
    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SalesArticlesReallocatorResourceBuilder : IResourceBuilder<SalesArticlesReallocator>
    {
        public SalesArticlesReallocatorResource Build(SalesArticlesReallocator salesArticlesReallocator)
        {
            return new SalesArticlesReallocatorResource
            {
                OldTariffId = salesArticlesReallocator.OldTariffId,
                NewTariffId = salesArticlesReallocator.NewTariffId,
                Links = this.BuildLinks(salesArticlesReallocator).ToArray()
            };
        }

        object IResourceBuilder<SalesArticlesReallocator>.Build(SalesArticlesReallocator salesArticlesReallocatorResponseModel) => this.Build(salesArticlesReallocatorResponseModel);

        public string GetLocation(SalesArticlesReallocator salesArticleResponseModel)
        {
            return $"/products/maint/sales-articles-reallocate";
        }

        private IEnumerable<LinkResource> BuildLinks(SalesArticlesReallocator salesArticleResponseModel)
        {
            yield return new LinkResource("self", GetLocation(salesArticleResponseModel));
        }
    }
}
