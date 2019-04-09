
namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Resources;

    using PagedList.Core;

    public class SalesPackagesPaginatedResourceBuilder : IResourceBuilder<IPagedList<SalesPackage>>
    {
        private readonly SalesPackageResourceBuilder salesPackageResourceBuilder = new SalesPackageResourceBuilder();

        public SalesPackagesPaginatedResource Build(IPagedList<SalesPackage> salesPackages)
        {
            return new SalesPackagesPaginatedResource()
                       {
                           SalesPackageResources =
                               salesPackages.Select(a => this.salesPackageResourceBuilder.Build(a)).AsQueryable(),
                           PageCount = salesPackages.PageCount,
                           PageSize = salesPackages.PageSize,
                           PageNumber = salesPackages.PageNumber,
                           TotalItemCount = salesPackages.TotalItemCount,
                           HasNextPage = salesPackages.HasNextPage,
                           HasPreviousPage = salesPackages.HasPreviousPage,
                           IsFirstPage = salesPackages.IsFirstPage,
                           IsLastPage = salesPackages.IsLastPage,
                           FirstItemOnPage = salesPackages.FirstItemOnPage,
                           LastItemOnPage = salesPackages.LastItemOnPage
                       };
        }

        object IResourceBuilder<IPagedList<SalesPackage>>.Build(IPagedList<SalesPackage> salesPackage) =>
            this.Build(salesPackage);

        public string GetLocation(IPagedList<SalesPackage> salesPackages)
        {
            throw new NotImplementedException();
        }
    }


}
