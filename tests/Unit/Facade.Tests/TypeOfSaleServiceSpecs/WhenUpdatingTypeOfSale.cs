namespace Linn.Products.Facade.Tests.TypeOfSaleServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingTypeOfSale : ContextBase
    {
        private IResult<TypeOfSale> result;

        private TypeOfSaleResource resource;

        private string name;

        [SetUp]
        public void SetUp()
        {
            this.name = "name1";
            this.resource = new TypeOfSaleResource
                                {
                                    Name = "type of sale",
                                    Department = "dept",
                                    Description = "desc",
                                    Nominal = "nom",
                                    RealSale = "Y"
                                };
            this.TypeOfSaleRepository.FindById(this.name).Returns(new TypeOfSale(this.name, "de", "no", "dep", "re"));
            this.result = this.Sut.Update(this.name, this.resource);
        }

        [Test]
        public void ShouldAddTypeOfSale()
        {
            this.TypeOfSaleRepository.Received().FindById(this.name);
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<SuccessResult<TypeOfSale>>();
            var dataResult = ((SuccessResult<TypeOfSale>)this.result).Data;
            dataResult.Name.Should().Be(this.name);
            dataResult.Description.Should().Be(this.resource.Description);
            dataResult.Department.Should().Be(this.resource.Department);
            dataResult.Nominal.Should().Be(this.resource.Nominal);
            dataResult.RealSale.Should().Be(this.resource.RealSale);
        }
    }
}
