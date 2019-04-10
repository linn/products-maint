namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;

    using PagedList.Core;

    public class SalesPackagesResponseProcessor : JsonResponseProcessor<IEnumerable<SalesPackage>>
    {
        public SalesPackagesResponseProcessor(IResourceBuilder<IEnumerable<SalesPackage>> resourceBuilder)
            : base(resourceBuilder, "sales-packages", 1)
        {
        }
    }
}