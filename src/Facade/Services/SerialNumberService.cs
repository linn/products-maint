namespace Linn.Products.Facade.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Domain.Exceptions;
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Extensions;
    using Linn.Products.Resources;

    public class SerialNumberService : FacadeService<SerialNumber, int, SerialNumberResource, SerialNumberResource>, ISerialNumberFacadeService
    {
        private readonly IRepository<SerialNumber, int> serialNumberRepository;

        private readonly ITransactionManager transactionManager;

        private readonly ISerialNumberFactory serialNumberFactory;

        public SerialNumberService(
            IRepository<SerialNumber, int> serialNumberRepository,
            ITransactionManager transactionManager,
            ISerialNumberFactory serialNumberFactory)
            : base(serialNumberRepository, transactionManager)
        {
            this.serialNumberRepository = serialNumberRepository;
            this.transactionManager = transactionManager;
            this.serialNumberFactory = serialNumberFactory;
        }

        public IResult<IEnumerable<SerialNumber>> CreateSerialNumbers(SerialNumberResource resource)
        {
            var employee = resource.Links.FirstOrDefault(a => a.Rel == "entered-by");

            if (employee == null)
            {
                return new BadRequestResult<IEnumerable<SerialNumber>>("Must supply an employee number when creating a Serial Number");
            }

            var employeeNumber = employee.Href.ParseId();

            IEnumerable<SerialNumber> serialNumbers;

            try
            {
                serialNumbers = this.serialNumberFactory.CreateSerialNumbers(
                    resource.TransCode,
                    resource.ArticleNumber,
                    resource.FromSernosNumber,
                    resource.ToSernosNumber,
                    resource.PrevSernosNumber,
                    employeeNumber);
            }
            catch (DomainException e)
            {
                return new BadRequestResult<IEnumerable<SerialNumber>>(e.Message);
            }

            foreach (var serialNumber in serialNumbers)
            {
                this.serialNumberRepository.Add(serialNumber);
            }

            this.transactionManager.Commit();

            return new CreatedResult<IEnumerable<SerialNumber>>(serialNumbers);
        }

        protected override SerialNumber CreateFromResource(SerialNumberResource resource)
        {
            throw new System.NotImplementedException();
        }

        protected override void UpdateFromResource(SerialNumber entity, SerialNumberResource updateResource)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<SerialNumber, bool>> SearchExpression(string searchTerm)
        {
            return serialNumber => serialNumber.SernosNumber.ToString().Equals(searchTerm);
        }
    }
}