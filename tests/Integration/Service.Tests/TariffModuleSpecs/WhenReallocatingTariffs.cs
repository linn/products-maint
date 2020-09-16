namespace Linn.Products.Service.Tests.TariffModuleSpecs
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

    public class WhenReallocatingTariffs : ContextBase
    {
        private TariffReallocatorResource requestResource;
        [SetUp]
        public void SetUp()
        {
            this.requestResource = new TariffReallocatorResource { NewTariffId = 21, OldTariffId = 20 };

            var tariffReallocatorResponseModel = new ResponseModel<TariffsReallocator>(new TariffsReallocator { NewTariffId = 21, OldTariffId = 20 }, new List<string>());

            this.TariffService.Reallocate(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<List<string>>())
                .Returns(new SuccessResult<ResponseModel<TariffsReallocator>>(tariffReallocatorResponseModel));

            this.AuthorisationService.HasPermissionFor(AuthorisedAction.ReallocateSalesArticles, Arg.Any<List<string>>())
                .Returns(true);

            this.Response = this.Browser.Post(
                "/products/maint/tariffs-reallocate",
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
            this.TariffService.Received().Reallocate(
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
