namespace Linn.Products.Facade.Tests.VatCodeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingVatCode : ContextBase
    {
        private string code;

        private VatCodeResource resource;

        private IResult<VatCode> result;

        [SetUp]
        public void SetUp()
        {
            this.code = "A";

            this.resource = new VatCodeResource { Code = "A", Description = "STD UK VAT RATE.", Rate = 20 };

            this.VatCodeRepository.FindById(this.code).Returns(new VatCode("A", "desc", 3, null, "N", 1));

            this.result = this.Sut.Update(this.code, this.resource);
        }

        [Test]
        public void ShouldGetVatCode()
        {
            this.VatCodeRepository.Received().FindById(this.code);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<VatCode>>();
            var dataResult = ((SuccessResult<VatCode>)this.result).Data;
            dataResult.Code.Should().Be("A");
            dataResult.Description.Should().Be("STD UK VAT RATE.");
            dataResult.Rate.Should().Be(20);
        }
    }
}