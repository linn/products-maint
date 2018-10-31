namespace Linn.Products.Facade.Tests.SernosConfigServiceSpes
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSernosConfig : ContextBase
    {
        private IResult<SernosConfig> result;

        private SernosConfigResource resource;

        private string name;

        [SetUp]
        public void SetUp()
        {
            this.name = "c1";
            this.resource = new SernosConfigResource
                                {
                                    Name = "Nonsense",
                                    Description = "new desc",
                                    SerialNumbered = "Y",
                                    NumberOfSernos = 2,
                                    NumberOfBoxes = 1,
                                    StartOn = "ANY"
                                };
            this.SernosConfigRepository.FindById(this.name)
                .Returns(new SernosConfig(this.name, "N", 1, 1));
            this.result = this.Sut.Update(this.name, this.resource);
        }

        [Test]
        public void ShouldGetSernosConfig()
        {
            this.SernosConfigRepository.Received().FindById(this.name);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<SernosConfig>>();
            var dataResult = ((SuccessResult<SernosConfig>)this.result).Data;
            dataResult.Name.Should().Be(this.name);
            dataResult.Description.Should().Be(this.resource.Description);
            dataResult.SerialNumbered.Should().Be("Y");
            dataResult.StartOn.Should().Be("ANY");
        }
    }
}
