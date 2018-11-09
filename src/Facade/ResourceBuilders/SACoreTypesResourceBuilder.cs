namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SaCoreTypesResourceBuilder : IResourceBuilder<IEnumerable<SaCoreType>>
    {
        private readonly SaCoreTypeResourceBuilder sACoreTypeResourceBuilder = new SaCoreTypeResourceBuilder();

        public IEnumerable<SaCoreTypeResource> Build(IEnumerable<SaCoreType> sACoreTypes)
        {
            return sACoreTypes.Select(a => this.sACoreTypeResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<SaCoreType>>.Build(IEnumerable<SaCoreType> saCoreType) =>
            this.Build(saCoreType);

        public string GetLocation(IEnumerable<SaCoreType> saCoreTypes)
        {
            throw new NotImplementedException();
        }
    }
}