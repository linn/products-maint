namespace Linn.Products.Service.Tests.SernosNoteModuleSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSernosNote : ContextBase
    {
        private SernosNoteResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SernosNoteResource
                                       {
                                           SernosNotes = "notes",
                                           SernosNoteId = 111,
                                           SernosGroup = "group",
                                           SernosNumber = 222,
                                           SernosTRef = 333,
                                           TransCode = "code"
                                       };

            var sernosNote = new SernosNote("notes")
                                 {
                                     SernosNoteId = 111,
                                     SernosGroup = "group",
                                     SernosNumber = 222,
                                     SernosTRef = 333,
                                     TransCode = "code"
                                 };

            this.SernosNoteService.Update(111, Arg.Any<SernosNoteResource>(), Arg.Any<IEnumerable<string>>())
                .Returns(new SuccessResult<ResponseModel<SernosNote>>(new ResponseModel<SernosNote>(sernosNote, new List<string>())));

            this.Response = this.Browser.Put(
                "/products/maint/serial-numbers/notes/111",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Header("Content-Type", "application/json");
                        with.JsonBody(this.requestResource);
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
            this.SernosNoteService.Received().Update(111, Arg.Is<SernosNoteResource>(r => r.SernosNotes == "notes"), Arg.Any<IEnumerable<string>>());
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
