namespace Linn.Products.Facade.Tests.ResourceBuilderSpecs.VatCodeSpecs
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected VatCodeResource Result { get; set; }

        protected VatCodeResourceBuilder Sut { get; private set; }

        protected ResponseModel<VatCode> Model { get; set; }

        protected VatCode Entity { get; set; }

        protected List<string> Privileges { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new VatCodeResourceBuilder();
            this.Entity = new VatCode("a", "b", 1, "r", 0, "N");
            this.Privileges = new List<string>();
        }
    }
}
