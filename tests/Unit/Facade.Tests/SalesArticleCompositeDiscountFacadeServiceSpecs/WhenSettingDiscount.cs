﻿namespace Linn.Products.Facade.Tests.SalesArticleCompositeDiscountFacadeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenSettingDiscount : ContextBase
    {
        private IResult<SalesArticleCompositeDiscount> result;

        private SalesArticleCompositeDiscountResource resource;

        private SalesArticleCompositeDiscount salesArticleCompositeDiscount;

        [SetUp]
        public void SetUp()
        {
            this.salesArticleCompositeDiscount = new SalesArticleCompositeDiscount
                                                     {
                                                         SalesArticle = "SA",
                                                         BaseSalesArticle = "B",
                                                         NoDiscountSalesArticle = "N"
                                                     };
            this.resource = new SalesArticleCompositeDiscountResource
                                {
                                    NoDiscountArticleNumber = "n",
                                    BaseArticleNumber = "b"
                                };
            this.SalesArticleCompositeDiscountService.SetCompositeDiscount("SA", "B", "N")
                .Returns(this.salesArticleCompositeDiscount);
            this.result = this.Sut.SetCompositeDiscount("sa", this.resource);
        }

        [Test]
        public void ShouldSetDiscountWithProxy()
        {
            this.SalesArticleCompositeDiscountService.Received().SetCompositeDiscount("SA", "B", "N");
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<SalesArticleCompositeDiscount>>();
            var dataResult = ((SuccessResult<SalesArticleCompositeDiscount>)this.result).Data;
            dataResult.SalesArticle.Should().Be("SA");
            dataResult.BaseSalesArticle.Should().Be("B");
            dataResult.NoDiscountSalesArticle.Should().Be("N");
        }
    }
}
