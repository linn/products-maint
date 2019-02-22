namespace Linn.Products.Domain.Linnapps.Tests.ProductRangeSpecs
{
    using Linn.Products.Domain.Linnapps.Products;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected ProductRange Sut { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new ProductRange { Id = 1 };
        }
    }
}
