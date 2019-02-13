namespace Domain.Linnapps.Tests.VatCodeSpecs
{
    using Linn.Products.Domain.Linnapps;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected VatCode Sut { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new VatCode("A", "STD UK VAT RATE.", 20, null, "N", 1);
        }
    }
}
