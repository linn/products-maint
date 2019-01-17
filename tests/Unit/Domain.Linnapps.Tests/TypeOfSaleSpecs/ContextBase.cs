namespace Domain.Linnapps.Tests.TypeOfSaleSpecs
{
    using Linn.Products.Domain.Linnapps;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected TypeOfSale Sut { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new TypeOfSale("DL", "SALES OF LINN RECORDS DOWNLOADS", "DUMMY", "DUMMY", "Y");
        }
    }
}
