namespace Linn.Products.Facade.Tests.SaCoreTypesServiceSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddinSaCoreTypeWithNullDateInvalid : ContextBase
    {
        private IResult<SaCoreType> result;

        private SaCoreTypeResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SaCoreTypeResource
                                {
                                    CoreType = 1,
                                    Description = "Desc",
                                    DateInvalid = null
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldAddSaCoreType()
        {
            this.SaCoreTypeRepository.Received().Add(Arg.Any<SaCoreType>());
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<CreatedResult<SaCoreType>>();
            var dataResult = ((CreatedResult<SaCoreType>)this.result).Data;
            dataResult.Description.Should().Be(this.resource.Description);
            dataResult.CoreType.Should().Be(1);
            dataResult.DateInvalid.Should().Be(null);
        }
    }
}
