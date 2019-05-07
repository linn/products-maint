namespace Linn.Products.Facade.Tests.SernosTransactionServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SernosTransactionService Sut { get; private set; }

        protected IRepository<SernosTrans, string> SerialNumberTransactionRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SerialNumberTransactionRepository = Substitute.For<IRepository<SernosTrans, string>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.Sut = new SernosTransactionService(this.SerialNumberTransactionRepository, this.TransactionManager);
        }
    }
}
