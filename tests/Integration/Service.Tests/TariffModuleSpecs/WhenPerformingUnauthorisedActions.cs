namespace Linn.Products.Service.Tests.TariffModuleSpecs
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenPerformingUnauthorisedActions : ContextBase
    {
        private TariffResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.AuthorisationService.HasPermissionFor(AuthorisedAction.TariffAdmin, Arg.Any<IEnumerable<string>>())
                .Returns(false);

            this.Response = this.Browser.Post(
                "/products/maint/tariffs",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Header("Content-Type", "application/json");
                        with.JsonBody(this.requestResource);
                    }).Result;
        }

        [Test]
        public void ShouldReturnUnauthorisedResult()
        {
            var response = this.Response.Body;

            var random = this.Response.Body.DeserializeJson<UnauthorisedResult<ResponseModel<Tariff>>>();

            Assert.AreEqual("You are not authorised to create or edit tariffs", this.Response.Body.DeserializeJson<UnauthorisedResult<ResponseModel<Tariff>>>().Message);

        }

        [Test]
        public void ShouldHaveStatusCodeUnauthorised()
        {
            Assert.AreEqual(HttpStatusCode.Unauthorized, this.Response.StatusCode);
        }
    }
}
