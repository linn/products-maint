namespace Linn.Products.Service.Tests.SalesArticleModuleSpecs
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Linn.Common.Facade;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;
    using Nancy;
    using Nancy.Testing;
    using NSubstitute;
    using NUnit.Framework;

    public class WhenReallocatingSalesArticles : ContextBase
    {
        private SalesArticlesReallocatorResource requestResource;
        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SalesArticlesReallocatorResource { NewTariffId = "21", OldTariffId = "20" };

            var salesArticleReallocator = new SalesArticlesReallocator { NewTariffId = 21, OldTariffId = 20 };

            this.SalesArticleForecastService.Reallocate(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<List<string>>())
                .Returns(new SuccessResult<ResponseModel<SalesArticlesReallocator>>(new ResponseModel<SalesArticlesReallocator>(
                    salesArticleReallocator, new List<string>())));

            this.AuthorisationService.HasPermissionFor(AuthorisedAction.ReallocateSalesArticles, Arg.Any<List<string>>())
                .Returns(true);

            this.Response = this.Browser.Post(
                "/products/maint/sales-articles-reallocate",
                with =>
                    {
                        with.Header("Accept", "application/json");
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
            this.SalesArticleForecastService.Received().Reallocate(
                Arg.Any<string>(),
                Arg.Any<string>(),
                Arg.Any<List<string>>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SalesArticlesReallocatorResource>();
            resource.OldTariffId.Should().Be(this.requestResource.OldTariffId);
            resource.NewTariffId.Should().Be(this.requestResource.NewTariffId);
        }
    }
}
