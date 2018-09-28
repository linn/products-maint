namespace Linn.Products.Facade.Tests.ProductsReportsServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSalesProductsByRangeReport : ContextBase
    {
        private IResult<ResultsModel> result;

        [SetUp]
        public void SetUp()
        {
            this.ProductReports.GetSalesProductByRangeReport(1, true)
                .Returns(new ResultsModel { ReportTitle = new NameModel("products") });
            this.result = this.Sut.GetSalesProductByProductRange(1, true);
        }

        [Test]
        public void ShouldGetResults()
        {
            this.ProductReports.Received().GetSalesProductByRangeReport(1, true);
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.result.Should().BeOfType<SuccessResult<ResultsModel>>();
            var dataResult = ((SuccessResult<ResultsModel>)this.result).Data;
            dataResult.ReportTitle.DisplayValue.Should().Be("products");
        }
    }
}
