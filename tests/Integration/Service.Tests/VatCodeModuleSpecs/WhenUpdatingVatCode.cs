namespace Linn.Products.Service.Tests.VatCodeModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingVatCode : ContextBase
    {
        private VatCodeResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new VatCodeResource { Description = "new description", Rate = 55 };
            var vatCode = new VatCode("A", "STD UK VAT RATE.", 20, null, 1, "N") { Description = "new description" };
            this.VatCodeService.Update("A", Arg.Any<VatCodeResource>())
                .Returns(new SuccessResult<VatCode>(vatCode)
                             {
                                 Data = vatCode
                             });

            this.Response = this.Browser.Put(
                "/products/maint/vat-codes/A",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Type", "application/json");
                    with.JsonBody(this.requestResource);
                }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.VatCodeService.Received()
                .Update(
                    "A",
                    Arg.Is<VatCodeResource>(r => r.Description == this.requestResource.Description));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<VatCodeResource>();
            resource.Code.Should().Be("A");
            resource.Description.Should().Be("new description");
        }
    }
}