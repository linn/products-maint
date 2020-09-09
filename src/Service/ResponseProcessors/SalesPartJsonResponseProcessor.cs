namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain;

    public class SalesPartJsonProcessor : JsonResponseProcessor<SalesPart>
    {
        public SalesPartJsonProcessor(IResourceBuilder<SalesPart> resourceBuilder)
            : base(resourceBuilder, "sales-part", 1)
        {
        }
    }
}
