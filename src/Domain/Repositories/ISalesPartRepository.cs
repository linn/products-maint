﻿namespace Linn.Products.Domain.Repositories
{
    using System.Collections.Generic;

    public interface ISalesPartRepository
    {
        IEnumerable<SalesPart> GetWEEESalesParts();
    }
}