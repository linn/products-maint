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

        public IResult<ResultsModel> GetEanCodeResults()
        {
            var results = this.eanCodeReportService.GetEanCodeReport();
            return new SuccessResult<ResultsModel>(results);
        }

        public IResult<IEnumerable<IEnumerable<string>>> GetEanCodeCsvResults()
        {
            var results = this.eanCodeReportService.GetEanCodeReport().ConvertToCsvList();
            return new SuccessResult<IEnumerable<IEnumerable<string>>>(results);
        }
    }
}