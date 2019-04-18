namespace Linn.Products.Facade.Tests.SalesArticleCompositeDiscountFacadeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Models;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingDiscount : ContextBase
    {
        private IResult<SalesArticleCompositeDiscount> result;

        private SalesArticleCompositeDiscount salesArticleCompositeDiscount;

        [SetUp]
        public void SetUp()
        {
            this.salesArticleCompositeDiscount = new SalesArticleCompositeDiscount
                                                     {
                                                         SalesArticle = "sa",
                                                         BaseSalesArticle = "b",
                                                         NoDiscountSalesArticle = "n"
                                                     };

            this.SalesArticleCompositeDiscountService.GetCompositeDiscount("sa")
                .Returns(this.salesArticleCompositeDiscount);
            this.result = this.Sut.GetCompositeDiscount("sa");
        }

        [Test]
        public void ShouldSetDiscountWithProxy()
        {
            this.SalesArticleCompositeDiscountService.Received().GetCompositeDiscount("sa");
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<SalesArticleCompositeDiscount>>();
            var dataResult = ((SuccessResult<SalesArticleCompositeDiscount>)this.result).Data;
            dataResult.SalesArticle.Should().Be("sa");
            dataResult.BaseSalesArticle.Should().Be("b");
            dataResult.NoDiscountSalesArticle.Should().Be("n");
        }
    }
}
