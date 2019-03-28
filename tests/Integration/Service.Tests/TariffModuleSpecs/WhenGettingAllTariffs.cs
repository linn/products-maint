using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Linn.Common.Facade;
using Linn.Products.Domain.Linnapps.Products;
using Linn.Products.Resources;
using Nancy;
using Nancy.Testing;
using NSubstitute;
using NUnit.Framework;

namespace Linn.Products.Service.Tests.TariffModuleSpecs
{
    public class WhenGettingAllTariffs : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var tariff1 = new Tariff
            {
                TariffCode = "test",
                Description = "test-case"
            };
            var tariff2 = new Tariff
            {
                TariffCode = "test-1",
                Description = "test-case-1"
            };
            this.TariffService.GetAll()
                .Returns(new SuccessResult<IEnumerable<Tariff>>(new List<Tariff> { tariff1, tariff2 }));

            this.TariffRepository.SearchTariffs("test-1")
                .Returns(new List<Tariff> { tariff2 });

            this.Response = this.Browser.Get(
                "/products/maint/tariffs",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.TariffService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<TariffResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.TariffCode == "test" && a.Description == "test-case");
            resources.Should().Contain(a => a.TariffCode == "test-1" && a.Description == "test-case-1");
        }

        [Test]
        public void ShouldReturnResourceFilteredBySearchTerm()
        {
            this.Response = this.Browser.Get(
                "/products/maint/tariffs",
                with => { with.HttpRequest(); with.Header("Accept", "application/json"); with.Query("searchTerm", "test-1"); }).Result;

            var resources = this.Response.Body.DeserializeJson<IEnumerable<TariffResource>>().ToList();
            resources.Should().HaveCount(1);
        }
    }
}