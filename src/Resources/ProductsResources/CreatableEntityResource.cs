namespace Linn.Products.Resources.ProductsResources
{
    using System;
    using Linn.Common.Resources;

    public abstract class CreatableEntityResource : EntityResource
    {
        public LinkResource createdBy { get; set; }

        public DateTime createdOn { get; set; }
    }
}