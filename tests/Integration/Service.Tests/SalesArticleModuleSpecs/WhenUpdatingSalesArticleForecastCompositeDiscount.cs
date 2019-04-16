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

    public class WhenUpdatingSalesArticleForecastCompositeDiscount : ContextBase
    {
        private SalesArticleCompositeDiscount salesArticleCompositeDiscount;

        private SalesArticleCompositeDiscountResource resource;

        [SetUp]
        public void SetUp()
        {
            this.salesArticleCompositeDiscount = new SalesArticleCompositeDiscount
                                                     {
                                                         SalesArticle = "sa",
                                                         BaseSalesArticle = "b",
                                                         NoDiscountSalesArticle = "n"
                                                     };
            this.resource = new SalesArticleCompositeDiscountResource
                                {
                                    BaseArticleNumber = "b",
                                    NoDiscountArticleNumber = "n"
                                };
            this.SalesArticleCompositeDiscountFacadeService.SetCompositeDiscount(
                    "SA",
                    Arg.Any<SalesArticleCompositeDiscountResource>())
                .Returns(new SuccessResult<SalesArticleCompositeDiscount>(this.salesArticleCompositeDiscount));

            this.Response = this.Browser.Put(
                "/products/maint/sales-articles/composite-discounts/sa",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Type", "application/json");
                    with.JsonBody(this.resource);
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
            this.SalesArticleCompositeDiscountFacadeService
                .Received().SetCompositeDiscount(
                    "SA",
                    Arg.Is<SalesArticleCompositeDiscountResource>(r => r.NoDiscountArticleNumber == this.resource.NoDiscountArticleNumber));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var response = this.Response.Body.DeserializeJson<SalesArticleCompositeDiscountResource>();
            response.BaseArticleNumber.Should().Be("b");
        }
    }
}