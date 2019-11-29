namespace Linn.Products.Facade.Tests.ArchiveSerialNumberServiceSpecs
{
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected ArchiveSerialNumberService Sut { get; private set; }

        protected IFacadeService<ArchiveSerialNumber, int, ArchiveSerialNumberResource, ArchiveSerialNumberResource> ArchiveSerialNumberFacadeService
        {
            get;
            private set;
        }

        protected IRepository<ArchiveSerialNumber, int> ArchiveSerialNumberRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.ArchiveSerialNumberFacadeService = Substitute
                .For<IFacadeService<ArchiveSerialNumber, int, ArchiveSerialNumberResource, ArchiveSerialNumberResource>>();
            this.ArchiveSerialNumberRepository = Substitute.For<IRepository<ArchiveSerialNumber, int>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();

            this.Sut = new ArchiveSerialNumberService(this.ArchiveSerialNumberRepository, this.TransactionManager);
        }
    }
}
