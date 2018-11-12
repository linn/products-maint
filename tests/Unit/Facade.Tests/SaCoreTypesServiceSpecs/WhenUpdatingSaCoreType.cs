namespace Linn.Products.Facade.Tests.SaCoreTypesServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSaCoreType : ContextBase
    {
        private IResult<SaCoreType> result;

        private SaCoreTypeResource resource;

        [SetUp]
        public void SetUp()
        {
            
            this.resource = new SaCoreTypeResource()
                                {
                                    CoreType = 1,
                                    Description = "new desc",
                                    DateInvalid = 28.March(1995).ToString("o"),
                                    SortOrder = 2,
                                    LookAheadDays = 10,
                                    TriggerLevel = 1
                                };
            this.SaCoreTypeRepository.FindById(1)
                .Returns(new SaCoreType(1, "desc"));
            this.result = this.Sut.Update(1, this.resource);
        }

        [Test]
        public void ShouldGetSaCoreType()
        {
            this.SaCoreTypeRepository.Received().FindById(1);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<SaCoreType>>();
            var dataResult = ((SuccessResult<SaCoreType>)this.result).Data;
            dataResult.CoreType.Should().Be(1);
            dataResult.Description.Should().Be("new desc");
        }
    }
}
