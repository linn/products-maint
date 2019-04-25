namespace Linn.Products.Domain.Linnapps
{
    using System;
    using System.Collections.Generic;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Exceptions;
    using Linn.Products.Domain.Linnapps.RemoteServices;

    public class SerialNumberFactory : ISerialNumberFactory
    {
        private readonly IRepository<SerialNumber, int> serialNumberRepository;

        private readonly ISernosPack sernosPack;

        public SerialNumberFactory(IRepository<SerialNumber, int> serialNumberRepository, ISernosPack sernosPack)
        {
            this.serialNumberRepository = serialNumberRepository;
            this.sernosPack = sernosPack;
        }

        public IEnumerable<SerialNumber> CreateSerialNumbers(
            string transCode,
            string articleNumber,
            int fromSerialNumber,
            int toSerialNumber,
            int? prevSerialNumber,
            int createdBy)
        {
            if (!this.sernosPack.CheckSernosTrans(transCode, articleNumber, fromSerialNumber))
            {
                throw new InvalidSerialNumberTransactionException(this.sernosPack.GetSernosMessage());
            }

            var sernosGroup = this.sernosPack.GetProductGroup(articleNumber);

            return new List<SerialNumber>
                       {
                           new SerialNumber(sernosGroup, transCode, articleNumber, createdBy)
                               {
                                   PrevSernosNumber = prevSerialNumber,
                                   SernosDate = DateTime.UtcNow
                               }
                       };
        }
    }
}