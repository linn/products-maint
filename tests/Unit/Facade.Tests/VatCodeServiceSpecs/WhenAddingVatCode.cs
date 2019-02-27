namespace Linn.Products.Facade.Tests.VatCodeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingVatCode : ContextBase
    {
        private VatCodeResource resource;

        private IResult<VatCode> result;

        [SetUp]
        public void SetUp()
        {
            this.resource = new VatCodeResource { Code = "A", Description = "STD UK VAT RATE.", Rate = 20 };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldAddVatCode()
        {
            this.VatCodeRepository.Received().Add(Arg.Any<VatCode>());
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<CreatedResult<VatCode>>();
            var dataResult = ((CreatedResult<VatCode>)this.result).Data;
            dataResult.Code.Should().Be("A");
            dataResult.Description.Should().Be("STD UK VAT RATE.");
            dataResult.Rate.Should().Be(20);
        }
    }
}