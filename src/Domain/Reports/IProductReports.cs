﻿namespace Linn.Products.Domain.Reports
{
    using Linn.Common.Reporting.Models;

    public interface IProductReports
    {
        ResultsModel GetProductRangeReport(bool includePhasedOut = false);

        ResultsModel GetSalesProductByRangeReport(int productRangeId, bool includePhasedOut = false);
    }
}
