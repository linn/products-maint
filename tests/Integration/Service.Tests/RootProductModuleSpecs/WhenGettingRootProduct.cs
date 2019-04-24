namespace Linn.Products.Service.Tests.RootProductModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingRootProductById : ContextBase
    {
        private RootProduct rootProduct;

        [SetUp]
        public void SetUp()
        {
            this.rootProduct = new RootProduct { Name = "rp" };
            this.RootProductService.GetById("rp").Returns(new SuccessResult<RootProduct>(this.rootProduct));

            this.Response = this.Browser.Get(
                "/products/maint/root-products/rp",
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
            this.RootProductService.Received().GetById("rp");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<RootProductResource>();
            resource.Name.Should().Be("rp");
        }
    }
}