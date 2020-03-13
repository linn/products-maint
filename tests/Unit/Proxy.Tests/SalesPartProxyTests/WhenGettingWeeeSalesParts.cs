namespace Linn.Products.Proxy.Tests.SalesPartProxyTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;

    using FluentAssertions;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingWeeeSalesParts : ContextBase
    {
        private RestResponse<string> response;

        private IEnumerable<SalesPart> results;

        [SetUp]
        public void SetUp()
        {
            var json = new JsonSerializer();
            var resource = new List<SalesPart>
                               {
                                   new SalesPart
                                       {
                                           Name = "SP",
                                           Description = "Desc",
                                           RootProduct = new RootProduct { Name = "RP", Description = "Desc" }
                                       }
                               };
            this.response =
                new RestResponse<string> { StatusCode = HttpStatusCode.OK, Value = json.Serialize(resource) };

            this.RestClient.Get(
                Arg.Any<CancellationToken>(),
                Arg.Any<Uri>(),
                Arg.Any<IDictionary<string, string>>(),
                Arg.Any<IDictionary<string, string[]>>()).Returns(this.response);

            this.results = this.Sut.GetWEEESalesParts();
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.results.Should().HaveCount(1);
            this.results.First().Name.Should().Be("SP");
        }
    }
}