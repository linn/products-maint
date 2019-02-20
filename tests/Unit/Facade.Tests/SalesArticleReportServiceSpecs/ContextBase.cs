namespace Linn.Products.Facade.Tests.SalesArticleReportServiceSpecs
{
    using Linn.Products.Domain.Linnapps.Reports;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleReportService Sut { get; private set; }

        protected IEanCodeReportService EanCodeReportService { get; private set; }

        protected ISalesArticleReports SalesArticleReports { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.EanCodeReportService = Substitute.For<IEanCodeReportService>();
            this.SalesArticleReports = Substitute.For<ISalesArticleReports>();
            this.Sut = new SalesArticleReportService(this.EanCodeReportService, this.SalesArticleReports);
        }
    }
}
