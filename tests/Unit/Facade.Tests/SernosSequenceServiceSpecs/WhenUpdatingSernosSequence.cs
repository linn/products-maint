namespace Linn.Products.Facade.Tests.SernosSequenceServiceSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSernosSequence : ContextBase
    {
        private SernosSequenceResource resource;

        private IResult<SernosSequence> result;

        private string sequenceName;

        [SetUp]
        public void SetUp()
        {
            this.sequenceName = "QNAP";

            this.resource = new SernosSequenceResource
                                {
                                    SequenceName = "KRYSTAL",
                                    Description = "KRYSTAL MOVING COIL CARTRIDGE",
                                    NextSerialNumber = 1940,
                                    DateClosed = 21.February(2019).ToString("o")
                                };

            this.SernosSequenceRepository.FindById(this.sequenceName).Returns(
                new SernosSequence(this.sequenceName, "QNAP NAS (TS210)", 10000, null));
            this.result = this.Sut.Update(this.sequenceName, this.resource);
        }

        [Test]
        public void ShouldAddSernosSequence()
        {
            this.SernosSequenceRepository.Received().FindById(this.sequenceName);
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<SuccessResult<SernosSequence>>();
            var dataResult = ((SuccessResult<SernosSequence>)this.result).Data;
            dataResult.SequenceName.Should().Be(this.sequenceName);
            dataResult.Description.Should().Be("KRYSTAL MOVING COIL CARTRIDGE");
            dataResult.NextSerialNumber.Should().Be(1940);
            dataResult.DateClosed.Should().Be(new DateTime(2019, 2, 21));
        }
    }
}