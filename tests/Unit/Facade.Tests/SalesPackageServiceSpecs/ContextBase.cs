namespace Linn.Products.Facade.Tests.SalesPackageServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Facade.Services;
    using Linn.Products.Proxy;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesPackageService Sut { get; private set; }

        protected IRepository<SalesPackage, int> SalesPackageRepository { get; private set; }

        protected ITransactionManager TransactionManager { get; private set; }

        protected IDatabaseService DatabaseService { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SalesPackageRepository = Substitute.For<IRepository<SalesPackage, int>>();
            this.TransactionManager = Substitute.For<ITransactionManager>();
            this.DatabaseService = Substitute.For<IDatabaseService>();
            this.Sut = new SalesPackageService(
                this.SalesPackageRepository,
                this.TransactionManager,
                this.DatabaseService);
        }
    }
}