namespace Linn.Products.Resources.ProductsResources
{
    using System;

    using Linn.Common.Resources;

    public abstract class PhaseOutableEntityResource : CreatableEntityResource
    {
        public LinkResource phasedOutBy { get; set; }

        public DateTime? phasedOutOn { get; set; }
    }
}