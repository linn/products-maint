namespace Linn.Products.Service.Tests.SalesArticleModuleSpecs
{
    using FluentAssertions;

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
            this.SalesArticleService.GetSalesArticle("sa").Returns(this.salesArticle);

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
            this.SalesArticleService.Received().GetSalesArticle("sa");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SalesArticleResource>();
            resource.ArticleNumber.Should().Be("sa");
        }
    }
}