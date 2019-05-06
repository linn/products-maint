﻿namespace Linn.Products.Domain.Linnapps.Reports
{
    using System.Collections.Generic;

    using Linn.Common.Reporting.Models;

    public interface ISaHoldStoryService
    {
        ResultsModel GetHoldStoriesForSalesArticle(string articleNumber);

        ResultsModel GetHoldStoriesForRootProduct(string rootProductName);
    }
}
