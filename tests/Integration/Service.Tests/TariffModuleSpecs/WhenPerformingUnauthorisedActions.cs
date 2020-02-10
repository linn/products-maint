namespace Linn.Products.Service.Tests.TariffModuleSpecs
{
    using System.Collections.Generic;

    using Linn.Products.Domain;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenPerformingUnauthorisedActions : ContextBase
    {
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
                        with.JsonBody(new TariffResource());
                    }).Result;
        }

        [Test]
        public void ShouldReturnUnauthorisedResult()
        {
            this.TariffService.DidNotReceiveWithAnyArgs().Add(Arg.Any<TariffResource>(), Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldHaveStatusCodeUnauthorised()
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, this.Response.StatusCode);
        }
    }
}
