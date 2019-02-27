namespace Linn.Products.Facade.Tests.ProductRangeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenCreating : ContextBase
    {
        private IResult<ProductRange> result;

        private ProductRangeResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new ProductRangeResource
                                {
                                    RangeName = "new name",
                                    RangeDescription = "new description"
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldAddRange()
        {
            this.ProductRangeRepository
                .Received().Add(Arg.Is<ProductRange>(r => r.RangeName == this.resource.RangeName));
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<CreatedResult<ProductRange>>();
            var dataResult = ((CreatedResult<ProductRange>)this.result).Data;
            dataResult.RangeName.Should().Be(this.resource.RangeName);
            dataResult.RangeDescription.Should().Be(this.resource.RangeDescription);
            dataResult.DateInvalid.Should().BeNull();
        }
    }
}
