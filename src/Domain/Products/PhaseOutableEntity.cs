namespace Linn.Products.Domain.Products
{
    using System;

    public abstract class PhaseOutableEntity : CreatableEntity
    {
        protected PhaseOutableEntity()
        {
        }

        protected PhaseOutableEntity(int id)
            : base(id)
        {
        }

        public virtual Uri PhasedOutBy { get; set; }

        public virtual DateTime? PhasedOutOn { get; set; }

        public void PhaseOut(Uri phasedOutBy, DateTime phasedOutOn)
        {
            this.PhasedOutBy = phasedOutBy;
            this.PhasedOutOn = phasedOutOn;
        }

        public void PhaseIn()
        {
            this.PhasedOutBy = null;
            this.PhasedOutOn = null;
        }
    }
}
