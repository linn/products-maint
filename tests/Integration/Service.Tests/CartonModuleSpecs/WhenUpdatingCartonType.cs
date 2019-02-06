namespace Linn.Products.Service.Tests.CartonModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingCartonType : ContextBase
    {
        private CartonTypeUpdateResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new CartonTypeUpdateResource { Description = "d1" };
            var cartonType = new CartonType("c1", 1, 2, 3);
            this.CartonTypeService.Update("c1", Arg.Any<CartonTypeUpdateResource>())
                .Returns(new SuccessResult<CartonType>(cartonType)
                             {
                                 Data = cartonType
                             });

            this.Response = this.Browser.Put(
                "/products/maint/carton-types/c1",
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
            this.CartonTypeService.Received()
                .Update(
                    "c1",
                    Arg.Is<CartonTypeUpdateResource>(r => r.Description == this.requestResource.Description));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<CartonTypeResource>();
            resource.Name.Should().Be("c1");
        }
    }
}