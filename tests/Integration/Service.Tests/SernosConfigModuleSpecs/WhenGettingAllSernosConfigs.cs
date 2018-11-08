namespace Linn.Products.Service.Tests.SernosConfigModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingAllSernosConfigs : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosConfig1 = new SernosConfig("name1", "Y", 2, 3);
            var sernosConfig2 = new SernosConfig("name2", "Y", 2, 3);
            this.SernosConfigService.GetAll()
                .Returns(new SuccessResult<IEnumerable<SernosConfig>>(new List<SernosConfig> { sernosConfig1, sernosConfig2 }));

            this.Response = this.Browser.Get(
                "/products/maint/sernos-configs",
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
            this.SernosConfigService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<SernosConfigResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.Name == "name1");
            resources.Should().Contain(a => a.Name == "name2");
        }
    }
}