namespace Linn.Products.Facade.Tests.ProductsReportsServiceSpecs
{
    using Linn.Products.Domain.Reports;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected ProductsReportsService Sut { get; private set; }

        protected IProductReports ProductReports { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.ProductReports = Substitute.For<IProductReports>();
            this.Sut = new ProductsReportsService(this.ProductReports);
        }
    }
}
