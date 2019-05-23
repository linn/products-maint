namespace Linn.Products.Service.Tests.SalesArticleModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSalesArticleSerialNumberDetails : ContextBase
    {
        private SalesArticleSerialNumberDetails salesArticleSerialNumberDetails;

        [SetUp]
        public void SetUp()
        {
            this.salesArticleSerialNumberDetails = new SalesArticleSerialNumberDetails
                                                       {
                                                           SernosGroup = "group",
                                                           SerialNumberType = "P1"
                                                       };
            this.SalesArticleSerialNumberFacadeService.GetSerialNumberDetails("A").Returns(
                new SuccessResult<SalesArticleSerialNumberDetails>(this.salesArticleSerialNumberDetails));

            this.Response = this.Browser.Get(
                "/products/maint/sales-articles/serial-number-details/A",
                with =>
                    {
                        with.Header("Accept", "application/json");
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
            this.SalesArticleSerialNumberFacadeService.Received().GetSerialNumberDetails("A");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SalesArticleSerialNumberDetailsResource>();
            resource.SerialNumbered.Should().Be("Serial numbered in pairs, one box");
            resource.SernosGroup.Should().Be("group");
        }
    }
}
