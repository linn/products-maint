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
            var serialNumber1 = new SerialNumber("group", "code", "article", 321)
                                    {
                                        SernosNumber = 222,
                                        SernosTRef = 123
                                    };
            var serialNumber2 = new SerialNumber("group a", "code a", "article a", 888)
                                    {
                                        SernosNumber = 222,
                                        SernosTRef = 555
            };

            this.SerialNumberService.Search("222").Returns(
                new SuccessResult<IEnumerable<SerialNumber>>(
                    new List<SerialNumber>
                        {
                            serialNumber1, serialNumber2
                        }));

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
            this.SerialNumberService.Received().Search("222");
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<SerialNumberResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(s => s.SernosTRef == 123);
            resources.Should().Contain(s => s.SernosTRef == 555);
        }
    }
}
