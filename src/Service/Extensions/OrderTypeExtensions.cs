namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class OrderTypeExtensions
    {
        public static OrderTypeResource ToResource(this OrderType orderType)
        {
            return new OrderTypeResource()
            {
                id = orderType.Id,
                description = orderType.Description,
                lookAheadDays = orderType.LookAheadDays,
                triggerLevel = orderType.TriggerLevel
            };
        }
    }
}
