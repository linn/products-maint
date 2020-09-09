namespace Linn.Products.Domain.Products
{
    using System;

    public class ServicePart : SalesPartBase, IProductEntity
    {
        public Uri Department { get; set; }

        public Uri Nominal { get; set; }

        public T Accept<T>(IProductEntityVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
