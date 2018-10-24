namespace Linn.Products.Facade.Tests.CartonTypeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingCartonType : ContextBase
    {
        private IResult<CartonType> result;

        private CartonTypeUpdateResource resource;

        private string name;

        [SetUp]
        public void SetUp()
        {
            this.name = "c1";
            this.resource = new CartonTypeUpdateResource
                                {
                                    Description = "new desc",
                                    Height = 4m,
                                    Depth = 4m,
                                    Width = 4m,
                                };
            this.CartonTypeRepository.GetCarton(this.name)
                .Returns(new CartonType(this.name, 1, 1, 1));
            this.result = this.Sut.UpdateCartonType(this.name, this.resource);
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
            dataResult.Description.Should().Be(this.resource.Description);
            dataResult.Height.Should().Be(this.resource.Height);
            dataResult.Width.Should().Be(this.resource.Width);
            dataResult.Depth.Should().Be(this.resource.Depth);
        }
    }
}
