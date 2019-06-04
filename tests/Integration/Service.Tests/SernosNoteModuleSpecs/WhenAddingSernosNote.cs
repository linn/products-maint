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

    public class WhenAddingSernosNote : ContextBase
    {
        private SernosNoteCreateResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SernosNoteCreateResource()
                                       {
                                           SernosNotes = "notes",
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

            this.SernosNoteService.Add(Arg.Any<SernosNoteCreateResource>(), Arg.Any<IEnumerable<string>>())
                .Returns(new CreatedResult<ResponseModel<SernosNote>>(new ResponseModel<SernosNote>(sernosNote, new List<string>())));

            this.Response = this.Browser.Post(
                "products/maint/serial-numbers/notes",
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
            this.SernosNoteService.Received().Add(
                Arg.Is<SernosNoteCreateResource>(s => s.SernosNotes == this.requestResource.SernosNotes), Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosNoteResource>();
            resource.SernosNotes.Should().Be("notes");
        }
    }
}
