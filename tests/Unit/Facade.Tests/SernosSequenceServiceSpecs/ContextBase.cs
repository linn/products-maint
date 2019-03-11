namespace Linn.Products.Facade.Tests.SernosSequenceServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SernosSequenceService Sut { get; set; }

        protected IRepository<SernosSequence, string> SernosSequenceRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SernosSequenceRepository = Substitute.For<IRepository<SernosSequence, string>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.Sut = new SernosSequenceService(this.SernosSequenceRepository, this.TransactionManager);
        }
    }
}
