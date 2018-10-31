namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Products.Domain.Linnapps;

    public class SernosConfigRepository : IRepository<SernosConfig, string>
    {
        private readonly List<SernosConfig> sernosConfigurations;

        public SernosConfigRepository()
        {
            this.sernosConfigurations = this.MakeSernosConfigs();
        }

        public SernosConfig FindById(string key)
        {
            return this.sernosConfigurations.Find(a => a.Name == key);
        }

        public IQueryable<SernosConfig> FindAll()
        {
            return this.sernosConfigurations.AsQueryable();
        }

        public void Add(SernosConfig sernosConfig)
        {
            this.sernosConfigurations.Add(sernosConfig);
        }

        public void Remove(SernosConfig entity)
        {
            throw new NotImplementedException();
        }

        public SernosConfig FindBy(Expression<Func<SernosConfig, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SernosConfig> FilterBy(Expression<Func<SernosConfig, bool>> expression)
        {
            throw new NotImplementedException();
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
                                   Description = "Serial Numbered In Ones"
                               },
                           new SernosConfig("P1", "Y", 2, 1)
                               {
                                   Description = "Serial Numbered In Pairs, One Box"
                               },
                           new SernosConfig("P2", "Y", 2, 2)
                               {
                                   Description = "Serial Numbered In Pairs, Two Boxes"
                               }
                       };
        }
    }
}