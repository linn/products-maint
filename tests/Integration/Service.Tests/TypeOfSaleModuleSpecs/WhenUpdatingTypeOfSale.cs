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

    public class WhenUpdatingTypeOfSale : ContextBase
    {
        private TypeOfSaleResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new TypeOfSaleResource
                                       {
                                           Description = "new desc",
                                           Department = "new dept",
                                           Nominal = "new nom",
                                           RealSale = "N"
                                       };
            var typeOfSale = new TypeOfSale("name", "desc", "nom", "dept", "Y") { Description = "new desc" };
            this.TypeOfSaleService.Update("name", Arg.Any<TypeOfSaleResource>()).Returns(new SuccessResult<TypeOfSale>(typeOfSale) { Data = typeOfSale });

            this.Response = this.Browser.Put(
                "/products/maint/types-of-sale/name",
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
            this.TypeOfSaleService.Received().Update(
                "name",
                Arg.Is<TypeOfSaleResource>(r => r.Description == this.requestResource.Description));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<TypeOfSaleResource>();
            resource.Name.Should().Be("name");
            resource.Description.Should().Be("new desc");
        }
    }
}
