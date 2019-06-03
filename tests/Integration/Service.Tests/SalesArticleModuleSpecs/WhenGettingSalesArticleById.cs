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

    public class WhenGettingSalesArticleById : ContextBase
    {
        private SalesArticle salesArticle;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle { ArticleNumber = "sa" };
            this.SalesArticleForecastService.GetById("SA", Arg.Any<List<string>>()).Returns(new SuccessResult<ResponseModel<SalesArticle>>(new ResponseModel<SalesArticle>(this.salesArticle, null)));

            this.Response = this.Browser.Get(
                "/products/maint/sales-articles/sa",
                with =>
                {
                    with.Header("Accept", "application/json");
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
            this.SalesArticleForecastService.Received().GetById("SA", Arg.Any<List<string>>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SalesArticleResource>();
            resource.ArticleNumber.Should().Be("sa");
        }
    }
}