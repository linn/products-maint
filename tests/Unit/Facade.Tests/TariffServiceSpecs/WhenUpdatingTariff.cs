namespace Linn.Products.Facade.Tests.TariffServiceSpecs
{
    using System;

    using FluentAssertions;
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingTariff : ContextBase
    {
        private IResult<Tariff> result;

        private TariffResource resource;

        private int id;

        private Tariff existing;
        [SetUp]
        public void SetUp()
        {
            this.id = 1;

            this.existing = new Tariff
                                {
                                    TariffCode = "random",
                                    Description = "new desc",
                                    DateInvalid = 1.August(2017),
                                    USTariffCode = "changed",
                                    Id = 1
                                };

            this.resource = new TariffResource
                                {
                                    TariffCode = "test",
                                    Description = "new desc",
                                    DateInvalid = 1.August(2018).ToString("o"),
                                    USTariffCode = "test"
                                };
            this.TariffRepository.FindById(this.id)
                .Returns(this.existing);
            this.result = this.Sut.Update(this.id, this.resource);
        }

        [Test]
        public void ShouldGetTariffs()
        {
            this.TariffRepository.Received().FindById(this.id);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<Tariff>>();
            var dataResult = ((SuccessResult<Tariff>)this.result).Data;
            dataResult.Id.Should().Be(this.id);
            dataResult.Description.Should().Be(this.resource.Description);
            dataResult.TariffCode.Should().Be(this.existing.TariffCode);
            dataResult.USTariffCode.Should().Be(this.resource.USTariffCode);
            dataResult.DateInvalid.Should().Be(DateTime.Parse(this.resource.DateInvalid));
        }
    }
}
