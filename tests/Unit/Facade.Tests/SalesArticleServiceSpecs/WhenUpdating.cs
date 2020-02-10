namespace Linn.Products.Facade.Tests.SalesArticleServiceSpecs
{
    using System;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdating : ContextBase
    {
        private IResult<SalesArticle> result;

        private SalesArticleResource resource;

        private SalesArticle salesArticle;

        private SaCoreType coreType;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle
                                    {
                                        ArticleNumber = "sa",
                                        ForecastType = "N",
                                        ForecastToDate = 1.December(2019)
                                    };
            this.coreType = new SaCoreType(1, "thing");
            this.resource = new SalesArticleResource
                                {
                                    ArticleNumber = "sa",
                                    Description = "new desc",
                                    ForecastType = "Y",
                                    ForecastToDate = 1.December(2020).ToString("o"),
                                    Links = new LinkResource[] { new LinkResource("sa-core-type", "/sact/1") }
                                };
            this.SalesArticleRepository.FindById("sa")
                .Returns(this.salesArticle);
            this.SaCoreTypeRepository.FindById(1)
                .Returns(this.coreType);
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
            dataResult.SaCoreType.CoreType.Should().Be(1);
            dataResult.SaCoreType.Description.Should().Be("thing");
        }
    }
}
