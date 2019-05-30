namespace Linn.Products.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class AuthorisationService : IAuthorisationService
    {
        public bool CanEditOrCreateVatCodes(IEnumerable<string> privileges)
        {
            return privileges.Contains("finance.admin");
        }
    }
}