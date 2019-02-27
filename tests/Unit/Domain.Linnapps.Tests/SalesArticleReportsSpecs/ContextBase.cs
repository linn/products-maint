namespace Linn.Products.Domain.Linnapps.Tests.SalesArticleReportsSpecs
{
    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.Reports;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleReports Sut { get; private set; }

        protected IRepository<SalesArticle, string> SalesArticleRepository { get; private set; }

        protected ResultsModel Results { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SalesArticleRepository = Substitute.For<IRepository<SalesArticle, string>>();

            this.Sut = new SalesArticleReports(this.SalesArticleRepository);
        }
    }
}
