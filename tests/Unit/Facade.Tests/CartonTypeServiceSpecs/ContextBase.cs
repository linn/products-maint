namespace Linn.Products.Facade.Tests.CartonTypeServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected CartonTypeService Sut { get; private set; }

        protected IRepository<CartonType, string> CartonTypeRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.CartonTypeRepository = Substitute.For<IRepository<CartonType, string>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.Sut = new CartonTypeService(this.CartonTypeRepository, this.TransactionManager);
        }
    }
}
