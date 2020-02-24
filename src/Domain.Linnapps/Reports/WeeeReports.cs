namespace Linn.Products.Domain.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.Reports;

    public class WEEEReports : IWEEEReports
    {
        private readonly IQueryRepository<SalesAnalysis> salesAnalysisRepository;

        private readonly IRepository<RootProduct, string> rootProductRepository;

        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        private readonly IReportingHelper reportingHelper;

        public WEEEReports(
            IQueryRepository<SalesAnalysis> salesAnalysisRepository,
            IRepository<RootProduct, string> rootProductRepository,
            IRepository<SalesArticle, string> salesArticleRepository,
            IReportingHelper reportingHelper)
        {
            this.salesAnalysisRepository = salesAnalysisRepository;
            this.rootProductRepository = rootProductRepository;
            this.salesArticleRepository = salesArticleRepository;
            this.reportingHelper = reportingHelper;
        }

        public ResultsModel GetUKWEEEReport(DateTime fromDate, DateTime toDate)
        {
            var salesAnalyses = this.salesAnalysisRepository.FilterBy(
                s => s.SanlDate >= fromDate && s.SanlDate <= toDate && s.AccountingCompany == "LINN"
                     && s.CountryCode == "GB" && s.DocumentType == "I").ToList();

            var salesArticles = this.salesArticleRepository.FilterBy(
                article => salesAnalyses.Any(analysis => analysis.ArticleNumber == article.ArticleNumber)
                           && article.RootProduct != "SERVICE").ToList();

            var rootProducts =
                this.rootProductRepository.FilterBy(r => salesArticles.Any(s => s.RootProduct == r.Name)).ToList();

            var model = new ResultsModel
                            {
                                ReportTitle = new NameModel($"UK WEEE Report - Details from {fromDate:d} - {toDate:d}")
                            };

            var columns = this.ModelColumns();

            model.AddSortedColumns(columns);

            var values = this.SetModelRows(salesAnalyses, salesArticles, rootProducts);

            this.reportingHelper.AddResultsToModel(model, values, CalculationValueModelType.Quantity, true);

            return model;
        }

        private List<CalculationValueModel> SetModelRows(
            IEnumerable<SalesAnalysis> salesAnalyses,
            IEnumerable<SalesArticle> salesArticles,
            IEnumerable<RootProduct> rootProducts)
        {
            var values = new List<CalculationValueModel>();

            foreach (var article in salesArticles)
            {
                var analyses = salesAnalyses.Where(s => s.ArticleNumber == article.ArticleNumber);

                var quantity = analyses.Count();

                var totalWeight = article.Weight * quantity;

                var rootProduct = rootProducts.ToList().FirstOrDefault(r => r.Name == article.RootProduct);

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
                        TextDisplay = article.InvoiceDescription,
                        ColumnId = "Invoice Description"
                    });

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = article.ArticleNumber,
                        TextDisplay = rootProduct?.Name,
                        ColumnId = "Root Product"
                    });
                
                values.Add(
                    new CalculationValueModel
                    {
                        RowId = article.ArticleNumber,
                        TextDisplay = rootProduct?.Description,
                        ColumnId = "Description"
                    });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = article.ArticleNumber,
                            Quantity = new decimal(article.Weight ?? 0),
                            ColumnId = "Individual Product Weight"
                        });

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = article.ArticleNumber,
                        Quantity = quantity,
                        ColumnId = "Quantity"
                    });

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = article.ArticleNumber,
                        Quantity = quantity,
                        ColumnId = "Quantity"
                    });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = article.ArticleNumber, Quantity = new decimal(totalWeight ?? 0), ColumnId = "Weight"
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
                           new AxisDetailsModel("Invoice Description")
                               {
                                   SortOrder = 1, GridDisplayType = GridDisplayType.TextValue
                               },
                           new AxisDetailsModel("Root Product")
                               {
                                   SortOrder = 2, GridDisplayType = GridDisplayType.TextValue
                               },
                           new AxisDetailsModel("Description")
                               {
                                   SortOrder = 3, GridDisplayType = GridDisplayType.TextValue
                               },
                           new AxisDetailsModel("Individual Product Weight")
                               {
                                   SortOrder = 4, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                           new AxisDetailsModel("SA Analysis Group 3")
                               {
                                   SortOrder = 5, GridDisplayType = GridDisplayType.TextValue
                               },
                           new AxisDetailsModel("Quantity") { SortOrder = 6, GridDisplayType = GridDisplayType.Value },
                           new AxisDetailsModel("Weight")
                               {
                                   SortOrder = 7, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                       };
        }
    }
}