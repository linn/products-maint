namespace Linn.Products.Service.Tests.TariffModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;
    using NSubstitute.Core.Arguments;

    using NUnit.Framework;

    public class WhenGettingAllTariffs : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var tariff1 = new Tariff { TariffCode = "test", Description = "test-case" };
            var tariff2 = new Tariff { TariffCode = "test-1", Description = "test-case-1" };
            this.TariffService.GetAll(Arg.Any<IEnumerable<string>>()).Returns(
                new SuccessResult<ResponseModel<IEnumerable<Tariff>>>(
                    new ResponseModel<IEnumerable<Tariff>>(new List<Tariff> { tariff1, tariff2 }, new List<string>())));

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
            this.TariffService.Received().GetAll(Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<ResponseResource<IEnumerable<TariffResource>>>().ResponseData.ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.TariffCode == "test" && a.Description == "test-case");
            resources.Should().Contain(a => a.TariffCode == "test-1" && a.Description == "test-case-1");
        }
    }
}
