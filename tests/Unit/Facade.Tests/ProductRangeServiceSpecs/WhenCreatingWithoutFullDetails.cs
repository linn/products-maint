namespace Linn.Products.Facade.Tests.ProductRangeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenCreatingWithoutFullDetails : ContextBase
    {
        private IResult<ProductRange> result;

        private ProductRangeResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new ProductRangeResource
                                {
                                    RangeName = "new name"
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldNotAddRange()
        {
            this.ProductRangeRepository.DidNotReceive().Add(Arg.Any<ProductRange>());
        }

        [Test]
        public void ShouldReturnBadRequestResult()
        {
            this.result.Should().BeOfType<BadRequestResult<ProductRange>>();
        }
    }
}
