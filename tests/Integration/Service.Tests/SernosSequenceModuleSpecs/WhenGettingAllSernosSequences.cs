namespace Linn.Products.Service.Tests.SernosSequenceModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingAllSernosSequences : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosSequence1 = new SernosSequence(
                "KRYSTAL",
                "KRYSTAL MOVING COIL CARTRIDGE",
                1940,
                21.February(2019));
            var sernosSequence2 = new SernosSequence("QNAP", "QNAP NAS (TS210)", 10000, null);
            this.SernosSequenceService.GetAll().Returns(
                new SuccessResult<IEnumerable<SernosSequence>>(
                    new List<SernosSequence> { sernosSequence1, sernosSequence2 }));

            this.Response = this.Browser.Get(
                "/products/maint/sernos-sequences",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosSequenceService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<SernosSequenceResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.SequenceName == "KRYSTAL");
            resources.Should().Contain(a => a.SequenceName == "QNAP");
        }
    }
}
