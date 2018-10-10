namespace Linn.Products.Facade.Tests.CartonTypeServiceSpecs
{
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Facade.Services;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected CartonTypeService Sut { get; private set; }

        protected ICartonTypeRepository CartonTypeRepository { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.CartonTypeRepository = Substitute.For<ICartonTypeRepository>();
            this.Sut = new CartonTypeService(this.CartonTypeRepository);
        }
    }
}
