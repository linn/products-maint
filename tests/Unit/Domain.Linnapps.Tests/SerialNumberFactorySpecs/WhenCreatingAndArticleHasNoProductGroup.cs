namespace Linn.Products.Domain.Linnapps.Tests.SerialNumberFactorySpecs
{
    using System;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Exceptions;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;
    using NSubstitute.ReturnsExtensions;

    using NUnit.Framework;

    public class WhenCreatingAndArticleHasNoProductGroup : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.SalesArticleRepository.FindById("art").Returns(new SalesArticle { ArticleNumber = "art" });

            this.SernosPack.GetProductGroup("art").ReturnsNull();

            this.action = () => this.Sut.CreateSerialNumbers("t", "art", 1, 2, 3, 4);
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<InvalidArticleException>().WithMessage("Could not find Sernos Group for Sales Article art");
        }
    }
}
