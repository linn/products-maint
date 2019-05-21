namespace Linn.Products.Domain.Linnapps.Tests.SerialNumberFactorySpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SerialNumberFactory Sut { get; private set; }

        protected IRepository<SalesArticle, string> SalesArticleRepository { get; private set; }

        protected ISernosPack SernosPack { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SalesArticleRepository = Substitute.For<IRepository<SalesArticle, string>>();
            this.SernosPack = Substitute.For<ISernosPack>();
            this.Sut = new SerialNumberFactory(this.SernosPack, this.SalesArticleRepository);
        }
    }
}
