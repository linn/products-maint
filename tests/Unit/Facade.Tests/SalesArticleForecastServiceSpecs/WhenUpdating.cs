namespace Linn.Products.Facade.Tests.SalesArticleForecastServiceSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdating : ContextBase
    {
        private IResult<SalesArticle> result;

        private SalesArticleResource resource;

        private SalesArticle salesArticle;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle
                                    {
                                        ArticleNumber = "sa",
                                        ForecastType = "N",
                                        ForecastToDate = 1.December(2019)
                                    };
            this.resource = new SalesArticleResource
                                {
                                    ArticleNumber = "sa",
                                    Description = "new desc",
                                    ForecastType = "Y",
                                    ForecastToDate = 1.December(2020).ToString("o")
                                };
            this.SalesArticleRepository.FindById("sa")
                .Returns(this.salesArticle);
            this.result = this.Sut.Update("sa", this.resource);
        }

        [Test]
        public void ShouldGetArticle()
        {
            this.SalesArticleRepository.Received().FindById("sa");
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<SalesArticle>>();
            var dataResult = ((SuccessResult<SalesArticle>)this.result).Data;
            dataResult.ArticleNumber.Should().Be("sa");
            dataResult.ForecastType.Should().Be("Y");
            dataResult.ForecastToDate.Should().Be(DateTime.Parse(this.resource.ForecastToDate));
        }
    }
}
