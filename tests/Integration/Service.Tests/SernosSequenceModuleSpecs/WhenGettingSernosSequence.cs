namespace Linn.Products.Service.Tests.SernosSequenceModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSernosSequence : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosSequence = new SernosSequence("KRYSTAL", "KRYSTAL MOVING COIL CARTRIDGE", 1940, 21.February(2019));
            this.SernosSequenceService.GetById("KRYSTAL").Returns(
                new SuccessResult<SernosSequence>(sernosSequence) { Data = sernosSequence });

            this.Response = this.Browser.Get(
                "/products/maint/sernos-sequences/KRYSTAL",
                with =>
                    {
                        with.Header("Accept", "application/json");
                    }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosSequenceService.Received().GetById("KRYSTAL");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosSequenceResource>();
            resource.SequenceName.Should().Be("KRYSTAL");
        }
    }
}
