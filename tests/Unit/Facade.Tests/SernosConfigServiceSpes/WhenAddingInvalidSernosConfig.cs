namespace Linn.Products.Facade.Tests.SernosConfigServiceSpes
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingInvalidSernosConfig : ContextBase
    {
        private IResult<SernosConfig> result;

        private SernosConfigResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SernosConfigResource
                                {
                                    SerialNumbered = "Y",
                                    Description = "Desc"
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldNotAddSernosConfig()
        {
            this.SernosConfigRepository.DidNotReceive().Add(Arg.Any<SernosConfig>());
        }

        [Test]
        public void ShouldReturnBadRequest()
        {
            this.result.Should().BeOfType<BadRequestResult<SernosConfig>>();
        }
    }
}
