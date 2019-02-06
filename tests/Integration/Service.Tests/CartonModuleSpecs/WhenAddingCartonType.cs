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

    public class WhenAddingCartonType : ContextBase
    {
        private CartonTypeResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new CartonTypeResource { Name = "c1" };
            var cartonType = new CartonType("c1", 1, 2, 3);
            this.CartonTypeService.Add(Arg.Any<CartonTypeResource>())
                .Returns(new CreatedResult<CartonType>(cartonType)
                             {
                                 Data = cartonType
                             });

            this.Response = this.Browser.Post(
                "/products/maint/carton-types",
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
            this.CartonTypeService.Received().Add(Arg.Is<CartonTypeResource>(r => r.Name == this.requestResource.Name));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<CartonTypeResource>();
            resource.Name.Should().Be("c1");
        }
    }
}