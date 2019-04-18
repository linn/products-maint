namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SernosTransResponseProcessor : JsonResponseProcessor<SernosTrans>
    {
        public SernosTransResponseProcessor(IResourceBuilder<SernosTrans> resourceBuilder)
            : base(resourceBuilder, "sernos-trans", 1)
        {
        }
    }
}
