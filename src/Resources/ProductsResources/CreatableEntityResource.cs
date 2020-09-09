namespace Linn.Products.Resources.ProductsResources
{
    using System;

    public abstract class CreatableEntityResource : EntityResource
    {
        public LinkResource createdBy { get; set; }

        public DateTime createdOn { get; set; }
    }
}
