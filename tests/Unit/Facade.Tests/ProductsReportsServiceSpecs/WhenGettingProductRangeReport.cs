namespace Linn.Products.Facade.Tests.ProductsReportsServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingProductRangeReport : ContextBase
    {
        private IResult<ResultsModel> result;

        [SetUp]
        public void SetUp()
        {
            this.ProductReports.GetProductRangeReport(true)
                .Returns(new ResultsModel { ReportTitle = new NameModel("product ranges") });
            this.result = this.Sut.GetProductRanges(true);
        }

        [Test]
        public void ShouldGetResults()
        {
            this.ProductReports.Received().GetProductRangeReport(true);
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.result.Should().BeOfType<SuccessResult<ResultsModel>>();
            var dataResult = ((SuccessResult<ResultsModel>)this.result).Data;
            dataResult.ReportTitle.DisplayValue.Should().Be("product ranges");
        }
    }
}
