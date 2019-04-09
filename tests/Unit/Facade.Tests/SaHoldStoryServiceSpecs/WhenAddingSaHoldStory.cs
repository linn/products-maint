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

    public class WhenAddingSaHoldStory : ContextBase
    {
        private IResult<SaHoldStory> result;

        private SaHoldStoryResource resource;

        [SetUp]
        public void SetUp()
        {
            var links = new[] { new LinkResource("put-on-hold-by", "/employees/1") };
            this.SalesArticleRepository.FindById("AR").Returns(new SalesArticle { ArticleNumber = "AR" });
            this.EmployeeRepository.FindById(Arg.Any<int>()).Returns(new Employee { Id = 1, FullName = "Employee" });
            this.resource = new SaHoldStoryResource
                                {
                                    HoldStoryId = 1,
                                    ReasonStarted = "test",
                                    SalesArticle = "AR",
                                    DateStarted = new DateTime().ToShortDateString(),
                                    PutOnHoldByEmployee = "Employee",
                                    Links = links
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldAddSaHoldStory()
        {
            this.SaHoldStoryRepository.Received().Add(Arg.Any<SaHoldStory>());
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<CreatedResult<SaHoldStory>>();
            var dataResult = ((CreatedResult<SaHoldStory>)this.result).Data;
            dataResult.ReasonStarted.Should().Be(this.resource.ReasonStarted);
        }
    }
}
