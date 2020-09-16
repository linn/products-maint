namespace Linn.Products.Domain.Dispatchers
{
    using Linn.Products.Domain.Products;

    public interface ISalesPartUpdatedDispatcher
    {
        void DispatchSalesPartUpdated(ProductSalesPart resource);
    }
}
