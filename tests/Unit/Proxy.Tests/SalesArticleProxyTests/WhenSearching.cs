namespace Linn.Products.Proxy.Tests.SalesArticleProxyTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;

    using FluentAssertions;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenSearching : ContextBase
    {
        private RestResponse<string> response;

        private IEnumerable<SalesArticle> results;

        [SetUp]
        public void SetUp()
        {
            var json = new JsonSerializer();
            var resource = new List<SalesArticle> { new SalesArticle { ArticleNumber = "sa" } };
            this.response = new RestResponse<string> { StatusCode = HttpStatusCode.OK, Value = json.Serialize(resource) };

            this.RestClient.Get(
                    Arg.Any<CancellationToken>(),
                    Arg.Is<Uri>(u => u.ToString().Contains($"linnapps-api/sales-articles/search?searchTerm")),
                    Arg.Any<IDictionary<string, string>>(),
                    Arg.Any<IDictionary<string, string[]>>())
                .Returns(this.response);

            this.results = this.Sut.Search("search");
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.results.Should().HaveCount(1);
            this.results.First().ArticleNumber.Should().Be("sa");
        }
    }
}