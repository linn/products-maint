﻿namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SernosNotesResponseProcessor : JsonResponseProcessor<ResponseModel<IEnumerable<SernosNote>>>
    {
        public SernosNotesResponseProcessor(IResourceBuilder<ResponseModel<IEnumerable<SernosNote>>> resourceBuilder)
            : base(resourceBuilder, "sernos-notes", 1)
        {
        }
    }
}