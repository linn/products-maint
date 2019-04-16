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

    public class WhenGettingSalesArticleCompositeDiscount : ContextBase
    {
        private SalesArticleCompositeDiscount salesArticleCompositeDiscount;

        [SetUp]
        public void SetUp()
        {
            this.salesArticleCompositeDiscount = new SalesArticleCompositeDiscount
                                                     {
                                                         SalesArticle = "sa",
                                                         BaseSalesArticle = "b",
                                                         NoDiscountSalesArticle = "n"
                                                     };
            this.SalesArticleCompositeDiscountFacadeService.GetCompositeDiscount("SA")
                .Returns(new SuccessResult<SalesArticleCompositeDiscount>(this.salesArticleCompositeDiscount));

            this.Response = this.Browser.Get(
                "/products/maint/sales-articles/composite-discounts/sa",
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
            this.SalesArticleCompositeDiscountFacadeService.Received().GetCompositeDiscount("SA");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SalesArticleCompositeDiscountResource>();
            resource.BaseArticleNumber.Should().Be("b");
            resource.NoDiscountArticleNumber.Should().Be("n");
        }
    }
}