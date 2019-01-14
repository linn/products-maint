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

    public class WhenGettingTypeOfSale : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var typeOfSale = new TypeOfSale("name", "desc", "nom", "dept", "Y");
            this.TypeOfSaleService.GetById("name")
                .Returns(new SuccessResult<TypeOfSale>(typeOfSale) { Data = typeOfSale });

            this.Response = this.Browser.Get(
                "/products/maint/types-of-sale/name",
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
            this.TypeOfSaleService.Received().GetById("name");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<TypeOfSaleResource>();
            resource.Name.Should().Be("name");
        }
    }
}