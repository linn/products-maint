namespace Linn.Products.Facade.Services
{
    using System;
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    public interface IWEEEReportsService
    {
        IResult<IEnumerable<ResultsModel>> GetUkWeeeReport(DateTime fromDate, DateTime toDate);

        IResult<IEnumerable<ResultsModel>> GetGermanWeeeReport(DateTime fromDate, DateTime toDate);
    }
}