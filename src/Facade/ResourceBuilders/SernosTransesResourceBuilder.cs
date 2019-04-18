namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosTransesResourceBuilder : IResourceBuilder<IEnumerable<SernosTrans>>
    {
        private readonly SernosTransResourceBuilder sernosTransResourceBuilder = new SernosTransResourceBuilder();

        public IEnumerable<SernosTransResource> Build(IEnumerable<SernosTrans> sernosTranses)
        {
            return sernosTranses.Select(s => this.sernosTransResourceBuilder.Build(s));
        }

        public string GetLocation(IEnumerable<SernosTrans> model)
        {
            throw new System.NotImplementedException();
        }

        object IResourceBuilder<IEnumerable<SernosTrans>>.Build(IEnumerable<SernosTrans> sernosTranses) => this.Build(sernosTranses);
    }
}
