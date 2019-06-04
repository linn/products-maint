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

            this.SernosNoteService.Search("222", Arg.Any<IEnumerable<string>>()).Returns(
                new SuccessResult<ResponseModel<IEnumerable<SernosNote>>>(
                    new ResponseModel<IEnumerable<SernosNote>>(
                        new List<SernosNote> { sernosNote1, sernosNote2 }, 
                        new List<string>())));

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
            this.SernosNoteService.Received().Search("222", Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<ResponseResource<IEnumerable<SernosNoteResource>>>().ResponseData.ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(s => s.SernosNoteId == 111);
            resources.Should().Contain(s => s.SernosNoteId == 11123);
        }
    }
}