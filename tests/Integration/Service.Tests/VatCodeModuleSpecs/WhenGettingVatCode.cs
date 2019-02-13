namespace Linn.Products.Service.Tests.VatCodeModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Service.Tests.VatCodesModuleSpecs;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingVatCode : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var vatCode = new VatCode("A", "STD UK VAT RATE.", 20, null, "N", 1);
            this.VatCodeService.GetById("A").Returns(new SuccessResult<VatCode>(vatCode) { Data = vatCode });

            this.Response = this.Browser.Get(
                "/products/maint/vat-codes/A",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.VatCodeService.Received().GetById("A");
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<VatCodeResource>();
            resource.Code.Should().Be("A");
        }
    }
}