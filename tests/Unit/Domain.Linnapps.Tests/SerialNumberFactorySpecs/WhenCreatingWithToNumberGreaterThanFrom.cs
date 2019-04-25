namespace Linn.Products.Domain.Linnapps.Tests.SerialNumberFactorySpecs
{
    using System;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Exceptions;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenCreatingWithToNumberGreaterThanFrom : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.SalesArticleRepository.FindById("art")
                .Returns(new SalesArticle { ArticleNumber = "art", TypeOfSerialNumber = "P1" });

            this.SernosPack.GetProductGroup("art").Returns("group");

            this.SernosPack.CheckSernosTrans("t", "art", 1).Returns(false);

            this.action = () => this.Sut.CreateSerialNumbers("t", "art", 3, 2, null, 4);
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<InvalidDataException>().WithMessage("To serial number should not be less than from serial number");
        }
    }
}
