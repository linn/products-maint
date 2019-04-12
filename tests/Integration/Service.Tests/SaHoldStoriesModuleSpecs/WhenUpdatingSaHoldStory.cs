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

    public class WhenUpdatingSaHoldStory : ContextBase
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
            var holdStory = new SaHoldStory
                                {
                                    HoldStoryId = 1,
                                    DateStarted = new DateTime(),
                                    PutOnHoldByEmployee = new Employee { Id = 1, FullName = "Employee" },
                                    ArticleNumber = "KLIMAX/NTK",
                                    SalesArticle = new SalesArticle { ArticleNumber = "KLIMAX/NTK" },
                                    ReasonStarted = "reason"
                                };

            this.SaHoldStoryService.Update(1, Arg.Any<SaHoldStoryResource>())
                .Returns(new SuccessResult<SaHoldStory>(holdStory)
                {
                    Data = new SaHoldStory
                               {
                                   HoldStoryId = 1,
                                   SalesArticle = new SalesArticle { ArticleNumber = "KLIMAX/NTK" },
                                   PutOnHoldByEmployee = new Employee { Id = 1, FullName = "Employee" },
                                   TakenOffHoldByEmployee = new Employee { Id = 1, FullName = "Employee" },
                                   ReasonFinished = "test"
                    }
                });

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
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SaHoldStoryService.Received().Update(
                1,
                Arg.Is<SaHoldStoryResource>(r => r.ReasonFinished == this.requestResource.ReasonFinished));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SaHoldStoryResource>();
            resource.HoldStoryId.Should().Be(1);
            resource.ReasonFinished.Should().Be("test");
        }
    }
}
