namespace Linn.Products.Service.Tests.ProductRangeModuleSpecs
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

    public class WhenGettingProductRanges : ContextBase
    {
        private ProductRange productRange;

        [SetUp]
        public void SetUp()
        {
            this.productRange =
                new ProductRange { Id = 2, RangeName = "name", RangeDescription = "desc", DateInvalid = null };
            this.ProductRangeService.GetAll().Returns(
                new SuccessResult<IEnumerable<ProductRange>>(new List<ProductRange> { this.productRange }));

            this.Response = this.Browser.Get(
                "/products/maint/product-ranges",
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
            this.ProductRangeService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<ProductRangeResource>>().ToList();
            resources.Should().HaveCount(1);
            var resource = resources.First();
            resource.Id.Should().Be(this.productRange.Id);
            resource.RangeName.Should().Be(this.productRange.RangeName);
            resource.RangeDescription.Should().Be(this.productRange.RangeDescription);
            resource.DateInvalid.Should().Be(null);
        }
    }
}