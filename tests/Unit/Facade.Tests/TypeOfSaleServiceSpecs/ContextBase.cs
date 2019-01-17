namespace Linn.Products.Facade.Tests.TypeOfSaleServiceSpecs
{
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;
    using Linn.Products.Persistence.Linnapps;

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
