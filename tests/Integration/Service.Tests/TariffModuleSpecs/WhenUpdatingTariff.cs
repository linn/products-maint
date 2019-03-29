namespace Linn.Products.Service.Tests.TariffModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingTariff : ContextBase
    {
        private TariffResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new TariffResource() { Description = "new description", TariffCode = "N" };
            var tariff = new Tariff { Description = "new description", TariffCode = "N", Id = 1};
            this.TariffService.Update(1, Arg.Any<TariffResource>())
                .Returns(new SuccessResult<Tariff>(tariff));

            this.Response = this.Browser.Put(
                "/products/maint/tariffs/1",
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
            this.TariffService.Received()
                .Update(
                    1,
                    Arg.Is<TariffResource>(r => r.Description == this.requestResource.Description));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<TariffResource>();
            resource.TariffCode.Should().Be("N");
            resource.Description.Should().Be("new description");
        }
    }
}