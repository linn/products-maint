namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosConfigsResourceBuilder : IResourceBuilder<IEnumerable<SernosConfig>>
    {
        private readonly SernosConfigResourceBuilder sernosConfigResourceBuilder = new SernosConfigResourceBuilder();

        public IEnumerable<SernosConfigResource> Build(IEnumerable<SernosConfig> sernosConfigs)
        {
            return sernosConfigs.Select(a => this.sernosConfigResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<SernosConfig>>.Build(IEnumerable<SernosConfig> sernosConfigs) => this.Build(sernosConfigs);

        public string GetLocation(IEnumerable<SernosConfig> sernosConfigs)
        {
            throw new NotImplementedException();
        }
    }
}