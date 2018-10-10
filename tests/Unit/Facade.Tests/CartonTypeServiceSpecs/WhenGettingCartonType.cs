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
            this.CartonTypeRepository.GetCarton(this.name)
                .Returns(new CartonType { Name = this.name });
            this.result = this.Sut.GetCartonType(this.name);
        }

        [Test]
        public void ShouldGetCartonType()
        {
            this.CartonTypeRepository.Received().GetCarton(this.name);
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
