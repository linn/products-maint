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

    public class WhenAddingSernosConfig : ContextBase
    {
        private SernosConfigResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SernosConfigResource { Name = "c1" };
            var sernosConfig = new SernosConfig("name", "Y", 2, 3);
            this.SernosConfigService.Add(Arg.Any<SernosConfigResource>())
                .Returns(new CreatedResult<SernosConfig>(sernosConfig)
                             {
                                 Data = sernosConfig
                             });

            this.Response = this.Browser.Post(
                "/products/maint/sernos-configs",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Type", "application/json");
                    with.JsonBody(this.requestResource);
                }).Result;
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosConfigService.Received().Add(Arg.Is<SernosConfigResource>(r => r.Name == this.requestResource.Name));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosConfigResource>();
            resource.Name.Should().Be("name");
        }
    }
}