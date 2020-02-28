namespace Linn.Products.Facade.Services
{
    using System;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Reports;
    using Linn.Products.Resources;

    public class WEEEReportsService : IWEEEReportsService
    {
        private readonly IWEEEReports WEEEReports;

        public WEEEReportsService(IWEEEReports weeeReports)
        {
            this.WEEEReports = weeeReports;
        }

        public IResult<ResultsModel> GetWEEEReport(WEEEReportRequestResource resource)
        {
            var results = this.WEEEReports.GetUKWEEEReport(
                DateTime.Parse(resource.FromDate),
                DateTime.Parse(resource.ToDate));
            return new SuccessResult<ResultsModel>(results);
        }
    }
}