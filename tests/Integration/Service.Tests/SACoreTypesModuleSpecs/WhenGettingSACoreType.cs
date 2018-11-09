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

    public class WhenGettingSaCoreType : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var saCoreType = new SaCoreType(1, "description");
                                
            this.SaCoreTypeService.GetById(1)
                .Returns(new SuccessResult<SaCoreType>(saCoreType));

            this.Response = this.Browser.Get(
                "/products/maint/sa-core-types/1",
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
            this.SaCoreTypeService.Received().GetById(1);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SaCoreTypeResource>();
            resource.CoreType.Should().Be(1);
        }
    }
}
