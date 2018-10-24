namespace Linn.Products.Facade.Tests.CartonTypeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingCartonTypeToBeInvalid : ContextBase
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
                                    Description = "new desc"
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
        public void ShouldReturnBadRequest()
        {
            this.result.Should().BeOfType<BadRequestResult<CartonType>>();
        }
    }
}
