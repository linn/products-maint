namespace Linn.Products.Service.Tests.TypeOfSaleModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingTypeOfSale : ContextBase
    {
        private TypeOfSaleResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new TypeOfSaleResource { Name = "sale" };
            var typeOfSale = new TypeOfSale("name", "desc", "nom", "dept", "Y");
            this.TypeOfSaleService.Add(Arg.Any<TypeOfSaleResource>())
                .Returns(new CreatedResult<TypeOfSale>(typeOfSale) { Data = typeOfSale });

            this.Response = this.Browser.Post(
                "/products/maint/types-of-sale",
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
        public void ShouldCallservice()
        {
            this.TypeOfSaleService.Received().Add(Arg.Is<TypeOfSaleResource>(r => r.Name == this.requestResource.Name));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<TypeOfSaleResource>();
            resource.Name.Should().Be("name");
        }
    }
}
