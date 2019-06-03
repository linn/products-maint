namespace Linn.Products.Service.Tests.VatCodeModuleSpecs
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

    public class WhenGettingAllVatCodes : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var vatCode1 = new VatCode("A", "STD UK VAT RATE.", 20, null, 1, "N");
            var vatCode2 = new VatCode("B", "UK VAT ZERO RATE", 0, "REASON", 5, "Y");

            this.VatCodeService.GetAll(Arg.Any<IEnumerable<string>>()).Returns(
                new SuccessResult<ResponseModel<IEnumerable<VatCode>>>(
                    new ResponseModel<IEnumerable<VatCode>>(
                        new List<VatCode> { vatCode1, vatCode2 },
                        new List<string>())));

            this.Response = this.Browser.Get(
                "/products/maint/vat-codes",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.VatCodeService.Received().GetAll(Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<ResponseResource<IEnumerable<VatCodeResource>>>().ResponseData.ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.Code == "A");
            resources.Should().Contain(a => a.Code == "B");
        }
    }
}