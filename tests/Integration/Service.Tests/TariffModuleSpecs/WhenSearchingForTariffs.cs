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

    using NUnit.Framework;

    public class WhenSearchingForTariffs : ContextBase
    {
        private string searchTerm;

        [SetUp]
        public void SetUp()
        {
            this.searchTerm = "test-1";

            var tariff2 = new Tariff
            {
                TariffCode = "test-1",
                Description = "test-case-1"
            };
            this.TariffService.Search(this.searchTerm, Arg.Any<IEnumerable<string>>())
                .Returns(new SuccessResult<ResponseModel<IEnumerable<Tariff>>>(
                    new ResponseModel<IEnumerable<Tariff>>(
                        new List<Tariff> { tariff2 },
                        new List<string>())));

            this.Response = this.Browser.Get(
                "/products/maint/tariffs",
                with =>
                    {
                        with.HttpRequest();
                        with.Header("Accept", "application/json");
                        with.Query("searchTerm", this.searchTerm);
                    }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResourceFilteredBySearchTerm()
        {
            var resources = this.Response.Body.DeserializeJson<ResponseResource<IEnumerable<TariffResource>>>().ResponseData.ToList();
            resources.Should().HaveCount(1);
            resources.Should().Contain(a => a.TariffCode == "test-1");
        }
    }
}
