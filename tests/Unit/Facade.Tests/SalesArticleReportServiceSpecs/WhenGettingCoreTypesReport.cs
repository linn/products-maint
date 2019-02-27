namespace Linn.Products.Facade.Tests.SalesArticleReportServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingCoreTypesReport : ContextBase
    {
        private IResult<ResultsModel> result;

        [SetUp]
        public void SetUp()
        {
            this.SalesArticleReports.SalesArticleCoreTypeReport()
                .Returns(new ResultsModel { ReportTitle = new NameModel("title") });
            this.result = this.Sut.GetSalesArticleCoreTypes();
        }

        [Test]
        public void ShouldGetResults()
        {
            this.SalesArticleReports.Received().SalesArticleCoreTypeReport();
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.result.Should().BeOfType<SuccessResult<ResultsModel>>();
            var dataResult = ((SuccessResult<ResultsModel>)this.result).Data;
            dataResult.ReportTitle.DisplayValue.Should().Be("title");
        }
    }
}
