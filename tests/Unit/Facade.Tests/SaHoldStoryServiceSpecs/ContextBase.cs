namespace Linn.Products.Facade.Tests.SaHoldStoryServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SaHoldStoryFacadeService Sut { get; set; }

        protected IRepository<SaHoldStory, int> SaHoldStoryRepository { get; set; }

        protected IRepository<SalesArticle, string> SalesArticleRepository { get; set; }

        protected IRepository<Employee, int> EmployeeRepository { get; set; }

        protected IRepository<RootProduct, string> RootProductRepository { get; set; }

        protected ITransactionManager TransactionManager { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SaHoldStoryRepository = Substitute.For<IRepository<SaHoldStory, int>>();
            this.SalesArticleRepository = Substitute.For<IRepository<SalesArticle, string>>();
            this.RootProductRepository = Substitute.For<IRepository<RootProduct, string>>();
            this.EmployeeRepository = Substitute.For<IRepository<Employee, int>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.Sut = new SaHoldStoryFacadeService(
                this.SaHoldStoryRepository,
                this.TransactionManager,
                this.SalesArticleRepository,
                this.RootProductRepository,
                this.EmployeeRepository);
        }
    }
}