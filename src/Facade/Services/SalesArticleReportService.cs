namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
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
    }
}