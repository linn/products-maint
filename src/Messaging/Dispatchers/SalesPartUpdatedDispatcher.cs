namespace Linn.Products.Messaging.Dispatchers
{
    using System.Text;
    using Linn.Common.Messaging.RabbitMQ;
    using Linn.Products.Domain.Dispatchers;
    using Linn.Products.Domain.Products;
    using Linn.Products.Service.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class SalesPartUpdatedDispatcher : ISalesPartUpdatedDispatcher
    {
        private const string ContentType = "application/json";

        private readonly string routingKey = "products.sales-part.updated";

        private readonly IMessageDispatcher messageDispatcher;

        public SalesPartUpdatedDispatcher(IMessageDispatcher messageDispatcher)
        {
            this.messageDispatcher = messageDispatcher;
        }

        public void DispatchSalesPartUpdated(ProductSalesPart salesPart)
        {
            var resource = SalesPartExtensions.ToMessageResource(salesPart);

            var json = JsonConvert.SerializeObject(
                resource,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            var body = Encoding.UTF8.GetBytes(json);

            this.messageDispatcher.Dispatch(this.routingKey, body, ContentType);
        }
    }
}
