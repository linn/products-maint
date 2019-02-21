namespace Linn.Products.Facade.Services
{
    using System;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class ProductRangeService : FacadeService<ProductRange, int, ProductRangeResource, ProductRangeUpdateResource>
    {
        public ProductRangeService(
            IRepository<ProductRange, int> repository,
            ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override ProductRange CreateFromResource(ProductRangeResource resource)
        {
            var range = new ProductRange
                       {
                           RangeName = resource.RangeName,
                           RangeDescription = resource.RangeDescription,
                           DateInvalid = string.IsNullOrEmpty(resource.DateInvalid) ? (DateTime?)null : DateTime.Parse(resource.DateInvalid)
                       };

            range.ValidateProductRange();

            return range;
        }

        protected override void UpdateFromResource(ProductRange productRange, ProductRangeUpdateResource updateResource)
        {
            productRange.RangeName = updateResource.RangeName;
            productRange.RangeDescription = updateResource.RangeDescription;
            productRange.DateInvalid = string.IsNullOrEmpty(updateResource.DateInvalid)
                                           ? (DateTime?)null
                                           : DateTime.Parse(updateResource.DateInvalid);

            productRange.ValidateProductRange();
        }
    }
}
