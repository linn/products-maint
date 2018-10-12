namespace Linn.Products.Facade.Tests.CartonTypeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingCartonType : ContextBase
    {
        private IResult<CartonType> result;

        private CartonTypeResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new CartonTypeResource
                                {
                                    Name = "cartonName",
                                    Description = "Desc",
                                    Width = 2m,
                                    Depth = 3m,
                                    Height = 4m
                                };

            this.result = this.Sut.AddCartonType(this.resource);
        }

        [Test]
        public void ShouldAddCartonType()
        {
            this.CartonTypeRepository.Received().Add(Arg.Any<CartonType>());
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<CreatedResult<CartonType>>();
            var dataResult = ((CreatedResult<CartonType>)this.result).Data;
            dataResult.Name.Should().Be(this.resource.Name);
            dataResult.Description.Should().Be(this.resource.Description);
            dataResult.Height.Should().Be(this.resource.Height);
            dataResult.Depth.Should().Be(this.resource.Depth);
            dataResult.Width.Should().Be(this.resource.Width);
            dataResult.NumberOfLargeLabels.Should().Be(1);
            dataResult.NumberOfSmallLabels.Should().Be(0);
        }
    }
}
