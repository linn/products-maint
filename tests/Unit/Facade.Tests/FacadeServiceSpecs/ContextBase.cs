namespace Linn.Products.Facade.Tests.FacadeServiceSpecs
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Persistence.Linnapps;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected FacadeService<TestEntity, int, TestEntity> Sut { get; private set; }

        protected IRepository<TestEntity, int> Repository { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Repository = Substitute.For<IRepository<TestEntity, int>>();
            this.Sut = new TestService(this.Repository);
        }
    }
}
