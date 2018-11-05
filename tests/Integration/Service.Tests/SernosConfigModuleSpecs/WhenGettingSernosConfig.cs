namespace Linn.Products.Service.Tests.SernosConfigModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSernosConfig : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosConfig = new SernosConfig("name", "Y", 2, 3);
            this.SernosConfigService.GetById("name")
                .Returns(new SuccessResult<SernosConfig>(sernosConfig)
                             {
                                 Data = sernosConfig
                             });

            this.Response = this.Browser.Get(
                "/products/maint/sernos-configs/name",
                with =>
                {
                    with.Header("Accept", "application/json");
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
            this.SernosConfigService.Received().GetById("name");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosConfigResource>();
            resource.Name.Should().Be("name");
        }
    }
}