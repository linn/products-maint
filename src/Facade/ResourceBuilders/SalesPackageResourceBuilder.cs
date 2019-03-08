namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Resources;

    public class SalesPackageResourceBuilder : IResourceBuilder<SalesPackage>
    {
        public SalesPackageResource Build(SalesPackage salesPackage)
        {
            var elements = salesPackage.Elements.Select(a => a.SalesPackageElement);
            return new SalesPackageResource
                       {
                           Id = salesPackage.Id,
                           SalesPackageId = salesPackage.SalesPackageId,
                           Description  = salesPackage.Description,
                           Elements = elements.Select(
                               a => new SalesPackageElementResource
                                        {
                                            ElementType = a.ElementType, Quantity = a.Quantity, Sequence = a.Sequence
                                        }),
                           Links = this.BuildLinks(salesPackage).ToArray()
                       };
        }

        object IResourceBuilder<SalesPackage>.Build(SalesPackage salesPackage) => this.Build(salesPackage);

        public string GetLocation(SalesPackage salesPackage)
        {
            return $"/products/maint/sales-packages/{salesPackage.Id}";
        }

        private IEnumerable<LinkResource> BuildLinks(SalesPackage salesPackage)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(salesPackage)
                             };
        }
    }
}