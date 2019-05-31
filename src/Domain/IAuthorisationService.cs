namespace Linn.Products.Domain
{
    using System;
    using System.Collections.Generic;

    public interface IAuthorisationService
    {
        bool CanEditOrCreateVatCodes(IEnumerable<string> privileges);

        bool CanPutProductOnOffHold(IEnumerable<string> privileges);
    }
}
