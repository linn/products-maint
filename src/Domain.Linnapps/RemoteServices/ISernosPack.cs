namespace Linn.Products.Domain.Linnapps.RemoteServices
{
    public interface ISernosPack
    {
        string GetProductGroup(string partNumber);

        bool CheckSernosTrans(string transCode, string articleNumber, int sernosNumber);

        string GetSernosMessage();
    }
}
