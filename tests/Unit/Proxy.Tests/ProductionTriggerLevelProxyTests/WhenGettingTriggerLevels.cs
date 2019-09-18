namespace Linn.Products.Proxy.Tests.ProductionTriggerLevelProxyTests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;

    using FluentAssertions;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.Products.Domain.Linnapps.Models;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingTriggerLevels : ContextBase
    {
        private RestResponse<string> response;

        private IEnumerable<ProductionTriggerLevel> results;

        [SetUp]
        public void SetUp()
        {
            var json = new JsonSerializer();
            var resources = new List<ProductionTriggerLevel>
                               {
                                   new ProductionTriggerLevel { PartNumber = "P1" },
                                   new ProductionTriggerLevel { PartNumber = "P2" },
                                   new ProductionTriggerLevel { PartNumber = "P3" }
                               };
            this.response = new RestResponse<string> { StatusCode = HttpStatusCode.OK, Value = json.Serialize(resources) };

            this.RestClient.Get(
                    Arg.Any<CancellationToken>(),
                    Arg.Is<Uri>(u => u.ToString().Contains($"/production/maintenance/production-trigger-levels")),
                    Arg.Any<IDictionary<string, string>>(),
                    Arg.Any<IDictionary<string, string[]>>())
                .Returns(this.response);

            this.results = this.Sut.GetAll();
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.results.Should().HaveCount(3);
            this.results.Should().Contain(a => a.PartNumber == "P1");
            this.results.Should().Contain(a => a.PartNumber == "P2");
            this.results.Should().Contain(a => a.PartNumber == "P3");
        }
    }
}