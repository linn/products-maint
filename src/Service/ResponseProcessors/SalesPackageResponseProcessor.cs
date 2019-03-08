namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;

    public class SalesPackageResponseProcessor : JsonResponseProcessor<SalesPackage>
    {
        public SalesPackageResponseProcessor(IResourceBuilder<SalesPackage> resourceBuilder)
            : base(resourceBuilder, "sales-package", 1)
        {
        }
    }
}