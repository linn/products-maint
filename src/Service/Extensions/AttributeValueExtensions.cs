namespace Linn.Products.Service.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class AttributeValueExtensions
    {
        public static IList<AttributeValueResource> ToResource(this IEnumerable<AttributeValue> domains)
        {
            return domains.Select(d => new AttributeValueResource() { keyName = d.Key.Name, value = d.Value }).ToList();
        }
    }
}
