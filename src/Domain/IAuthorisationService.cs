namespace Linn.Products.Domain
{
    using System.Collections.Generic;

    public interface IAuthorisationService
    {
        bool HasPermissionFor(string action, IEnumerable<string> privileges);
    }
}
