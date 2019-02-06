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

    public class WhenGettingCartonType : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var cartonType = new CartonType("c1", 1, 2, 3);
            this.CartonTypeService.GetById("c1")
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
            this.CartonTypeService.Received().GetById("c1");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<CartonTypeResource>();
            resource.Name.Should().Be("c1");
        }
    }
}