namespace Linn.Products.Service.Tests.SaHoldStoriesModuleSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingAllSaHoldStories : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var saHoldStory1 = new SaHoldStory
                                  {
                                      HoldStoryId = 1,
                                      ArticleNumber = "AR 1",
                                      DateStarted = DateTime.Today,
                                      PutOnHoldByEmployeeNumber = 1,
                                      ReasonStarted = "Reason 1",
                                      ReasonFinished = "reason2",
                                      RootProduct = "prod"
                                                 
                                  };

            var saHoldStory2 = new SaHoldStory
                                  {
                                      HoldStoryId = 2,
                                      ArticleNumber = "AR 2",
                                      DateStarted = DateTime.Today,
                                      PutOnHoldByEmployeeNumber = 1,
                                      ReasonStarted = "Reason 2"
                                  };
            this.SaHoldStoryService.GetAll()
                .Returns(new SuccessResult<IEnumerable<SaHoldStory>>(new List<SaHoldStory> { saHoldStory1, saHoldStory2 }));

            this.Response = this.Browser.Get(
                "/products/reports/sa-hold-stories/",
                with =>
                    {
                        with.Header("Accept", "application/json");
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
            this.SaHoldStoryService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var r = this.Response.Body;
            var resources = this.Response.Body.DeserializeJson<IEnumerable<SaHoldStoryResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.HoldStoryId == 1);
            resources.Should().Contain(a => a.HoldStoryId == 2);
        }
    }
}
