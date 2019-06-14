namespace Linn.Products.Facade.Tests.SaHoldStoryServiceSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSaHoldStory : ContextBase
    {
        private IResult<SaHoldStory> result;

        private SaHoldStoryResource resource;

        [SetUp]
        public void SetUp()
        {
            var links = new[] { new LinkResource("put-on-hold-by", "/employees/1") };
            this.SalesArticleRepository.FindById("AR").Returns(new SalesArticle { ArticleNumber = "AR" });
            this.EmployeeRepository.FindById(Arg.Any<int>()).Returns(new Employee { Id = 1, FullName = "Employee" });

            this.SaHoldStoryRepository.FindById(1).Returns(new SaHoldStory
                                                               {
                                                                   HoldStoryId = 1,
                                                                   SalesArticle = new SalesArticle{ArticleNumber = "AR"},
                                                                   ReasonStarted = "test",
                                                                   PutOnHoldByEmployee = new Employee { Id = 1, FullName = "Employee" }
                                                               });
            this.resource = new SaHoldStoryResource
                                {
                                    HoldStoryId = 1,
                                    ReasonStarted = "test",
                                    ReasonFinished = "test",
                                    DateFinished = new DateTime().ToShortDateString(),
                                    TakenOffHoldByEmployee = "Employee",
                                    SalesArticle = "AR",
                                    DateStarted = new DateTime().ToShortDateString(),
                                    PutOnHoldByEmployee = "Employee",
                                    Links = links
                                };

            this.result = this.Sut.Update(1, this.resource);
        }

        [Test]
        public void ShouldGetSaHoldStory()
        {
            this.SaHoldStoryRepository.Received().FindById(1);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<SaHoldStory>>();
            var dataResult = ((SuccessResult<SaHoldStory>)this.result).Data;
            dataResult.ReasonFinished.Should().Be(this.resource.ReasonFinished);
        }
    }
}