namespace Linn.Products.Facade.Tests.SernosSequenceServiceSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingSernosSequence : ContextBase
    {
        private SernosSequenceResource resource;

        private IResult<SernosSequence> result;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SernosSequenceResource
                                {
                                    SequenceName = "KRYSTAL",
                                    Description = "KRYSTAL MOVING COIL CARTRIDGE",
                                    NextSerialNumber = 1940,
                                    DateClosed = 21.February(2019).ToString("o")
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldAddSernosSequence()
        {
            this.SernosSequenceRepository.Received().Add(Arg.Any<SernosSequence>());
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<CreatedResult<SernosSequence>>();
            var dataResult = ((CreatedResult<SernosSequence>)this.result).Data;
            dataResult.SequenceName.Should().Be("KRYSTAL");
            dataResult.Description.Should().Be("KRYSTAL MOVING COIL CARTRIDGE");
            dataResult.NextSerialNumber.Should().Be(1940);
            dataResult.DateClosed.Should().Be(new DateTime(2019, 2, 21));
        }
    }
}