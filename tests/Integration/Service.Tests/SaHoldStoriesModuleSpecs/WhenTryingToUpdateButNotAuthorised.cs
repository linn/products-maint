namespace Linn.Products.Service.Tests.SaHoldStoriesModuleSpecs
{
    using System;
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

    public class WhenTryingToUpdateButNotAuthorised : ContextBase
    {
        private SaHoldStoryResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SaHoldStoryResource
            {
                DateFinished = new DateTime().ToShortDateString(),
                TakenOffHoldByEmployee = "Employee",
                ReasonFinished = "test"
            };
            
            this.AuthorisationService.HasPermissionFor(AuthorisedAction.ProductHold, Arg.Any<List<string>>()).Returns(false);

            this.Response = this.Browser.Put(
                "/products/maint/sa-hold-stories/1",
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
            this.Response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public void ShouldNotCallService()
        {
            this.SaHoldStoryService.DidNotReceiveWithAnyArgs().Update(1, Arg.Any<SaHoldStoryResource>());
        } 
    }
}
