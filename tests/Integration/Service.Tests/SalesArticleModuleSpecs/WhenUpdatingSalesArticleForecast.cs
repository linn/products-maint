namespace Linn.Products.Service.Tests.SalesArticleModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSalesArticleForecast : ContextBase
    {
        private SalesArticle salesArticle;

        private SalesArticleResource resource;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle { ArticleNumber = "sa" };
            this.resource = new SalesArticleResource
                                {
                                    ForecastType = "Y",
                                    ForecastFromDate = 1.December(2020).ToString("o")
                                };
            this.SalesArticleForecastService.Update("sa", Arg.Any<SalesArticleResource>())
                .Returns(new SuccessResult<SalesArticle>(this.salesArticle));

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
            this.SalesArticleForecastService.Received().Update("sa", Arg.Is<SalesArticleResource>(r => r.ForecastType == this.resource.ForecastType));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var response = this.Response.Body.DeserializeJson<SalesArticleResource>();
            response.ArticleNumber.Should().Be("sa");
        }
    }
}