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
                           Id = salesArticleResponseModel.ResponseData.ArticleNumber,
                           ArticleNumber = salesArticleResponseModel.ResponseData.ArticleNumber,
                           ArticleType = salesArticleResponseModel.ResponseData.ArticleType,
                           Description  = salesArticleResponseModel.ResponseData.InvoiceDescription,
                           CartonType = salesArticleResponseModel.ResponseData.CartonType,
                           ForecastType = salesArticleResponseModel.ResponseData.ForecastType,
                           ForecastFromDate = salesArticleResponseModel.ResponseData.ForecastFromDate?.ToString("o"),
                           ForecastToDate = salesArticleResponseModel.ResponseData.ForecastToDate?.ToString("o"),
                           PercentageOfRootProductSales = salesArticleResponseModel.ResponseData.PercentageOfRootProductSales,
                           EanCode = salesArticleResponseModel.ResponseData.EanCode,
                           SaDiscountFamily = salesArticleResponseModel.ResponseData.SaDiscountFamily,
                           PhaseInDate = salesArticleResponseModel.ResponseData.PhaseInDate?.ToString("o"),
                           PhaseOutDate = salesArticleResponseModel.ResponseData.PhaseOutDate?.ToString("o"),
                           TypeOfSale = salesArticleResponseModel.ResponseData.TypeOfSale,
                           PackingDescription = salesArticleResponseModel.ResponseData.PackingDescription,
                           TypeOfSerialNumber = salesArticleResponseModel.ResponseData.TypeOfSerialNumber,
                           Links = this.BuildLinks(salesArticleResponseModel).ToArray(),
                           OnHold = IsOnHold(salesArticleResponseModel),
                           RootProductOnHold = RootProductGroupIsOnHold(salesArticleResponseModel),
                           ProductIdOnChip = salesArticleResponseModel.ResponseData.ProductIdOnChip,
                           SmallLabelType = salesArticleResponseModel.ResponseData.SmallLabelType
                       };
        }

        object IResourceBuilder<ResponseModel<SalesArticle>>.Build(ResponseModel<SalesArticle> salesArticleResponseModel) => this.Build(salesArticleResponseModel);

        public string GetLocation(ResponseModel<SalesArticle> salesArticleResponseModel)
        {
            return $"/products/maint/sales-articles/{Uri.EscapeDataString(salesArticleResponseModel.ResponseData.ArticleNumber)}";
        }

        private static bool IsOnHold(ResponseModel<SalesArticle> salesArticleResponseModel)
        {
            return salesArticleResponseModel.ResponseData.HoldStories?.Any(story => story.DateFinished == null) ?? false;
        }

        private static bool RootProductGroupIsOnHold(ResponseModel<SalesArticle> salesArticleResponseModel)
        {
            return salesArticleResponseModel.ResponseData.LastHoldStoryId != null && !IsOnHold(salesArticleResponseModel);
        }

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<SalesArticle> salesArticleResponseModel)
        {
            var openStory = salesArticleResponseModel.ResponseData.HoldStories?.FirstOrDefault(s => s.DateFinished == null);

            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(salesArticleResponseModel)
                             };

            if (openStory != null && this.authorisationService.HasPermissionFor(AuthorisedAction.ProductHold, salesArticleResponseModel.Privileges))
            {
                yield return new LinkResource
                                 {
                                     Rel = "put-off-hold",
                                     Href = $"/products/maint/close-hold-story/{openStory.HoldStoryId}"
                                 };
            }
            else if (this.authorisationService.HasPermissionFor(AuthorisedAction.ProductHold, salesArticleResponseModel.Privileges))
            {
                yield return new LinkResource
                                 {
                                     Rel = "put-on-hold",
                                     Href =
                                         $"/products/maint/put-product-on-hold/{Uri.EscapeDataString(salesArticleResponseModel.ResponseData.ArticleNumber)}"
                                 };
            }

            if (salesArticleResponseModel.ResponseData.SaCoreType != null)
            {
                yield return new LinkResource
                             {
                                 Rel = "sa-core-type",
                                 Href = $"/products/maint/sa-core-types/{salesArticleResponseModel.ResponseData.SaCoreType.CoreType}"
                             };
            }
        }
    }
}
