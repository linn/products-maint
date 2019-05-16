namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Models;

    public class SalesArticleSerialNumberDetailsResponseProcessor : JsonResponseProcessor<SalesArticleSerialNumberDetails>
    {
        public SalesArticleSerialNumberDetailsResponseProcessor(IResourceBuilder<SalesArticleSerialNumberDetails> resourceBuilder)
            : base(resourceBuilder, "sales-article-serial-number-details", 1)
        {
        }
    }
}
