namespace Linn.Products.Facade.Tests.CartonTypeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingCartonTypeNotFound : ContextBase
    {
        private IResult<CartonType> result;

        private string name;

        [SetUp]
        public void SetUp()
        {
            this.name = "cartonName";
            this.CartonTypeRepository.FindById(this.name)
                .Returns((CartonType)null);
            this.result = this.Sut.GetById(this.name);
        }

        [Test]
        public void ShouldGetCartonType()
        {
            this.CartonTypeRepository.Received().FindById(this.name);
        }

        [Test]
        public void ShouldReturnNotFound()
        {
            this.result.Should().BeOfType<NotFoundResult<CartonType>>();
        }
    }
}
