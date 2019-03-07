namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Resources;

    public class SalesPackagesResourceBuilder : IResourceBuilder<IEnumerable<SalesPackage>>
    {
        private readonly SalesPackageResourceBuilder salesPackageResourceBuilder = new SalesPackageResourceBuilder();

        public IEnumerable<SalesPackageResource> Build(IEnumerable<SalesPackage> salesPackages)
        {
            return salesPackages.Select(a => this.salesPackageResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<SalesPackage>>.Build(IEnumerable<SalesPackage> salesPackage) =>
            this.Build(salesPackage);

        public string GetLocation(IEnumerable<SalesPackage> salesPackages)
        {
            throw new NotImplementedException();
        }
    }
}