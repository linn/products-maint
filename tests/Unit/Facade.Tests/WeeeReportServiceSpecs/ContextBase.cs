namespace Linn.Products.Facade.Tests.WeeeReportServiceSpecs
{
    using Linn.Products.Domain.Reports;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected WEEEReportsService Sut { get; private set; }

        protected IWEEEReports WeeeReports { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.WeeeReports = Substitute.For<IWEEEReports>();
            this.Sut = new WEEEReportsService(this.WeeeReports);
        }
    }
}
