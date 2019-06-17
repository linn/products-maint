namespace Linn.Products.Service.Tests.RootProductModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenSearching : ContextBase
    {
        private IResult<IEnumerable<RootProduct>> rootProducts;

        [SetUp]
        public void SetUp()
        {
            var list = new[] { new RootProduct { Name = "rp", Description = "a root product" } };
            this.rootProducts = new SuccessResult<IEnumerable<RootProduct>>(list);
            this.RootProductService.Search("sa").Returns(this.rootProducts);

            this.Response = this.Browser.Get(
                "/products/maint/root-products",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Query("searchTerm", "sa");
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
            this.RootProductService.Received().Search("sa");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<IEnumerable<RootProductResource>>().ToList();
            resource.Should().HaveCount(1);
            resource.First().Name.Should().Be("rp");
        }
    }
}