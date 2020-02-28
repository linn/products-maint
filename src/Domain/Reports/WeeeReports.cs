namespace Linn.Products.Domain.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Repositories;

    public class WEEEReports : IWEEEReports
    {
        private readonly IQueryRepository<SalesAnalysis> salesAnalysisRepository;

        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        private readonly IReportingHelper reportingHelper;

        private readonly ISalesPartRepository salesPartRepository;

        public WEEEReports(
            IQueryRepository<SalesAnalysis> salesAnalysisRepository,
            IRepository<SalesArticle, string> salesArticleRepository,
            IReportingHelper reportingHelper,
            ISalesPartRepository salesPartRepository)
        {
            this.salesAnalysisRepository = salesAnalysisRepository;
            this.salesArticleRepository = salesArticleRepository;
            this.reportingHelper = reportingHelper;
            this.salesPartRepository = salesPartRepository;
        }

        public ResultsModel GetUKWEEEReport(DateTime fromDate, DateTime toDate)
        {
            var weeeParts = this.salesPartRepository.GetWEEESalesProducts().ToList();

            var salesAnalyses = this.salesAnalysisRepository.FilterBy(
                s => s.SanlDate >= fromDate && s.SanlDate <= toDate && s.AccountingCompany == "LINN"
                     && s.CountryCode == "GB" && s.DocumentType == "I"
                     && weeeParts.Any(w => w.Name == s.ArticleNumber)).ToList();

            var salesArticles = this.salesArticleRepository.FilterBy(
                article => salesAnalyses.Any(a => a.ArticleNumber == article.ArticleNumber)
                           && article.RootProduct != "SERVICE").ToList();

            var model = new ResultsModel
                            {
                                ReportTitle = new NameModel($"UK WEEE Report - Details from {fromDate:d} - {toDate:d}")
                            };

            var columns = this.ModelColumns();

            model.AddSortedColumns(columns);

            var values = this.SetModelRows(salesAnalyses, salesArticles, weeeParts);

            this.reportingHelper.AddResultsToModel(model, values, CalculationValueModelType.Quantity, true);

            return model;
        }

        private List<CalculationValueModel> SetModelRows(
            IEnumerable<SalesAnalysis> salesAnalyses,
            IEnumerable<SalesArticle> salesArticles,
            IEnumerable<SalesPart> salesParts)
        {
            var values = new List<CalculationValueModel>();

            foreach (var article in salesArticles)
            {
                var analyses = salesAnalyses.Where(s => s.ArticleNumber == article.ArticleNumber);

                var quantity = analyses.Count();

                var salesPart = salesParts.FirstOrDefault(w => w.Name == article.ArticleNumber);

                var totalWeight = salesPart?.NettWeight * quantity;

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = article.ArticleNumber,
                            TextDisplay = article.ArticleNumber,
                            ColumnId = "Article Number"
                        });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = article.ArticleNumber,
                            TextDisplay = salesPart?.Description,
                            ColumnId = "Description"
                        });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = article.ArticleNumber, Quantity = quantity, ColumnId = "Quantity"
                        });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = article.ArticleNumber,
                            Quantity = new decimal(totalWeight ?? 0),
                            ColumnId = "Total Nett Weight"
                        });
            }

            return values;
        }

        private List<AxisDetailsModel> ModelColumns()
        {
            return new List<AxisDetailsModel>
                       {
                           new AxisDetailsModel("Article Number")
                               {
                                   SortOrder = 0, GridDisplayType = GridDisplayType.TextValue
                               },
                           new AxisDetailsModel("Description")
                               {
                                   SortOrder = 1, GridDisplayType = GridDisplayType.TextValue
                               },
                           new AxisDetailsModel("Quantity") { SortOrder = 2, GridDisplayType = GridDisplayType.Value },
                           new AxisDetailsModel("Total Nett Weight")
                               {
                                   SortOrder = 3, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                       };
        }
    }
}