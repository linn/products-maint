namespace Linn.Products.Service.Tests.CartonModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingCartonType : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var cartonType = new CartonType { Name = "c1" };
            this.CartonTypeService.GetCartonType("c1")
                .Returns(new SuccessResult<CartonType>(cartonType)
                             {
                                 Data = cartonType
                             });

            this.Response = this.Browser.Get(
                "/products/maint/carton-types/c1",
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
            this.CartonTypeService.Received().GetCartonType("c1");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<CartonType>();
            resource.Name.Should().Be("c1");
        }
    }
}