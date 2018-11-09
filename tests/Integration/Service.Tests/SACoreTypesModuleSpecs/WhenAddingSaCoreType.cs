namespace Linn.Products.Service.Tests.SaCoreTypesModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingSaCoreType : ContextBase
    {
        private SaCoreTypeResource requestResource;
        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SaCoreTypeResource { Description = "new description" };

            var saCoreType = new SaCoreType(1, "description");

            this.SaCoreTypeService.Add(Arg.Any<SaCoreTypeResource>())
                .Returns(new SuccessResult<SaCoreType>(saCoreType));
               
            this.Response = this.Browser.Post(
                "/products/maint/sa-core-types",
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
            this.SaCoreTypeService.Received().Add(
                Arg.Is<SaCoreTypeResource>(r => r.Description == this.requestResource.Description));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SaCoreTypeResource>();
            resource.CoreType.Should().Be(1);
            resource.Description.Should().Be("description");
        }
    }
}
