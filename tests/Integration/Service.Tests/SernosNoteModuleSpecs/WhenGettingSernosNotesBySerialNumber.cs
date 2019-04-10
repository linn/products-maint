namespace Linn.Products.Service.Tests.SernosNoteModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSernosNotesBySerialNumber : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosNote1 = new SernosNote("notes")
                                  {
                                      SernosGroup = "group",
                                      SernosNoteId = 111,
                                      SernosNumber = 222,
                                      SernosTRef = 333,
                                      TransCode = "code"
                                  };

            var sernosNote2 = new SernosNote("notes")
                                  {
                                      SernosGroup = "other group",
                                      SernosNoteId = 11123,
                                      SernosNumber = 222,
                                      SernosTRef = 333432,
                                      TransCode = "code"
                                  };

            this.SernosNoteService.GetSernosNotesBySerialNumber(222).Returns(
                new SuccessResult<IEnumerable<SernosNote>>(new List<SernosNote> { sernosNote1, sernosNote2 }));

            this.Response = this.Browser.Get(
                "/products/maint/serial-numbers/notes",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Query("sernosNumber", "222");
                    }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosNoteService.Received().GetSernosNotesBySerialNumber(222);
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<SernosNoteResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(s => s.SernosNoteId == 111);
            resources.Should().Contain(s => s.SernosNoteId == 11123);
        }
    }
}