namespace Linn.Products.Domain.Products.Labels
{
    public interface ISalesPartLabelAcceptor
    {
        T Accept<T>(ISalesPartLabelVisitor<T> visitor);
    }
}
