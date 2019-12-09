namespace Linn.Products.Facade.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class ArchiveSerialNumberService :
        FacadeService<ArchiveSerialNumber, int, ArchiveSerialNumberResource, ArchiveSerialNumberResource>,
        IArchiveSerialNumberFacadeService
    {
        private readonly IRepository<ArchiveSerialNumber, int> repository;

        public ArchiveSerialNumberService(
            IRepository<ArchiveSerialNumber, int> repository,
            ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
            this.repository = repository;
        }

        public IResult<ResponseModel<IEnumerable<ArchiveSerialNumber>>> SearchByDocumentNumber(int documentNumber, IEnumerable<string> privileges)
        {
            return new SuccessResult<ResponseModel<IEnumerable<ArchiveSerialNumber>>>(
                new ResponseModel<IEnumerable<ArchiveSerialNumber>>(
                    this.repository.FilterBy(s => s.DocumentNumber == documentNumber && s.TransCode == "ISSUED"), privileges));
        }

        protected override ArchiveSerialNumber CreateFromResource(ArchiveSerialNumberResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(
            ArchiveSerialNumber entity,
            ArchiveSerialNumberResource updateResource)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<ArchiveSerialNumber, bool>> SearchExpression(string searchTerm)
        {
            return s => s.SernosNumber.ToString().Equals(searchTerm);
        }
    }
}
