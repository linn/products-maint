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

    public class WhenGettingProductRangeById : ContextBase
    {
        private ProductRange productRange;

        [SetUp]
        public void SetUp()
        {
            this.productRange =
                new ProductRange { Id = 2, RangeName = "name", RangeDescription = "desc", DateInvalid = null };
            this.ProductRangeService.GetById(2)
                .Returns(new SuccessResult<ProductRange>(this.productRange));

            this.Response = this.Browser.Get(
                "/products/maint/product-ranges/2",
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
            this.ProductRangeService.Received().GetById(2);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<ProductRangeResource>();
            resource.Id.Should().Be(this.productRange.Id);
            resource.RangeName.Should().Be(this.productRange.RangeName);
            resource.RangeDescription.Should().Be(this.productRange.RangeDescription);
            resource.DateInvalid.Should().BeNull();
        }
    }
}