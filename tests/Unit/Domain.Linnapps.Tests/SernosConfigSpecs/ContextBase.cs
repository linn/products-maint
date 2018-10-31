namespace Domain.Linnapps.Tests.SernosConfigSpecs
{
    using Linn.Products.Domain.Linnapps;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SernosConfig Sut { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new SernosConfig("S", "Y", 1, 1);
        }
    }
}
