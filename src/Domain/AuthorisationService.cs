namespace Linn.Products.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class AuthorisationService : IAuthorisationService
    {
        public bool HasPermissionFor(string action, IEnumerable<string> privileges)
        {
            switch (action)
            {
                case AuthorisedAction.VatAdmin:
                    return this.CanEditOrCreate(AuthorisedAction.VatAdmin, privileges);
                case AuthorisedAction.TariffAdmin:
                    return this.CanEditOrCreate(AuthorisedAction.TariffAdmin, privileges);
                default:
                    return false;
            }
        }

        private bool CanEditOrCreate(string action, IEnumerable<string> privileges)
        {
            return this.Satisfies(action, privileges);
        }

        private bool Satisfies(string privilegeRequired, IEnumerable<string> privileges)
        {
            return privileges != null && privileges.Contains(privilegeRequired);
        }
    }
}
