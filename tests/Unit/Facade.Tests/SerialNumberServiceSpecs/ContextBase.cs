namespace Linn.Products.Facade.Tests.SerialNumberServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SerialNumberService Sut { get; private set; }

        protected IRepository<SerialNumber, int> SerialNumberRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        protected ISerialNumberFactory SerialNumberFactory { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SerialNumberRepository = Substitute.For<IRepository<SerialNumber, int>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.SerialNumberFactory = Substitute.For<ISerialNumberFactory>();
            this.Sut = new SerialNumberService(this.SerialNumberRepository, this.TransactionManager, this.SerialNumberFactory);
        }
    }
}
