namespace Linn.Products.Facade.Tests.TypeOfSaleServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingTypeOfSale : ContextBase
    {
        private IResult<TypeOfSale> result;

        private TypeOfSaleResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new TypeOfSaleResource
                                {
                                    Name = "type of sale",
                                    Department = "dept",
                                    Description = "desc",
                                    Nominal = "nom",
                                    RealSale = "Y"
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldAddTypeOfSale()
        {
            this.TypeOfSaleRepository.Received().Add(Arg.Any<TypeOfSale>());
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<CreatedResult<TypeOfSale>>();
            var dataResult = ((CreatedResult<TypeOfSale>)this.result).Data;
            dataResult.Name.Should().Be(this.resource.Name);
            dataResult.Description.Should().Be(this.resource.Description);
            dataResult.Department.Should().Be(this.resource.Department);
            dataResult.Nominal.Should().Be(this.resource.Nominal);
            dataResult.RealSale.Should().Be(this.resource.RealSale);
        }
    }
}
