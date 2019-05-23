﻿namespace Linn.Products.Domain.Linnapps.Tests.SerialNumberFactorySpecs
{
    using System;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Exceptions;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenCreatingWithOddToNumber : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.SalesArticleRepository.FindById("art")
                .Returns(new SalesArticle { ArticleNumber = "art", TypeOfSerialNumber = "P1" });

            this.SernosPack.GetProductGroup("art").Returns("group");

            this.SernosPack.CheckSernosTrans("t", "art", 1).Returns(false);

            this.action = () => this.Sut.CreateSerialNumbers("t", "art", 1, 3, 3, 4);
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<InvalidSerialNumberTransactionException>().WithMessage("If creating pair of Serial Numbers sequence must start with the odd number and end with the even number");
        }
    }
}
