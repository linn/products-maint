namespace Linn.Products.Facade.Tests.TypeOfSaleServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingInvalidTypeOfSale : ContextBase
    {
        private IResult<TypeOfSale> result;

        private TypeOfSaleResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new TypeOfSaleResource
                                {
                                    Department = "dept",
                                    Description = "desc",
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldAddTypeOfSale()
        {
            this.TypeOfSaleRepository.DidNotReceive().Add(Arg.Any<TypeOfSale>());
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<BadRequestResult<TypeOfSale>>();
        }
    }
}
