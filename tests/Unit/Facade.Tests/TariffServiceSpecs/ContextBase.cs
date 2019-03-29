namespace Linn.Products.Facade.Tests.TariffServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected TariffService Sut { get; private set; }

        protected IRepository<Tariff, int> TariffRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.TariffRepository = Substitute.For<IRepository<Tariff, int>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.Sut = new TariffService(this.TariffRepository, this.TransactionManager);
        }
    }
}
