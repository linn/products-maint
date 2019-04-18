namespace Linn.Products.Facade.Tests.SalesArticleCompositeDiscountFacadeServiceSpecs
{
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleCompositeDiscountFacadeService Sut { get; private set; }

        protected ISalesArticleCompositeDiscountService SalesArticleCompositeDiscountService { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SalesArticleCompositeDiscountService = Substitute.For<ISalesArticleCompositeDiscountService>();
            this.Sut = new SalesArticleCompositeDiscountFacadeService(this.SalesArticleCompositeDiscountService);
        }
    }
}
