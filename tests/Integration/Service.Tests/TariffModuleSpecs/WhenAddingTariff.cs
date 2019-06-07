namespace Linn.Products.Service.Tests.TariffModuleSpecs
{
    using System;
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingTariff : ContextBase
    {
        private TariffResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new TariffResource
            {
                TariffCode = "test",
                Description = "test-case"
            };

            var tariff = new Tariff
            {
                TariffCode = "test",
                Description = "test-case"
            };
            this.TariffService.Add(Arg.Any<TariffResource>(), Arg.Any<IEnumerable<string>>())
                .Returns(new CreatedResult<ResponseModel<Tariff>>(new ResponseModel<Tariff>(tariff, new List<string>())));

            this.Response = this.Browser.Post(
                "/products/maint/tariffs",
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
            this.TariffService.Received().Add(
                Arg.Is<TariffResource>(r => r.TariffCode == this.requestResource.TariffCode),
                Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var res = this.Response.Body;
            var resource = this.Response.Body.DeserializeJson<TariffResource>();
            resource.TariffCode.Should().Be("test");
            resource.Description.Should().Be("test-case");
        }
    }
}
