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
        private TariffReallocatorResource requestResource;
        [SetUp]
        public void SetUp()
        {
            this.requestResource = new TariffReallocatorResource { NewTariffId = 21, OldTariffId = 20 };

            var salesArticleReallocatorResponseModel = new ResponseModel<TariffsReallocator>(new TariffsReallocator { NewTariffId = 21, OldTariffId = 20 }, new List<string>());

            this.SalesArticleForecastService.Reallocate(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<List<string>>())
                .Returns(new SuccessResult<ResponseModel<TariffsReallocator>>(salesArticleReallocatorResponseModel));

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
                Arg.Any<int>(),
                Arg.Any<int>(),
                Arg.Any<List<string>>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<TariffReallocatorResource>();
            resource.OldTariffId.Should().Be(this.requestResource.OldTariffId);
            resource.NewTariffId.Should().Be(this.requestResource.NewTariffId);
        }
    }
}
