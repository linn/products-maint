namespace Linn.Products.Domain.Linnapps.Tests.SernosSequenceSpecs
{
    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SernosSequence Sut { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new SernosSequence("KRYSTAL", "KRYSTAL MOVING COIL CARTRIDGE", 1940, null);
        }
    }
}