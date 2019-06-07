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

    public class WhenGettingSernosNoteById : ContextBase
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

            this.SernosNoteService.GetById(111)
                .Returns(new SuccessResult<SernosNote>(sernosNote) { Data = sernosNote });

            this.Response = this.Browser.Get(
                "/products/maint/serial-numbers/notes/111",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosNoteService.Received().GetById(111);
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
