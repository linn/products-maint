namespace Linn.Products.Facade.Tests.SalesArticleForecastServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleForecastService Sut { get; private set; }

        protected IRepository<SalesArticle, string> SalesArticleRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SalesArticleRepository = Substitute.For<IRepository<SalesArticle, string>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.Sut = new SalesArticleForecastService(this.SalesArticleRepository, this.TransactionManager);
        }
    }
}
