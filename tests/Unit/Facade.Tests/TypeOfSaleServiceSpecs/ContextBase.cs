namespace Linn.Products.Facade.Tests.TypeOfSaleServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected TypeOfSaleService Sut { get; private set; }

        protected IRepository<TypeOfSale, string> TypeOfSaleRepository { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.TypeOfSaleRepository = Substitute.For<IRepository<TypeOfSale, string>>();
            this.Sut = new TypeOfSaleService(this.TypeOfSaleRepository);
        }
    }
}
