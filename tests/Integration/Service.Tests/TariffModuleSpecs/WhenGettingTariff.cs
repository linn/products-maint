using FluentAssertions;
using Linn.Common.Facade;
using Linn.Products.Domain.Linnapps;
using Linn.Products.Domain.Linnapps.Products;
using Linn.Products.Resources;
using Nancy;
using Nancy.Testing;
using NSubstitute;
using NUnit.Framework;

namespace Linn.Products.Service.Tests.TariffModuleSpecs
{
    public class WhenGettingTariff : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var tariff = new Tariff
            {
                Id = 1,
                TariffCode = "test",
                Description = "test-case"
            };
            this.TariffService.GetById(1)
                .Returns(new SuccessResult<Tariff>(tariff));

            this.Response = this.Browser.Get(
                "/products/maint/tariffs/1",
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
            this.TariffService.Received().GetById(1);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<TariffResource>();
            resource.TariffCode.Should().Be("test");
            resource.Description.Should().Be("test-case");
        }
    }
}