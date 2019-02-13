namespace Linn.Products.Facade.Tests.VatCodeServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected VatCodeService Sut { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        protected IRepository<VatCode, string> VatCodeRepository { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.VatCodeRepository = Substitute.For<IRepository<VatCode, string>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.Sut = new VatCodeService(this.VatCodeRepository, this.TransactionManager);
        }
    }
}