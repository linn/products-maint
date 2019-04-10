namespace Linn.Products.Service.Tests.SalesArticleModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
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
            this.salesArticle = new SalesArticle { ArticleNumber = "sa" };
            this.SalesArticleForecastService.GetById("sa").Returns(new SuccessResult<SalesArticle>(this.salesArticle));

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
            this.SalesArticleForecastService.Received().GetById("sa");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SalesArticleResource>();
            resource.ArticleNumber.Should().Be("sa");
        }
    }
}