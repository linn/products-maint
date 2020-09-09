namespace Linn.Products.Domain.Products.Labels
{
    public class CartridgeLabel : SalesPartLabel
    {
        public override T Accept<T>(ISalesPartLabelVisitor<T> visitor)
        {
            return visitor.VisitCartridgeLabel(this);
        }
    }
}