namespace Linn.Products.Service.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Linn.Products.Domain.Products.Labels;
    using Linn.Products.Resources.ProductsResources;

    public static class SalesPartLabelExtensions
    {
        private static readonly ISalesPartLabelVisitor<SalesPartLabelResource> Visitor = new SalesPartLabelToResourceVisitor();

        public static SalesPartLabelResource ToResource(this ISalesPartLabel label)
        {
            return label.Accept(Visitor);
        }

        public static IList<SalesPartLabelResource> ToResource(this IEnumerable<ISalesPartLabel> labels, int salesPartId)
        {
            return labels.Select(s =>
                {
                    var resource = s.ToResource();
                    resource.salesPartId = salesPartId;
                    return resource;
                }).ToList();
        }
    }
}
