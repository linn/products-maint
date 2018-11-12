namespace Linn.Products.Facade.Tests.SaCoreTypesServiceSpecs
{
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;
    using Linn.Products.Persistence.Linnapps;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SaCoreTypeService Sut { get; private set; }

        protected IRepository<SaCoreType, int> SaCoreTypeRepository { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SaCoreTypeRepository = Substitute.For<IRepository<SaCoreType, int>>();
            this.Sut = new SaCoreTypeService(this.SaCoreTypeRepository);
        }
    }
}