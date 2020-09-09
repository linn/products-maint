namespace Linn.Products.Domain.Products.Labels
{
    public interface ISalesPartLabel : ISalesPartLabelAcceptor
    {
        string Type { get; set; }

        int Id { get; set; }

        int NumberToBePrinted { get; set; }
    }
}