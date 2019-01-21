namespace Linn.Products.Facade.Services
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class TypeOfSaleService : FacadeService<TypeOfSale, string, TypeOfSaleResource>
    {
        public TypeOfSaleService(IRepository<TypeOfSale, string> repository)
            : base(repository)
        {
        }

        protected override TypeOfSale CreateFromResource(TypeOfSaleResource resource)
        {
            var config = new TypeOfSale(resource.Name, resource.Description, resource.Nominal, resource.Department, resource.RealSale);
            return config;
        }

        protected override void UpdateFromResource(TypeOfSale typeOfSale, TypeOfSaleResource updateResource)
        {
            typeOfSale.Update(updateResource.Description, updateResource.Nominal, updateResource.Department, updateResource.RealSale);
        }
    }
}
