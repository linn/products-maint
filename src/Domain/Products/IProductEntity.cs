namespace Linn.Products.Domain.Products
{
    using System;

    public interface IProductEntity
    {
        DateTime CreatedOn { get; }

        string Description { get; }

        string Name { get; }

        DateTime? PhasedOutOn { get; }

        T Accept<T>(IProductEntityVisitor<T> visitor);
    }
}
