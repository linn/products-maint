namespace Linn.Products.Facade.Tests.CartonReportsServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingCartonDetailsReport : ContextBase
    {
        private IResult<ResultsModel> result;

        [SetUp]
        public void SetUp()
        {
            this.CartonDetailsReportService.GetCartonsReport()
                .Returns(new ResultsModel { ReportTitle = new NameModel("cartons") });
            this.result = this.Sut.GetCartonDetails();
        }

        [Test]
        public void ShouldGetResults()
        {
            this.CartonDetailsReportService.Received().GetCartonsReport();
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.result.Should().BeOfType<SuccessResult<ResultsModel>>();
            var dataResult = ((SuccessResult<ResultsModel>)this.result).Data;
            dataResult.ReportTitle.DisplayValue.Should().Be("cartons");
        }
    }
}
