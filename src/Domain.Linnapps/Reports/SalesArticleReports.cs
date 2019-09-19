namespace Linn.Products.Domain.Linnapps.Reports
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;

    public class SalesArticleReports : ISalesArticleReports
    {
        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        private readonly IProductionTriggerLevelsService productionTriggerLevelsService;

        private readonly IReportingHelper reportingHelper;

        public SalesArticleReports(
            IRepository<SalesArticle, string> salesArticleRepository,
            IProductionTriggerLevelsService productionTriggerLevelsService,
            IReportingHelper reportingHelper)
        {
            this.salesArticleRepository = salesArticleRepository;
            this.productionTriggerLevelsService = productionTriggerLevelsService;
            this.reportingHelper = reportingHelper;
        }

        public ResultsModel SalesArticleCoreTypeReport()
        {
            var articles = this.salesArticleRepository.FilterBy(a => a.PhaseOutDate == null && a.SaCoreType != null);
            var results = new ResultsModel(new[] { "Description", "CoreType" })
                              {
                                  RowHeader = "Article Number",
                                  ReportTitle = new NameModel("Sales Article Core Types")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);
            results.SetColumnType(1, GridDisplayType.TextValue);

            foreach (var salesArticle in articles.OrderBy(a => a.ArticleNumber))
            {
                var row = results.AddRow(salesArticle.ArticleNumber);
                results.SetGridTextValue(row.RowIndex, 0, salesArticle.InvoiceDescription);
                results.SetGridTextValue(row.RowIndex, 1, salesArticle.SaCoreType?.Description);
            }

            return results;
        }

        public ResultsModel SalesArticleTriggerLevelsReport()
        {
            var resultsModel = new ResultsModel { ReportTitle = new NameModel("Sales Article Trigger Levels") };
            var columns = new List<AxisDetailsModel>
                              {
                                  new AxisDetailsModel("Cit") { GridDisplayType = GridDisplayType.TextValue, SortOrder = 0 },
                                  new AxisDetailsModel("Core Type") { GridDisplayType = GridDisplayType.TextValue, SortOrder = 1 },
                                  new AxisDetailsModel("Variable Trigger", "Trigger Level") { GridDisplayType = GridDisplayType.TextValue, SortOrder = 2 },
                                  new AxisDetailsModel("Override Trigger") { GridDisplayType = GridDisplayType.TextValue, SortOrder = 3 },
                                  new AxisDetailsModel("Kanban Size") { GridDisplayType = GridDisplayType.TextValue, SortOrder = 4 }
                              };
            resultsModel.AddSortedColumns(columns);
            var triggerLevels = this.productionTriggerLevelsService.GetAll();
            var values = new List<CalculationValueModel>();
            var salesArticles = this.salesArticleRepository.FilterBy(a => triggerLevels.Select(ab => ab.PartNumber).Contains(a.ArticleNumber)).ToList();
            foreach (var productionTriggerLevel in triggerLevels)
            {
                var article = salesArticles.FirstOrDefault(a => a.ArticleNumber == productionTriggerLevel.PartNumber);
                if (article != null)
                {
                    values.Add(
                        new CalculationValueModel
                            {
                                RowId = article.ArticleNumber,
                                ColumnId = "Cit",
                                TextDisplay = productionTriggerLevel.CitCode
                            });
                    values.Add(
                        new CalculationValueModel
                            {
                                RowId = article.ArticleNumber,
                                ColumnId = "Core Type",
                                TextDisplay = article.SaCoreType?.Description
                            });
                    values.Add(
                        new CalculationValueModel
                            {
                                RowId = article.ArticleNumber,
                                ColumnId = "Variable Trigger",
                                TextDisplay = productionTriggerLevel.VariableTriggerLevel?.ToString()
                            });
                    values.Add(
                        new CalculationValueModel
                            {
                                RowId = article.ArticleNumber,
                                ColumnId = "Override Trigger",
                                TextDisplay = productionTriggerLevel.OverrideTriggerLevel?.ToString()
                        });

                    values.Add(
                        new CalculationValueModel
                            {
                                RowId = article.ArticleNumber,
                                ColumnId = "Kanban Size",
                                TextDisplay = productionTriggerLevel.KanbanSize?.ToString()
                        });
                }
            }

            this.reportingHelper.AddResultsToModel(resultsModel, values, CalculationValueModelType.Value, true);

            return resultsModel;
        }
    }
}
