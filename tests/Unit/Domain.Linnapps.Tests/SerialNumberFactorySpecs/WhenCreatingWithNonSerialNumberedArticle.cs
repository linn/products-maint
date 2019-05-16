namespace Linn.Products.Domain.Linnapps.Tests.SerialNumberFactorySpecs
{
    using System;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Exceptions;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenCreatingWithNonSerialNumberedArticle : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.SalesArticleRepository.FindById("art")
                .Returns(new SalesArticle { ArticleNumber = "art", TypeOfSerialNumber = "N" });

            this.SernosPack.GetProductGroup("art").Returns("group");

            this.SernosPack.CheckSernosTrans("t", "art", 1).Returns(false);

            this.action = () => this.Sut.CreateSerialNumbers("t", "art", 1, 2, 3, 4);
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<InvalidSerialNumberTransactionException>().WithMessage("Sales Article must be serial numbered");
        }
    }
}
