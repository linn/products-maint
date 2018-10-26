namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System.Collections.Generic;

    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;

    public class SernosConfigRepository : ISernosConfigRepository
    {
        private readonly List<SernosConfig> sernosConfigurations;

        public SernosConfigRepository()
        {
            this.sernosConfigurations = this.MakeSernosConfigs();
        }

        public SernosConfig Get(string name)
        {
            return this.sernosConfigurations.Find(a => a.Name == name);
        }

        public IEnumerable<SernosConfig> GetAll()
        {
            return this.sernosConfigurations;
        }

        public void Add(SernosConfig sernosConfig)
        {
            this.sernosConfigurations.Add(sernosConfig);
        }

        private List<SernosConfig> MakeSernosConfigs()
        {
            return new List<SernosConfig>
                       {
                           new SernosConfig("N", "N")
                               {
                                   Description = "Not Serial Numbered"
                               },
                           new SernosConfig("S", "Y", 1, 1)
                               {
                                   Description = "Serial Numbered In Ones",
                                   StartOn = "ANY"
                               },
                           new SernosConfig("P1", "Y", 2, 1)
                               {
                                   Description = "Serial Numbered In Pairs, One Box",
                                   StartOn = "ANY"
                               },
                           new SernosConfig("P2", "Y", 2, 2)
                               {
                                   Description = "Serial Numbered In Pairs, Two Boxes",
                                   StartOn = "ANY"
                               }
                       };
        }
    }
}