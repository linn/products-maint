namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SerialNumberService : ISerialNumberService
    {
        private readonly IRepository<SerialNumber, int> repository;
        private readonly ITransactionManager transactionManager;        
        
        public SerialNumberService(IRepository<SerialNumber, int> repository, ITransactionManager transactionManager)
        {
            this.repository = repository;
            this.transactionManager = transactionManager;
        }

        public IResult<SerialNumber> GetByTRef(int sernosTRef)
        {
            var serialNumber = this.repository.FindById(sernosTRef);
            if (serialNumber == null)
            {
                return new NotFoundResult<SerialNumber>(sernosTRef.ToString());
            }

            return new SuccessResult<SerialNumber>(serialNumber);
        }

        public IResult<IEnumerable<SerialNumber>> GetBySernosNumber(int sernosNumber)
        {
            var serialNumbers = this.repository.FilterBy(s => s.SernosNumber == sernosNumber);
            if (serialNumbers == null)
            {
                return new NotFoundResult<IEnumerable<SerialNumber>>(sernosNumber.ToString());
            }

            return new SuccessResult<IEnumerable<SerialNumber>>(serialNumbers);
        }

        public IResult<SerialNumber> Add(SerialNumberResource resource)
        {
            throw new System.NotImplementedException();
        }

        public IResult<SerialNumber> Update(int sernosTRef, SerialNumberResource resource)
        {
            throw new System.NotImplementedException();
        }
    }
}
