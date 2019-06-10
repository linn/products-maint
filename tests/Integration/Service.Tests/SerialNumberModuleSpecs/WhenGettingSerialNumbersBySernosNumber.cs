namespace Linn.Products.Service.Tests.SerialNumberModuleSpecs
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

    public class WhenGettingSerialNumbersBySernosNumber : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var serialNumber1 =
                new ArchiveSerialNumber { SernosGroup = "group", SernosNumber = 222, TransCode = "code" };

            var serialNumber2 =
                new ArchiveSerialNumber { SernosGroup = "new group", SernosNumber = 222, TransCode = "new code" };

            this.ArchiveSerialNumberService.Search("222", Arg.Any<IEnumerable<string>>()).Returns(
                new SuccessResult<ResponseModel<IEnumerable<ArchiveSerialNumber>>>(
                    new ResponseModel<IEnumerable<ArchiveSerialNumber>>(
                        new List<ArchiveSerialNumber> { serialNumber1, serialNumber2 }, 
                        new List<string>())));

            this.Response = this.Browser.Get(
                "products/maint/serial-numbers",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Query("sernosNumber", "222");
                    }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.ArchiveSerialNumberService.Received().Search("222", Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body
                .DeserializeJson<ResponseResource<IEnumerable<ArchiveSerialNumberResource>>>().ResponseData.ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(s => s.SernosGroup == "group");
            resources.Should().Contain(s => s.SernosGroup == "new group");
        }
    }
}
