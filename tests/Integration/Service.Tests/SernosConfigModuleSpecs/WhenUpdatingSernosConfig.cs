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

    public class WhenUpdatingSernosConfig : ContextBase
    {
        private SernosConfigResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SernosConfigResource { Description = "new description", SerialNumbered = "N" };
            var sernosConfig = new SernosConfig("name", "Y", 2, 3) { Description = "new description" };
            this.SernosConfigService.Update("name", Arg.Any<SernosConfigResource>())
                .Returns(new SuccessResult<SernosConfig>(sernosConfig)
                             {
                                 Data = sernosConfig
                             });

            this.Response = this.Browser.Put(
                "/products/maint/sernos-configs/name",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Type", "application/json");
                    with.JsonBody(this.requestResource);
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
            this.SernosConfigService.Received()
                .Update(
                    "name",
                    Arg.Is<SernosConfigResource>(r => r.Description == this.requestResource.Description));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosConfigResource>();
            resource.Name.Should().Be("name");
            resource.Description.Should().Be("new description");
        }
    }
}