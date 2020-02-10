namespace Linn.Products.Service.Tests.SalesArticleModuleSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSalesArticleForecast : ContextBase
    {
        private SalesArticleResource resource;

        [SetUp]
        public void SetUp()
        {
            var salesArticle = new SalesArticle { ArticleNumber = "sa" };
            var responseModel = new ResponseModel<SalesArticle>(salesArticle, null);
            this.resource = new SalesArticleResource
                                {
                                    ForecastType = "Y",
                                    ForecastFromDate = 1.December(2020).ToString("o")
                                };
            this.SalesArticleForecastService.Update("SA", Arg.Any<SalesArticleResource>(), Arg.Any<IEnumerable<string>>())
                .Returns(new SuccessResult<ResponseModel<SalesArticle>>(responseModel));

            this.Response = this.Browser.Put(
                "/products/maint/sales-articles/sa",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Type", "application/json");
                    with.JsonBody(this.resource);
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
            this.SalesArticleForecastService.Received().Update("SA", Arg.Is<SalesArticleResource>(r => r.ForecastType == this.resource.ForecastType), Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var response = this.Response.Body.DeserializeJson<SalesArticleResource>();
            response.ArticleNumber.Should().Be("sa");
        }
    }
}