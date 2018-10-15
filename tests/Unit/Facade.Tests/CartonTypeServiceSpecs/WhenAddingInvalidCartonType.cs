namespace Linn.Products.Facade.Tests.CartonTypeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingInvalidCartonType : ContextBase
    {
        private IResult<CartonType> result;

        private CartonTypeResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new CartonTypeResource
                                {
                                    Description = "Desc"
                                };

            this.result = this.Sut.AddCartonType(this.resource);
        }

        [Test]
        public void ShouldNotAddCartonType()
        {
            this.CartonTypeRepository.DidNotReceive().Add(Arg.Any<CartonType>());
        }

        [Test]
        public void ShouldReturnBadRequest()
        {
            this.result.Should().BeOfType<BadRequestResult<CartonType>>();
        }
    }
}
