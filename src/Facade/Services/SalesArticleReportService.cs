namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Common.Reporting.Resources.Extensions;
    using Linn.Products.Domain.Reports;

    public class SalesArticleReportService : ISalesArticleReportService
    {
        private readonly IEanCodeReportService eanCodeReportService;

        public SalesArticleReportService(IEanCodeReportService eanCodeReportService)
        {
            this.eanCodeReportService = eanCodeReportService;
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
    }
}