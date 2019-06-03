namespace Linn.Products.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class AuthorisationService : IAuthorisationService
    {
        public bool HasPermissionFor(AuthorisedAction action, IEnumerable<string> privileges)
        {
            switch (action)
            {
                case AuthorisedAction.VatAdmin:
                    return this.CanEditOrCreateVatCodes(privileges);
                case AuthorisedAction.SerialNumberAdmin:
                    return this.CanCreateOrUpdateSerialNumbers(privileges);
                    break;
                case AuthorisedAction.ProductHold:
                    return this.CanPutProductOnOffHold(privileges);
                    break;
                default:
                    return false;
            }
        }

        private bool CanCreateOrUpdateSerialNumbers(IEnumerable<string> privileges)
        {
            return this.Satisfies("serial-numbers.admin", privileges);
        }

        private bool CanEditOrCreateVatCodes(IEnumerable<string> privileges)
        {
            return this.Satisfies("vat.admin", privileges);
        }

        public bool CanPutProductOnOffHold(IEnumerable<string> privileges)
        {
            return this.Satisfies("product.hold", privileges);
        }

        private bool Satisfies(string privilegeRequired, IEnumerable<string> privileges)
        {
            return privileges != null && privileges.Contains(privilegeRequired);
        }
    }
}