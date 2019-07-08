namespace Linn.Products.Facade.Tests.SalesArticleReportServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.Reports;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleReportService Sut { get; private set; }

        protected IEanCodeReportService EanCodeReportService { get; private set; }

        protected ISalesArticleReports SalesArticleReports { get; private set; }


        protected IRepository<SalesArticle, string> salesArticleRepository;
        [SetUp]
        public void SetUpContext()
        {
            this.EanCodeReportService = Substitute.For<IEanCodeReportService>();
            this.SalesArticleReports = Substitute.For<ISalesArticleReports>();
            this.salesArticleRepository = Substitute.For<IRepository<SalesArticle, string>>();
            this.Sut = new SalesArticleReportService(this.EanCodeReportService, this.SalesArticleReports, this.salesArticleRepository);
        }
    }
}
