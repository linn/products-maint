namespace Linn.Products.Service.Tests.SernosConfigModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingAllSernosCounts : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosCount1 = new SernosCount { Name = "one" };
            var sernosCount2 = new SernosCount { Name = "two" };
            this.SernosCountService.GetAll()
                .Returns(new SuccessResult<IEnumerable<SernosCount>>(new List<SernosCount> { sernosCount1, sernosCount2 }));

            this.Response = this.Browser.Get(
                "/products/maint/serial-number-counts",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosCountService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<SernosCountResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.Name == "one");
            resources.Should().Contain(a => a.Name == "two");
        }
    }
}