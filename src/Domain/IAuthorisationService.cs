namespace Linn.Products.Domain
{
    using System.Collections.Generic;

    public interface IAuthorisationService
    {
        bool HasPermissionFor(AuthorisedAction action, IEnumerable<string> privileges);
    }
}
