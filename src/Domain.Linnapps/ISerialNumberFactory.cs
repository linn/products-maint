namespace Linn.Products.Domain.Linnapps
{
    using System.Collections.Generic;

    public interface ISerialNumberFactory
    {
        IEnumerable<SerialNumber> CreateSerialNumbers(
            string transCode,
            string articleNumber,
            int fromSerialNumber,
            int toSerialNumber,
            int? prevSerialNumber,
            int createdBy);
    }
}
