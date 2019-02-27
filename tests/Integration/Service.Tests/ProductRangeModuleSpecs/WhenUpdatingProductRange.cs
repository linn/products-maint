namespace Linn.Products.Service.Tests.ProductRangeModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingProductRange : ContextBase
    {
        private ProductRange productRange;

        private ProductRangeUpdateResource resource;

        [SetUp]
        public void SetUp()
        {
            this.productRange = new ProductRange { Id = 3, RangeName = "name" };
            this.resource = new ProductRangeUpdateResource
                                {
                                    RangeName = "name"
                                };
            this.ProductRangeService.Update(3, Arg.Any<ProductRangeUpdateResource>())
                .Returns(new SuccessResult<ProductRange>(this.productRange));

            this.Response = this.Browser.Put(
                "/products/maint/product-ranges/3",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Type", "application/json");
                    with.JsonBody(this.resource);
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
            this.ProductRangeService.Received().Update(
                3,
                Arg.Is<ProductRangeUpdateResource>(r => r.RangeName == this.resource.RangeName));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var response = this.Response.Body.DeserializeJson<ProductRangeResource>();
            response.Id.Should().Be(this.productRange.Id);
            response.RangeName.Should().Be(this.resource.RangeName);
        }
    }
}