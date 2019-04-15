namespace Linn.Products.Domain.Linnapps.Tests.SaHoldStorySpecs
{
    using Linn.Products.Domain.Linnapps.Products;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SaHoldStory Sut { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new SaHoldStory
                           {
                               HoldStoryId = 1,
                               ReasonStarted = "test",
                               PutOnHoldByEmployee = new Employee { Id = 1, FullName = "Employee"},
                                SalesArticle = new SalesArticle { ArticleNumber = "AR"}
                           };
        }
    }
}
