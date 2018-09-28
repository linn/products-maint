namespace Linn.Products.Facade.Tests.CartonReportsServiceSpecs
{
    using Linn.Products.Domain.Reports;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected CartonReportsService Sut { get; private set; }

        protected ICartonDetailsReportService CartonDetailsReportService { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.CartonDetailsReportService = Substitute.For<ICartonDetailsReportService>();
            this.Sut = new CartonReportsService(this.CartonDetailsReportService);
        }
    }
}
