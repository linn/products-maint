namespace Linn.Products.Domain.Reports.Helpers
{
    public interface ICsvCreator
    {
        byte[] CreateCsv(object data);
    }
}
