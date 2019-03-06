namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class TypeOfSaleService : FacadeService<TypeOfSale, string, TypeOfSaleResource, TypeOfSaleResource>
    {
        public TypeOfSaleService(IRepository<TypeOfSale, string> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override TypeOfSale CreateFromResource(TypeOfSaleResource resource)
        {
            var typeOfSale = new TypeOfSale(
                resource.Name,
                resource.Description,
                resource.Nominal,
                resource.Department,
                resource.RealSale);
            return typeOfSale;
        }

        protected override void UpdateFromResource(TypeOfSale typeOfSale, TypeOfSaleResource updateResource)
        {
            typeOfSale.Update(
                updateResource.Name,
                updateResource.Description,
                updateResource.Nominal,
                updateResource.Department,
                updateResource.RealSale);
        }
    }
}
