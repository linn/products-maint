namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SACoreTypesResourceBuilder : IResourceBuilder<IEnumerable<SACoreType>>
    {
        private readonly SACoreTypeResourceBuilder sACoreTypeResourceBuilder = new SACoreTypeResourceBuilder();

        public IEnumerable<SACoreTypeResource> Build(IEnumerable<SACoreType> sACoreTypes)
        {
            return sACoreTypes.Select(a => this.sACoreTypeResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<SACoreType>>.Build(IEnumerable<SACoreType> sACoreType) =>
            this.Build(sACoreType);

        public string GetLocation(IEnumerable<SACoreType> sACoreTypes)
        {
            throw new NotImplementedException();
        }
    }
}