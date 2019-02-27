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

    public class WhenGettingSaHoldStory : ContextBase
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
 
            this.SaHoldStoryService.GetById(1)
                .Returns(new SuccessResult<SaHoldStory>(saHoldStory1)
                             {
                                 Data = saHoldStory1
                             });

            this.Response = this.Browser.Get(
                "/products/sa-hold-stories/1",
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
            this.SaHoldStoryService.Received().GetById(1);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var r = this.Response.Body;
            var resource = this.Response.Body.DeserializeJson<SaHoldStoryResource>();
            resource.HoldStoryId.Should().Be(1);
        }
    }
}
