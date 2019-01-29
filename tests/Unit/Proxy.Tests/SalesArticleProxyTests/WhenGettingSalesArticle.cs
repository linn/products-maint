namespace Linn.Products.Proxy.Tests.SalesArticleProxyTests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;

    using FluentAssertions;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSalesArticle : ContextBase
    {
        private RestResponse<string> response;

        private SalesArticle result;

        [SetUp]
        public void SetUp()
        {
            var json = new JsonSerializer();
            var resource = new SalesArticle { ArticleNumber = "sa" };
            this.response = new RestResponse<string> { StatusCode = HttpStatusCode.OK, Value = json.Serialize(resource) };

            this.RestClient.Get(
                    Arg.Any<CancellationToken>(),
                    Arg.Is<Uri>(u => u.ToString().Contains("linnapps-api/sales-articles?articleNumber=")),
                    Arg.Any<IDictionary<string, string>>(),
                    Arg.Any<IDictionary<string, string[]>>())
                .Returns(this.response);

            this.result = this.Sut.GetSalesArticle("sa");
        }

        [Test]
        public void ShouldReturnResult()
        {
            this.result.ArticleNumber.Should().Be("sa");
        }
    }
}