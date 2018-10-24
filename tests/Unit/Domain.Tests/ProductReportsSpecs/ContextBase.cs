namespace Linn.Products.Domain.Tests.ProductReportsSpecs
{
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Reports;
    using Linn.Products.Domain.Repositories;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected ProductReports Sut { get; private set; }

        protected IProductRangeRepository ProductRangeRepository { get; private set; }

        protected ISalesProductRepository SalesProductRepository { get; private set; }

        protected ResultsModel Results { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.ProductRangeRepository = Substitute.For<IProductRangeRepository>();

            this.SalesProductRepository = Substitute.For<ISalesProductRepository>();

            this.Sut = new ProductReports(this.ProductRangeRepository, this.SalesProductRepository);
        }
    }
}
