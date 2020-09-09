namespace Linn.Products.Resources.ProductsResources
{
    using System;

    public abstract class PhaseOutableEntityResource : CreatableEntityResource
    {
        public LinkResource phasedOutBy { get; set; }

        public DateTime? phasedOutOn { get; set; }
    }
}
