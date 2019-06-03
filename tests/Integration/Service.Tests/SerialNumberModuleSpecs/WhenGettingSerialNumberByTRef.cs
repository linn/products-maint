namespace Linn.Products.Service.Tests.SerialNumberModuleSpecs
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

    public class WhenGettingSerialNumberByTRef : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var serialNumber = new SerialNumber("group", "code", "article", 321)
                                   {
                                       SernosNumber = 222,
                                       SernosTRef = 123
                                   };

            this.SerialNumberService.GetById(123, Arg.Any<IEnumerable<string>>())
                .Returns(new SuccessResult<ResponseModel<SerialNumber>>(new ResponseModel<SerialNumber>(serialNumber, new List<string>())));

            this.Response = this.Browser.Get(
                "/products/maint/serial-numbers/123",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.SerialNumberService.Received().GetById(123, Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SerialNumberResource>();
            resource.SernosNumber.Should().Be(222);
            resource.SernosTRef.Should().Be(123);
        }
    }
}
