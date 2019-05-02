namespace Linn.Products.Service.Tests.SerialNumberModuleSpecs
{
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
            var serialNumber = new SerialNumber(123, "group", "code", "article", 321)
                                   {
                                       SernosNumber = 222
                                   };

            this.SerialNumberService.GetById(123)
                .Returns(new SuccessResult<SerialNumber>(serialNumber) { Data = serialNumber });

            this.Response = this.Browser.Get(
                "/products/maint/serial-numbers/123",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.SerialNumberService.Received().GetById(123);
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
