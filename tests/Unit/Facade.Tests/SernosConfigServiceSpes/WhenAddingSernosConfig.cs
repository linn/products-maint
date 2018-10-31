namespace Linn.Products.Facade.Tests.SernosConfigServiceSpes
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingSernosConfig : ContextBase
    {
        private IResult<SernosConfig> result;

        private SernosConfigResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SernosConfigResource
                                {
                                    Name = "cartonName",
                                    Description = "Desc"
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldAddSernosConfig()
        {
            this.SernosConfigRepository.Received().Add(Arg.Any<SernosConfig>());
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<CreatedResult<SernosConfig>>();
            var dataResult = ((CreatedResult<SernosConfig>)this.result).Data;
            dataResult.Name.Should().Be(this.resource.Name);
            dataResult.Description.Should().Be(this.resource.Description);
        }
    }
}
