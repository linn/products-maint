namespace Linn.Products.Service.Tests.SaHoldStoriesModuleSpecs
{
    using System;
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenTryingToAddAndNotAuthorised : ContextBase
    {
        private SaHoldStoryResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SaHoldStoryResource
            {
                SalesArticle = "KLIMAX/NTK",
                HoldStoryId = 1,
                DateStarted = new DateTime().ToShortDateString(),
                PutOnHoldByEmployee = "Employee",
                ReasonStarted = "reason",
                Links = new LinkResource[0]
            };

            this.AuthorisationService.CanPutProductOnOffHold(Arg.Any<List<string>>()).Returns(false);

            this.Response = this.Browser.Post(
                "/products/maint/sa-hold-stories",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Type", "application/json");
                    with.JsonBody(this.requestResource);
                }).Result;
        }

        [Test]
        public void ShouldReturnUnauthorised()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Test]
        public void ShouldNotCallService()
        {
            this.SaHoldStoryService.DidNotReceiveWithAnyArgs().Add(Arg.Any<SaHoldStoryResource>());
        }
    }
}