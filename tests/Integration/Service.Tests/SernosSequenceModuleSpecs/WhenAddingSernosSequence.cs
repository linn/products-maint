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

    public class WhenAddingSernosSequence : ContextBase
    {
        private SernosSequenceResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SernosSequenceResource { SequenceName = "KRYSTAL" };
            var sernosSequence = new SernosSequence("KRYSTAL", "KRYSTAL MOVING COIL CARTRIDGE", 1940, 21.February(2019));
            this.SernosSequenceService.Add(Arg.Any<SernosSequenceResource>()).Returns(
                new CreatedResult<SernosSequence>(sernosSequence) { Data = sernosSequence });

            this.Response = this.Browser.Post(
                "/products/maint/sernos-sequences",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Header("Content-Type", "application/json");
                        with.JsonBody(this.requestResource);
                    }).Result;
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosSequenceService.Received().Add(
                Arg.Is<SernosSequenceResource>(r => r.SequenceName == this.requestResource.SequenceName));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosSequenceResource>();
            resource.SequenceName.Should().Be("KRYSTAL");
        }
    }
}
