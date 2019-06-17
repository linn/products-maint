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

    public class RootProductResourceBuilder : IResourceBuilder<ResponseModel<RootProduct>>
    {
        private readonly IAuthorisationService authorisationService = new AuthorisationService();

        public RootProductResource Build(ResponseModel<RootProduct> rootProduct)
        {
            return new RootProductResource
                       {
                           Name = rootProduct.ResponseData.Name,
                           Description = rootProduct.ResponseData.Description,
                           Links = this.BuildLinks(rootProduct).ToArray(),
                           onHold = IsOnHold(rootProduct)
                       };
        }

        object IResourceBuilder<ResponseModel<RootProduct>>.Build(ResponseModel<RootProduct> r) => this.Build(r);

        public string GetLocation(ResponseModel<RootProduct> rootProduct)
        {
            return $"/products/maint/root-products/{Uri.EscapeDataString(rootProduct.ResponseData.Name)}";
        }

        private static bool IsOnHold(ResponseModel<RootProduct> rootProductResponseModel)
        {
            return rootProductResponseModel.ResponseData.HoldStories?.Any(story => story.DateFinished == null) ?? false;
        }

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<RootProduct> rootProductResponseModel)
        {
            var openStory = rootProductResponseModel.ResponseData.HoldStories?.FirstOrDefault(s => s.DateFinished == null);

            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(rootProductResponseModel)
                             };

            if (openStory != null && this.authorisationService.HasPermissionFor(AuthorisedAction.ProductHold, rootProductResponseModel.Privileges))
            {
                yield return new LinkResource
                                    {
                                        Rel = "put-off-hold",
                                        Href = $"/products/maint/close-hold-story/{openStory.HoldStoryId}"
                };
            }
            else if (this.authorisationService.HasPermissionFor(AuthorisedAction.ProductHold, rootProductResponseModel.Privileges))
            {
                yield return new LinkResource
                                 {
                                     Rel = "put-on-hold",
                                     Href = $"{this.GetLocation(rootProductResponseModel)}/put-on-hold"
                                 };
            }
        }
    }
}
