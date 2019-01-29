namespace Linn.Products.Service.Tests.SalesArticleModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenSearching : ContextBase
    {
        private IEnumerable<SalesArticle> salesArticles;

        [SetUp]
        public void SetUp()
        {
            this.salesArticles = new[] { new SalesArticle { ArticleNumber = "sa" } };
            this.SalesArticleService.Search("sa").Returns(this.salesArticles);

            this.Response = this.Browser.Get(
                "/products/maint/sales-articles",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Query("searchTerm", "sa");
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
            this.SalesArticleService.Received().Search("sa");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<IEnumerable<SalesArticleResource>>().ToList();
            resource.Should().HaveCount(1);
            resource.First().ArticleNumber.Should().Be("sa");
        }
    }
}