namespace Linn.Products.Proxy
{
    public interface IDatabaseService
    {
        int GetIdSequence(string sequenceName);
    }
}