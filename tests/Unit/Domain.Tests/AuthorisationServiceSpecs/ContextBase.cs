namespace Linn.Products.Domain.Tests.AuthorisationServiceSpecs
{
    using System.Collections.Generic;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected AuthorisationService Sut { get; private set; }

        protected bool HasPrivilegeResult { get; set; }

        protected List<string> Privileges { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new AuthorisationService();
            this.Privileges = new List<string>();
        }
    }
}
