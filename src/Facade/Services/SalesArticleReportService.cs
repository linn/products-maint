namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;
    using Linn.Common.Reporting.Resources.Extensions;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.Reports;

    public class SalesArticleReportService : ISalesArticleReportService
    {
        private readonly IEanCodeReportService eanCodeReportService;

        private readonly ISalesArticleReports salesArticleReports;

        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        public SalesArticleReportService(
            IEanCodeReportService eanCodeReportService,
            ISalesArticleReports salesArticleReports,
        IRepository<SalesArticle, string> salesArticleRepository)
        {
            this.eanCodeReportService = eanCodeReportService;
            this.salesArticleReports = salesArticleReports;
            this.salesArticleRepository = salesArticleRepository;
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

        public IResult<ResultsModel> GetSalesArticleByTariff(int tariffId)
        {
            var results = this.salesArticleRepository.FilterBy(x => x.TariffId == tariffId);

            var resultsModel = new ResultsModel(new[] { "Title", "Description" })
            {
                RowHeader = "Article Number",
                ReportTitle = new NameModel("Sales Articles by Tariff")
            };

            resultsModel.SetColumnType(0, GridDisplayType.TextValue);
            resultsModel.SetColumnType(1, GridDisplayType.TextValue);

            foreach (var salesArticle in results.OrderBy(a => a.ArticleNumber))
            {
                var row = resultsModel.AddRow(salesArticle.ArticleNumber);
                resultsModel.SetGridTextValue(row.RowIndex, 0, salesArticle.ArticleNumber);
                resultsModel.SetGridTextValue(row.RowIndex, 1, salesArticle.InvoiceDescription);
            }

            return new SuccessResult<ResultsModel>(resultsModel);
        }

        public IResult<IEnumerable<IEnumerable<string>>> GetSalesArticleCoreTypesCsv()
        {
            var results = this.salesArticleReports.SalesArticleCoreTypeReport()
                .ConvertToCsvList();
            return new SuccessResult<IEnumerable<IEnumerable<string>>>(results);
        }
    }
}