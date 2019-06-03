namespace Linn.Products.Facade.Tests.ResourceBuilderSpecs.RootProductSpecs
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected RootProductResource Result { get; set; }

        protected RootProductResourceBuilder Sut { get; private set; }

        protected ResponseModel<RootProduct> Model { get; set; }

        protected RootProduct Entity { get; set; }

        protected List<string> Privileges { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new RootProductResourceBuilder();
            this.Entity = new RootProduct { Name = "RP" };
            this.Privileges = new List<string>();
        }

    }
}