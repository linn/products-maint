namespace Linn.Products.Domain.Tests.TariffsReallocationSpecs
{
    using System.Collections.Generic;
    using System.Linq;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Dispatchers;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Products;
    using Linn.Products.Domain.Services;
    using NSubstitute;
    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected IRepository<ProductSalesPart, int> SalesPartRepository { get; private set; }

        protected ITariffNumberReallocationService TariffNumberReallocationService { get; set; }

        protected ISalesPartUpdatedDispatcher Dispatcher { get; set; }

        protected IList<ProductSalesPart> SalesParts { get; set; }

        protected TariffsReallocator Result { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SalesPartRepository = Substitute.For<IRepository<ProductSalesPart, int>>();
            this.Dispatcher = Substitute.For<ISalesPartUpdatedDispatcher>();
            this.TariffNumberReallocationService = new TariffNumberReallocationService(this.SalesPartRepository, this.Dispatcher);


            this.SalesParts = new List<ProductSalesPart>
                                  {
                                      new ProductSalesPart { Tariff = new Products.Tariff() { Id = 118 } },
                                      new ProductSalesPart { Tariff = new Products.Tariff() { Id = 118 } },
                                      new ProductSalesPart { Tariff = new Products.Tariff() { Id = 118 } },
                                  };
            this.SalesPartRepository.FindAll().Returns(this.SalesParts.AsQueryable());
        }
    }
}
