namespace Linn.Products.Facade.Tests.SalesArticleReportServiceSpecs
{
    using Linn.Products.Domain.Reports;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleReportService Sut { get; private set; }

        protected IEanCodeReportService EanCodeReportService { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.EanCodeReportService = Substitute.For<IEanCodeReportService>();
            this.Sut = new SalesArticleReportService(this.EanCodeReportService);
        }
    }
}
