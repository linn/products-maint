namespace Linn.Products.Domain.Products.Labels
{
    public class BoxLabel : SalesPartLabel
    {
        public virtual bool InstallByRetailerOnly { get; set; }

        public virtual string LabelDisplayLine1 { get; set; }

        public virtual string LabelDisplayLine2 { get; set; }

        public virtual int NumberOfSmallLabels { get; set; }

        public override T Accept<T>(ISalesPartLabelVisitor<T> visitor)
        {
            return visitor.VisitBoxLabel(this);
        }
    }
}