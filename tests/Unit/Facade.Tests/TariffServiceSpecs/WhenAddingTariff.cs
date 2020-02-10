namespace Linn.Products.Facade.Tests.TariffServiceSpecs
{
    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NUnit.Framework;

    public class WhenAddingTariff : ContextBase
    {
        private IResult<Tariff> result;

        private TariffResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new TariffResource
                                {
                                    TariffCode = "test",
                                    Description = "Desc",
                                    Duty = 1m,
                                    DateInvalid = 12.December(2018).ToString("o"),
                                    Links = new[] { new LinkResource("entered-by", "/employees/123") }
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<CreatedResult<Tariff>>();
            var dataResult = ((CreatedResult<Tariff>)this.result).Data;
            dataResult.TariffCode.Should().Be(this.resource.TariffCode);
            dataResult.Description.Should().Be("Desc");
            dataResult.Duty.Should().Be(this.resource.Duty);
            dataResult.EnteredBy.Should().Be(123);
        }
    }
}
