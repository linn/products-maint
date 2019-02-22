namespace Linn.Products.Facade.Tests.ProductRangeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdating : ContextBase
    {
        private IResult<ProductRange> result;

        private ProductRangeUpdateResource resource;

        private ProductRange productRange;

        [SetUp]
        public void SetUp()
        {
            this.productRange = new ProductRange
                                    {
                                        Id = 111
                                    };
            this.resource = new ProductRangeUpdateResource
                                {
                                    RangeName = "new name",
                                    RangeDescription = "new description",
                                    DateInvalid = 1.December(2021).ToString("o")
                                };
            this.ProductRangeRepository.FindById(111)
                .Returns(this.productRange);
            this.result = this.Sut.Update(111, this.resource);
        }

        [Test]
        public void ShouldGetRange()
        {
            this.ProductRangeRepository.Received().FindById(111);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<ProductRange>>();
            var dataResult = ((SuccessResult<ProductRange>)this.result).Data;
            dataResult.RangeName.Should().Be(this.resource.RangeName);
            dataResult.RangeDescription.Should().Be(this.resource.RangeDescription);
            dataResult.DateInvalid.Should().Be(1.December(2021));
        }
    }
}
