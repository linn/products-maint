namespace Linn.Products.Service.Tests.SalesArticleModuleSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSalesArticle : ContextBase
    {
        private SalesArticle salesArticle;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle { ArticleNumber = "sa", SmallLabelType = "sm" };
            var responseModel = new ResponseModel<SalesArticle>(this.salesArticle, null);
            this.SalesArticleForecastService.GetById("SA", Arg.Any<IEnumerable<string>>())
                .Returns(new SuccessResult<ResponseModel<SalesArticle>>(responseModel));

            this.Response = this.Browser.Get(
                "/products/maint/sales-articles",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Query("articleNumber", "sa");
                }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SalesArticleForecastService.Received().GetById("SA", Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SalesArticleResource>();
            resource.ArticleNumber.Should().Be(this.salesArticle.ArticleNumber);
            resource.SmallLabelType.Should().Be(this.salesArticle.SmallLabelType);
        }
    }
}
