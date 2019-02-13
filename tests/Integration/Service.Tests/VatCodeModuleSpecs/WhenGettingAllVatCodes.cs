namespace Linn.Products.Service.Tests.VatCodeModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Service.Tests.VatCodesModuleSpecs;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingAllVatCodes : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var vatCode1 = new VatCode("A", "STD UK VAT RATE.", 20, null, "N", 1);
            var vatCode2 = new VatCode("B", "UK VAT ZERO RATE", 0, "REASON", "Y", 5);

            this.VatCodeService.GetAll().Returns(
                new SuccessResult<IEnumerable<VatCode>>(new List<VatCode> { vatCode1, vatCode2 }));

            this.Response = this.Browser.Get(
                "/products/maint/vat-codes",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.VatCodeService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<VatCodeResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.Code == "A");
            resources.Should().Contain(a => a.Code == "B");
        }
    }
}