namespace Linn.Products.Facade.Services
{
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Persistence.Linnapps;
    using Linn.Products.Resources;

    public class SernosConfigService : FacadeService<SernosConfig, string, SernosConfigResource>
    {
        public SernosConfigService(IRepository<SernosConfig, string> repository)
            : base(repository)
        {
        }

        protected override SernosConfig CreateFromResource(SernosConfigResource resource)
        {
            return new SernosConfig(resource.Name, resource.SerialNumbered, resource.NumberOfSernos, resource.NumberOfBoxes)
                       {
                           Description = resource.Description
                       };
        }

        protected override void UpdateFromResource(SernosConfig sernosConfig, SernosConfigResource updateResource)
        {
            sernosConfig.Update(updateResource.SerialNumbered, updateResource.NumberOfSernos, updateResource.NumberOfBoxes);
            sernosConfig.Description = updateResource.Description;
        }
    }
}