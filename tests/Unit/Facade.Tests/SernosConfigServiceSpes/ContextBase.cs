namespace Linn.Products.Facade.Tests.SernosConfigServiceSpes
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SernosConfigService Sut { get; private set; }

        protected IRepository<SernosConfig, string> SernosConfigRepository { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SernosConfigRepository = Substitute.For<IRepository<SernosConfig, string>>();
            this.Sut = new SernosConfigService(this.SernosConfigRepository);
        }
    }
}
