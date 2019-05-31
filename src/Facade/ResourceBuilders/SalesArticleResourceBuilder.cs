namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class SalesArticleResourceBuilder : IResourceBuilder<ResponseModel<SalesArticle>>
    {
        private readonly IAuthorisationService authorisationService = new AuthorisationService();
  
        public SalesArticleResource Build(ResponseModel<SalesArticle> salesArticleResponseModel)
        {
            return new SalesArticleResource
                       {
                           Id = salesArticleResponseModel.Entity.ArticleNumber,
                           ArticleNumber = salesArticleResponseModel.Entity.ArticleNumber,
                           ArticleType = salesArticleResponseModel.Entity.ArticleType,
                           Description  = salesArticleResponseModel.Entity.InvoiceDescription,
                           CartonType = salesArticleResponseModel.Entity.CartonType,
                           ForecastType = salesArticleResponseModel.Entity.ForecastType,
                           ForecastFromDate = salesArticleResponseModel.Entity.ForecastFromDate?.ToString("o"),
                           ForecastToDate = salesArticleResponseModel.Entity.ForecastToDate?.ToString("o"),
                           PercentageOfRootProductSales = salesArticleResponseModel.Entity.PercentageOfRootProductSales,
                           EanCode = salesArticleResponseModel.Entity.EanCode,
                           SaDiscountFamily = salesArticleResponseModel.Entity.SaDiscountFamily,
                           PhaseInDate = salesArticleResponseModel.Entity.PhaseInDate?.ToString("o"),
                           PhaseOutDate = salesArticleResponseModel.Entity.PhaseOutDate?.ToString("o"),
                           TypeOfSale = salesArticleResponseModel.Entity.TypeOfSale,
                           PackingDescription = salesArticleResponseModel.Entity.PackingDescription,
                           TypeOfSerialNumber = salesArticleResponseModel.Entity.TypeOfSerialNumber,
                           Links = this.BuildLinks(salesArticleResponseModel).ToArray(),
                           OnHold = IsOnHold(salesArticleResponseModel),
                           RootProductOnHold = RootProductGroupIsOnHold(salesArticleResponseModel)
                       };
        }

        object IResourceBuilder<ResponseModel<SalesArticle>>.Build(ResponseModel<SalesArticle> salesArticleResponseModel) => this.Build(salesArticleResponseModel);

        public string GetLocation(ResponseModel<SalesArticle> salesArticleResponseModel)
        {
            return $"/products/maint/sales-articles/{Uri.EscapeDataString(salesArticleResponseModel.Entity.ArticleNumber)}";
        }

        private static bool IsOnHold(ResponseModel<SalesArticle> salesArticleResponseModel)
        {
            return salesArticleResponseModel.Entity.HoldStories?.Any(story => story.DateFinished == null) ?? false;
        }

        private static bool RootProductGroupIsOnHold(ResponseModel<SalesArticle> salesArticleResponseModel)
        {
            return salesArticleResponseModel.Entity.LastHoldStoryId != null && !IsOnHold(salesArticleResponseModel);
        }

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<SalesArticle> salesArticleResponseModel)
        {
            var openStory = salesArticleResponseModel.Entity.HoldStories?.FirstOrDefault(s => s.DateFinished == null);

            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(salesArticleResponseModel)
                             };

            if (openStory != null && this.authorisationService.CanPutProductOnOffHold(salesArticleResponseModel.Privileges))
            {
                yield return new LinkResource
                                 {
                                     Rel = "put-off-hold",
                                     Href = $"/products/maint/close-hold-story/{openStory.HoldStoryId}"
                                 };
            }
            else if (this.authorisationService.CanPutProductOnOffHold(salesArticleResponseModel.Privileges))
            {
                yield return new LinkResource
                                 {
                                     Rel = "put-on-hold",
                                     Href =
                                         $"/products/maint/put-product-on-hold/{Uri.EscapeDataString(salesArticleResponseModel.Entity.ArticleNumber)}"
                                 };
            }

            if (salesArticleResponseModel.Entity.SaCoreType != null)
            {
                yield return new LinkResource
                             {
                                 Rel = "sa-core-type",
                                 Href = $"/products/maint/sa-core-types/{salesArticleResponseModel.Entity.SaCoreType.CoreType}"
                             };
            }
        }
    }
}