namespace Linn.Products.Facade.Tests.CartonTypeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingCartonType : ContextBase
    {
        private IResult<CartonType> result;

        private string name;

        [SetUp]
        public void SetUp()
        {
            this.name = "cartonName";
            this.CartonTypeRepository.FindById(this.name)
                .Returns(new CartonType(this.name, 1, 2, 3));
            this.result = this.Sut.GetById(this.name);
        }

        [Test]
        public void ShouldGetCartonType()
        {
            this.CartonTypeRepository.Received().FindById(this.name);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<CartonType>>();
            var dataResult = ((SuccessResult<CartonType>)this.result).Data;
            dataResult.Name.Should().Be(this.name);
        }
    }
}
