namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Exceptions;
    using Linn.Products.Resources;

    public class CartonTypeService : FacadeService<CartonType, string, CartonTypeResource, CartonTypeUpdateResource>
    {
        private readonly IRepository<CartonType, string> cartonTypeRepository;

        private readonly ITransactionManager transactionManager;

        public CartonTypeService(
            IRepository<CartonType, string> cartonTypeRepository,
            ITransactionManager transactionManager)
            : base(cartonTypeRepository, transactionManager)
        {
            this.cartonTypeRepository = cartonTypeRepository;
            this.transactionManager = transactionManager;
        }

        protected override CartonType CreateFromResource(CartonTypeResource resource)
        {
            return new CartonType(resource.Name, resource.Width, resource.Height, resource.Depth)
            {
                Description = resource.Description,
                NumberOfLargeLabels = 1,
                NumberOfSmallLabels = 0
            };
        }

        protected override void UpdateFromResource(CartonType cartonType, CartonTypeUpdateResource resource)
        {
            if (resource.Width <= 0 || resource.Height <= 0 || resource.Depth <= 0)
            {
                throw new IncompleteDataException("Valid dimensions must be supplied when updating carton type");
            }

            cartonType.Description = resource.Description;
            cartonType.Depth = resource.Depth;
            cartonType.Width = resource.Width;
            cartonType.Height = resource.Height;
        }
    }
}