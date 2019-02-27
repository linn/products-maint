namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Common.Reporting.Resources.Extensions;
    using Linn.Products.Domain.Linnapps.Reports;

    public class SalesArticleReportService : ISalesArticleReportService
    {
        private readonly IEanCodeReportService eanCodeReportService;

        private readonly ISalesArticleReports salesArticleReports;

        public SalesArticleReportService(
            IEanCodeReportService eanCodeReportService,
            ISalesArticleReports salesArticleReports)
        {
            this.eanCodeReportService = eanCodeReportService;
            this.salesArticleReports = salesArticleReports;
        }

        public IResult<ResultsModel> GetEanCodeResults(bool includePhasedOut = false, bool cartonisedOnly = false)
        {
            var results = this.eanCodeReportService.GetEanCodeReport(includePhasedOut, cartonisedOnly);
            return new SuccessResult<ResultsModel>(results);
        }

        public IResult<IEnumerable<IEnumerable<string>>> GetEanCodeCsvResults(
            bool includePhasedOut = false,
            bool cartonisedOnly = false)
        {
            var results = this.eanCodeReportService.GetEanCodeReport(includePhasedOut, cartonisedOnly)
                .ConvertToCsvList();
            return new SuccessResult<IEnumerable<IEnumerable<string>>>(results);
        }

        public IResult<ResultsModel> GetSalesArticleCoreTypes()
        {
            var results = this.salesArticleReports.SalesArticleCoreTypeReport();
            return new SuccessResult<ResultsModel>(results);
        }

        public IResult<IEnumerable<IEnumerable<string>>> GetSalesArticleCoreTypesCsv()
        {
            var results = this.salesArticleReports.SalesArticleCoreTypeReport()
                .ConvertToCsvList();
            return new SuccessResult<IEnumerable<IEnumerable<string>>>(results);
        }
    }
}