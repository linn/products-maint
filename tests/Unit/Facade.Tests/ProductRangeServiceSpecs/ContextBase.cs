namespace Linn.Products.Facade.Tests.ProductRangeServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected ProductRangeService Sut { get; private set; }

        protected IRepository<ProductRange, int> ProductRangeRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.ProductRangeRepository = Substitute.For<IRepository<ProductRange, int>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.Sut = new ProductRangeService(
                this.ProductRangeRepository,
                this.TransactionManager);
        }
    }
}
