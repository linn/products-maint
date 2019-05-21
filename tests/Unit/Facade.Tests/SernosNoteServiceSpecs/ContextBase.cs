namespace Linn.Products.Facade.Tests.SernosNoteServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SernosNoteService Sut { get; private set; }

        protected IRepository<SernosNote, int> SernosNoteRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SernosNoteRepository = Substitute.For<IRepository<SernosNote, int>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.Sut = new SernosNoteService(this.SernosNoteRepository, this.TransactionManager);
        }
    }
}