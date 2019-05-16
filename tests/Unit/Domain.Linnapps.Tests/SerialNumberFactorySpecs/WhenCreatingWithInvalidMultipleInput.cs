﻿namespace Linn.Products.Domain.Linnapps.Tests.SerialNumberFactorySpecs
{
    using System;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Exceptions;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenCreatingWithInvalidMultipleInput : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.SalesArticleRepository.FindById("art")
                .Returns(new SalesArticle { ArticleNumber = "art", TypeOfSerialNumber = "S" });

            this.SernosPack.GetProductGroup("art").Returns("group");

            this.SernosPack.CheckSernosTrans("t", "art", 1).Returns(true);
            this.SernosPack.CheckSernosTrans("t", "art", 2).Returns(false);
            this.SernosPack.CheckSernosTrans("t", "art", 3).Returns(true);

            this.SernosPack.GetSernosMessage().Returns("sernos message");

            this.action = () => this.Sut.CreateSerialNumbers("t", "art", 1, 3, null, 4);
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<InvalidSerialNumberTransactionException>().WithMessage("sernos message");
        }
    }
}
