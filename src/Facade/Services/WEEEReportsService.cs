namespace Linn.Products.Facade.Services
{
    using System;
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Reports;

    public class WEEEReportsService : IWEEEReportsService
    {
        private readonly IWEEEReports WEEEReports;

        public WEEEReportsService(IWEEEReports weeeReports)
        {
            this.WEEEReports = weeeReports;
        }

        public IResult<IEnumerable<ResultsModel>> GetUkWeeeReport(DateTime fromDate, DateTime toDate)
        {
            var results = this.WEEEReports.GetUkWEEEReport(fromDate, toDate);
            return new SuccessResult<IEnumerable<ResultsModel>>(results);
        }

        public IResult<IEnumerable<ResultsModel>> GetGermanWeeeReport(DateTime fromDate, DateTime toDate)
        {
            var results = this.WEEEReports.GetGermanWeeeReport(fromDate, toDate);
            return new SuccessResult<IEnumerable<ResultsModel>>(results);
        }
    }
}