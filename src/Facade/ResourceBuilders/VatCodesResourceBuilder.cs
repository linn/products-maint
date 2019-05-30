namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Models;
    using Linn.Products.Resources;

    public class VatCodesResourceBuilder : IResourceBuilder<IEnumerable<VatCode>>
    {
        private readonly VatCodeResourceBuilder vatCodeResourceBuilder = new VatCodeResourceBuilder();

        public IEnumerable<VatCodeResource> Build(IEnumerable<VatCode> vatCodes)
        {
            return vatCodes.Select(a => this.vatCodeResourceBuilder.Build(new ResponseModel<VatCode> { Entity = a }));
        }

        public string GetLocation(IEnumerable<VatCode> vatCodes)
        {
            throw new NotImplementedException();
        }

        object IResourceBuilder<IEnumerable<VatCode>>.Build(IEnumerable<VatCode> vatCodes) => this.Build(vatCodes);
    }
}