namespace Linn.Products.Service.Tests.SaHoldStoriesModuleSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingSaHoldStory : ContextBase
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
                                       };
            var holdStory = new SaHoldStory
                                {
                                    HoldStoryId = 1,
                                    DateStarted = new DateTime(),
                                    PutOnHoldByEmployee = new Employee { Id = 1, FullName = "Employee" },
                                    ArticleNumber = "KLIMAX/NTK",
                                    SalesArticle = new SalesArticle { ArticleNumber = "KLIMAX/NTK" },
                                    ReasonStarted = "reason",
                                };

            this.SaHoldStoryService.Add(Arg.Any<SaHoldStoryResource>())
                .Returns(new SuccessResult<SaHoldStory>(holdStory));

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
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SaHoldStoryService.Received().Add(
                Arg.Is<SaHoldStoryResource>(r => r.HoldStoryId == this.requestResource.HoldStoryId));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SaHoldStoryResource>();
            resource.HoldStoryId.Should().Be(1);
        }
    }
}