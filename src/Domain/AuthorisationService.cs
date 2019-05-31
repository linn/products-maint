namespace Linn.Products.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class AuthorisationService : IAuthorisationService
    {
        public bool CanEditOrCreateVatCodes(IEnumerable<string> privileges)
        {
            return this.Satisfies("finance.admin", privileges);
        }

        private bool Satisfies(string privilegeRequired, IEnumerable<string> privileges)
        {
            return privileges != null && privileges.Contains(privilegeRequired);
        }
    }
}