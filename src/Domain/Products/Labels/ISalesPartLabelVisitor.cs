namespace Linn.Products.Domain.Products.Labels
{
    public interface ISalesPartLabelVisitor<T>
    {
        T VisitBoxLabel(BoxLabel boxLabel);

        T VisitCartridgeLabel(CartridgeLabel cartridgeLabel);

        T VisitProductLabel(ProductLabel productLabel);
    }
}
