namespace Linn.Products.Domain.Products.Labels
{
    public class ProductLabel : SalesPartLabel
    {
        public override T Accept<T>(ISalesPartLabelVisitor<T> visitor)
        {
            return visitor.VisitProductLabel(this);
        }
    }
}