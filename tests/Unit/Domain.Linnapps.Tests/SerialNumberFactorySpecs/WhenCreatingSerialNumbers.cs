namespace Linn.Products.Domain.Linnapps.Tests.SerialNumberFactorySpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenCreatingSerialNumbers : ContextBase
    {
        private IEnumerable<SerialNumber> results;

        [SetUp]
        public void SetUp()
        {
            this.SalesArticleRepository.FindById("art")
                .Returns(new SalesArticle { ArticleNumber = "art", TypeOfSerialNumber = "S" });

            this.SernosPack.GetProductGroup("art").Returns("group");

            this.SernosPack.CheckSernosTrans("t", "art", 1).Returns(true);
            this.SernosPack.CheckSernosTrans("t", "art", 2).Returns(true);
            this.SernosPack.CheckSernosTrans("t", "art", 3).Returns(true);

            this.results = this.Sut.CreateSerialNumbers("t", "art", 1, 3, null, 4);
        }

        [Test]
        public void ShouldCreateSerialNumbers()
        {
            this.results.Should().HaveCount(3);
            this.results.Should().Contain(s => s.SernosNumber == 1);
            this.results.Should().Contain(s => s.SernosNumber == 2);
            this.results.Should().Contain(s => s.SernosNumber == 3);
        }
    }
}
