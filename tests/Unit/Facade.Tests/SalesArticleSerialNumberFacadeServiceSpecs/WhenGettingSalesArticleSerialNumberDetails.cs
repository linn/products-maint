namespace Linn.Products.Facade.Tests.SalesArticleSerialNumberFacadeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSalesArticleSerialNumberDetails : ContextBase
    {
        private IResult<SalesArticleSerialNumberDetails> result;

        [SetUp]
        public void SetUp()
        {
            var salesArticle = new SalesArticle
                                            {
                                                ArticleNumber = "article",
                                                TypeOfSerialNumber = "P1"
                                            };

            this.SalesArticleRepository.FindById("article").Returns(salesArticle);
            this.SernosPack.GetProductGroup("article").Returns("group");

            this.result = this.Sut.GetSerialNumberDetails("article");
        }

        [Test]
        public void ShouldGetSalesArticleSerialNumberDetails()
        {
            this.SalesArticleRepository.Received().FindById("article");
        }

        [Test]
        public void ShouldReturnSuccessResult()
        {
            this.result.Should().BeOfType<SuccessResult<SalesArticleSerialNumberDetails>>();
            var dataResult = ((SuccessResult<SalesArticleSerialNumberDetails>)this.result).Data;
            dataResult.SerialNumberType.Should().Be("P1");
            dataResult.SernosGroup.Should().Be("group");
        }
    }
}
