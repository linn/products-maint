namespace Linn.Products.Facade.Tests.SalesArticleSerialNumberFacadeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSalesArticleSerialNumberDetailsButNoMatchingSalesArticle : ContextBase
    {
        private IResult<SalesArticleSerialNumberDetails> result;

        [SetUp]
        public void SetUp()
        {
            this.SalesArticleRepository.FindById("article").Returns(null as SalesArticle);

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
            this.result.Should().BeOfType<NotFoundResult<SalesArticleSerialNumberDetails>>();
        }
    }
}
