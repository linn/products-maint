namespace Linn.Products.Service.Tests.SernosNoteModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSernosNoteByQuery : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosNote = new SernosNote("notes")
                                 {
                                     SernosGroup = "group",
                                     SernosNoteId = 111,
                                     SernosNumber = 222,
                                     SernosTRef = 333,
                                     TransCode = "code"
                                 };

            this.SernosNoteService.GetSernosNote("group", 222, "code")
                .Returns(new SuccessResult<SernosNote>(sernosNote) { Data = sernosNote });

            this.Response = this.Browser.Get(
                "/products/maint/serial-numbers/notes",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Query("sernosGroup", "group");
                        with.Query("sernosNumber", "222");
                        with.Query("transCode", "code");
                    }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosNoteService.Received().GetSernosNote("group", 222, "code");
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosNoteResource>();
            resource.SernosNotes.Should().Be("notes");
            resource.SernosNoteId.Should().Be(111);
        }
    }
}
