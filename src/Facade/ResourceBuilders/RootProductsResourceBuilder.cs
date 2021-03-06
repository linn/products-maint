﻿namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class RootProductsResourceBuilder : IResourceBuilder<IEnumerable<RootProduct>>
    {
        private readonly RootProductResourceBuilder rootProductResourceBuilder = new RootProductResourceBuilder();

        public IEnumerable<RootProductResource> Build(IEnumerable<RootProduct> rootProducts)
        {
            return rootProducts.Select(a => this.rootProductResourceBuilder.Build(new ResponseModel<RootProduct>(a, null)));
        }

        object IResourceBuilder<IEnumerable<RootProduct>>.Build(IEnumerable<RootProduct> rootProducts) =>
            this.Build(rootProducts);

        public string GetLocation(IEnumerable<RootProduct> salesArticles)
        {
            throw new NotImplementedException();
        }
    }
}