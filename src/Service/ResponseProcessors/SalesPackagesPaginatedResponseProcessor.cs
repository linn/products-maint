namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;

    using PagedList.Core;

    public class SalesPackagesPaginatedResponseProcessor : JsonResponseProcessor<IPagedList<SalesPackage>>
    {
        public SalesPackagesPaginatedResponseProcessor(IResourceBuilder<IPagedList<SalesPackage>> resourceBuilder)
            : base(resourceBuilder, "sales-packages", 1)
        {
        }
    }
}
