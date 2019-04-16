namespace Linn.Products.Facade.Tests.SalesArticleCompositeDiscountFacadeServiceSpecs
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
                                                         SalesArticle = "sa",
                                                         BaseSalesArticle = "b",
                                                         NoDiscountSalesArticle = "n"
                                                     };
            this.resource = new SalesArticleCompositeDiscountResource
                                {
                                    NoDiscountArticleNumber = "n",
                                    BaseArticleNumber = "b"
                                };
            this.SalesArticleCompositeDiscountService.SetCompositeDiscount("sa", "b", "n")
                .Returns(this.salesArticleCompositeDiscount);
            this.result = this.Sut.SetCompositeDiscount("sa", this.resource);
        }

        [Test]
        public void ShouldSetDiscountWithProxy()
        {
            this.SalesArticleCompositeDiscountService.Received().SetCompositeDiscount("sa", "b", "n");
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
