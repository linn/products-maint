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

    public class WhenAddingProductRange : ContextBase
    {
        private ProductRange productRange;

        private ProductRangeResource resource;

        [SetUp]
        public void SetUp()
        {
            this.productRange = new ProductRange { Id = 3, RangeName = "name", RangeDescription = "desc" };
            this.resource = new ProductRangeResource
                                {
                                    RangeName = "name",
                                    RangeDescription = "desc"
                                };
            this.ProductRangeService.Add(Arg.Any<ProductRangeResource>())
                .Returns(new CreatedResult<ProductRange>(this.productRange));

            this.Response = this.Browser.Post(
                "/products/maint/product-ranges",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Type", "application/json");
                    with.JsonBody(this.resource);
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
            this.ProductRangeService.Received().Add(
                Arg.Is<ProductRangeResource>(r => r.RangeName == this.resource.RangeName));
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