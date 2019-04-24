namespace Linn.Products.Facade.Tests.SalesArticleSerialNumberFacadeServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleSerialNumberFacadeService Sut { get; private set;  }

        protected IRepository<SalesArticle, string> SalesArticleRepository { get; private set; }

        protected ISernosPack SernosPack { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SalesArticleRepository = Substitute.For<IRepository<SalesArticle, string>>();
            this.SernosPack = Substitute.For<ISernosPack>();
            this.Sut = new SalesArticleSerialNumberFacadeService(this.SalesArticleRepository, this.SernosPack);
        }
    }
}
