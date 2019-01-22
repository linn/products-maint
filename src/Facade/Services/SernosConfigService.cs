namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosConfigService : FacadeService<SernosConfig, string, SernosConfigResource>
    {
        public SernosConfigService(IRepository<SernosConfig, string> repository)
            : base(repository)
        {
        }

        protected override SernosConfig CreateFromResource(SernosConfigResource resource)
        {
            var config = new SernosConfig(
                             resource.Name,
                             resource.SerialNumbered,
                             resource.NumberOfSernos,
                             resource.NumberOfBoxes)
                             {
                                 Description = resource.Description

                             };
            config.SetStartOn(resource.StartOn);

            return config;
        }

        protected override void UpdateFromResource(SernosConfig sernosConfig, SernosConfigResource updateResource)
        {
            sernosConfig.Update(
                updateResource.SerialNumbered,
                updateResource.NumberOfSernos,
                updateResource.NumberOfBoxes);
            sernosConfig.SetStartOn(updateResource.StartOn);
            sernosConfig.Description = updateResource.Description;
        }
    }
}