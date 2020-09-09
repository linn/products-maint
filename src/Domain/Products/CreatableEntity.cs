namespace Linn.Products.Domain.Products
{
    using System;

    public abstract class CreatableEntity : ProductEntity
    {
        protected CreatableEntity()
        {
        }

        protected CreatableEntity(int id)
            : base(id)
        {
        }

        public virtual Uri CreatedBy { get; set; }

        public virtual DateTime CreatedOn { get; set; }
    }
}