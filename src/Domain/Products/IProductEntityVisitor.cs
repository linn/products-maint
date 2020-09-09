namespace Linn.Products.Domain.Products
{
    public interface IProductEntityVisitor<out T>
    {
        T Visit(ProcommCategory productCategory);

        T Visit(RootProduct rootProduct);

        T Visit(ProductSalesPart salesPart);

        T Visit(ServicePart servicePart);

        T Visit(ProductRange productRange);

        T Visit(SalesProduct salesProduct);

        T Visit(Bundle bundle);
    }
}
