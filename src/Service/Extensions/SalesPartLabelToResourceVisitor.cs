namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products.Labels;
    using Linn.Products.Resources.ProductsResources;

    public class SalesPartLabelToResourceVisitor : ISalesPartLabelVisitor<SalesPartLabelResource>
    {
        public SalesPartLabelResource VisitBoxLabel(BoxLabel boxLabel)
        {
            return boxLabel.ToResource();
        }

        public SalesPartLabelResource VisitProductLabel(ProductLabel productLabel)
        {
            return productLabel.ToResource();
        }

        public SalesPartLabelResource VisitCartridgeLabel(CartridgeLabel cartridgeLabel)
        {
            return cartridgeLabel.ToResource();
        }
    }
}
