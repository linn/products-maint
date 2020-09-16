namespace Linn.Products.Facade.Tests.SalesArticleServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.Services;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleService Sut { get; private set; }

        protected IRepository<SalesArticle, string> SalesArticleRepository { get; private set; }

        protected IRepository<SaCoreType, int> SaCoreTypeRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        protected ITariffNumberReallocationService ReallocationService { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SalesArticleRepository = Substitute.For<IRepository<SalesArticle, string>>();
            this.SaCoreTypeRepository = Substitute.For<IRepository<SaCoreType, int>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.ReallocationService = Substitute.For<ITariffNumberReallocationService>();
            this.Sut = new SalesArticleService(
                this.SalesArticleRepository,
                this.SaCoreTypeRepository,
                this.TransactionManager,
                this.ReallocationService);
        }
    }
}
