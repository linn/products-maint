namespace Linn.Products.Domain.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Repositories;

    public class WEEEReports : IWEEEReports
    {
        private readonly IQueryRepository<SalesAnalysis> salesAnalysisRepository;

        private readonly IReportingHelper reportingHelper;

        private readonly ISalesPartRepository salesPartRepository;

        public WEEEReports(
            IQueryRepository<SalesAnalysis> salesAnalysisRepository,
            IReportingHelper reportingHelper,
            ISalesPartRepository salesPartRepository)
        {
            this.salesAnalysisRepository = salesAnalysisRepository;
            this.reportingHelper = reportingHelper;
            this.salesPartRepository = salesPartRepository;
        }

        public ResultsModel GetUkWEEEReport(DateTime fromDate, DateTime toDate)
        {
            var weeeParts = this.salesPartRepository.GetWEEESalesProducts().ToList();

            var salesAnalyses = this.salesAnalysisRepository.FilterBy(
                s => s.SanlDate >= fromDate && s.SanlDate <= toDate && s.AccountingCompany == "LINN"
                     && s.CountryCode == "GB" && s.DocumentType == "I"
                     && weeeParts.Any(w => w.Name == s.ArticleNumber)).ToList();

            weeeParts = weeeParts.Where(w => salesAnalyses.Any(a => a.ArticleNumber == w.Name)).OrderBy(w => w.Name)
                .ToList();

            var model = new ResultsModel
                            {
                                ReportTitle = new NameModel($"UK WEEE Report - Details from {fromDate:d} - {toDate:d}")
                            };

            var columns = this.UkModelColumns();

            model.AddSortedColumns(columns);

            var values = this.SetUkModelRows(salesAnalyses, weeeParts);

            this.reportingHelper.AddResultsToModel(model, values, CalculationValueModelType.Quantity, true);

            return model;
        }

        public IEnumerable<ResultsModel> GetGermanWeeeReport(DateTime fromDate, DateTime toDate)
        {
            var results = new List<ResultsModel>();

            var allWeeeParts = this.salesPartRepository.GetWEEESalesProducts().ToList();

            var salesAnalyses = this.salesAnalysisRepository.FilterBy(
                s => s.SanlDate >= fromDate && s.SanlDate <= toDate && s.AccountingCompany == "LINN"
                     && s.CountryCode == "DE" && s.DocumentType == "I"
                     && allWeeeParts.Any(w => w.Name == s.ArticleNumber)).ToList();

            allWeeeParts = allWeeeParts.Where(w => salesAnalyses.Any(a => a.ArticleNumber == w.Name))
                .OrderBy(w => w.Name).ToList();

            var weeeParts = allWeeeParts.Where(w => string.IsNullOrEmpty(w.RootProduct.WeeeCategory));

            var packagingOnlyParts = allWeeeParts.Where(w => w.RootProduct.WeeeCategory == "PACKAGING");

            var cableParts = allWeeeParts.Where(w => w.RootProduct.WeeeCategory == "CABLE");

            var columns = this.GermanModelColumns();

            var weeeResultsModel = new ResultsModel
                                       {
                                           ReportTitle = new NameModel($"WEEE Products from {fromDate:d} - {toDate:d}")
                                       };
            var packagingResultsModel = new ResultsModel { ReportTitle = new NameModel("Packaging Only") };
            var cablesResultsModel = new ResultsModel { ReportTitle = new NameModel("Cables Only") };


            weeeResultsModel.AddSortedColumns(columns);
            packagingResultsModel.AddSortedColumns(columns);
            cablesResultsModel.AddSortedColumns(columns);

            this.reportingHelper.AddResultsToModel(
                weeeResultsModel,
                this.SetGermanModelRows(salesAnalyses, weeeParts),
                CalculationValueModelType.Quantity,
                true);
            this.reportingHelper.AddResultsToModel(
                packagingResultsModel,
                this.SetGermanModelRows(salesAnalyses, packagingOnlyParts),
                CalculationValueModelType.Quantity,
                true);
            this.reportingHelper.AddResultsToModel(
                cablesResultsModel,
                this.SetGermanModelRows(salesAnalyses, cableParts),
                CalculationValueModelType.Quantity,
                true);

            results.Add(weeeResultsModel);
            results.Add(packagingResultsModel);
            results.Add(cablesResultsModel);

            return results;
        }

        private List<AxisDetailsModel> UkModelColumns()
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
                           new AxisDetailsModel("Nett Weight")
                               {
                                   SortOrder = 3, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                       };
        }

        private List<CalculationValueModel> SetUkModelRows(
            IEnumerable<SalesAnalysis> salesAnalyses,
            IEnumerable<SalesPart> salesParts)
        {
            var values = new List<CalculationValueModel>();

            foreach (var salesPart in salesParts)
            {
                var analyses = salesAnalyses.Where(s => s.ArticleNumber == salesPart.Name);

                var quantity = analyses.Sum(a => a.Quantity);

                var totalWeight = salesPart?.RootProduct.NettWeight * quantity;

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = salesPart.Name,
                            TextDisplay = salesPart.Name,
                            ColumnId = "Article Number"
                        });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = salesPart.Name,
                            TextDisplay = salesPart?.Description,
                            ColumnId = "Description"
                        });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = salesPart.Name, Quantity = quantity, ColumnId = "Quantity"
                        });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = salesPart.Name,
                            Quantity = new decimal(totalWeight ?? 0),
                            ColumnId = "Nett Weight"
                        });
            }

            return values;
        }

        private List<AxisDetailsModel> GermanModelColumns()
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
                           new AxisDetailsModel("Nett Weight")
                               {
                                   SortOrder = 3, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                           new AxisDetailsModel("Nett Packaging Weight")
                               {
                                   SortOrder = 4, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                           new AxisDetailsModel("Nett Packaging Foam Weight")
                               {
                                   SortOrder = 5, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                           new AxisDetailsModel("Dimension Over 50cm")
                               {
                                   SortOrder = 6, GridDisplayType = GridDisplayType.TextValue
                               },
                           new AxisDetailsModel("Mains Cables Per Product") { SortOrder = 7, GridDisplayType = GridDisplayType.Value },
                       };
        }

        private List<CalculationValueModel> SetGermanModelRows(
            IEnumerable<SalesAnalysis> salesAnalyses,
            IEnumerable<SalesPart> salesParts)
        {
            var values = new List<CalculationValueModel>();

            foreach (var part in salesParts)
            {
                var analyses = salesAnalyses.Where(s => s.ArticleNumber == part.Name);

                var quantity = analyses.Sum(a => a.Quantity);

                var nettWeight = (part.RootProduct.NettWeight * quantity)
                                 + (part.RootProduct.MainsCablesPerProduct * 0.25);

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = part.Name,
                        TextDisplay = part.Name,
                        ColumnId = "Article Number"
                    });

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = part.Name,
                        TextDisplay = part.Description,
                        ColumnId = "Description"
                    });

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = part.Name,
                        Quantity = quantity,
                        ColumnId = "Quantity"
                    });

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = part.Name,
                        Quantity = new decimal(nettWeight ?? 0),
                        ColumnId = "Nett Weight"
                    });

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = part.Name,
                        Quantity = new decimal(part.RootProduct.PackagingNettWeight * quantity ?? 0),
                        ColumnId = "Nett Packaging Weight"
                    });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = part.Name,
                            Quantity = new decimal(part.RootProduct.PackagingFoamNettWeight * quantity ?? 0),
                            ColumnId = "Nett Packaging Foam Weight"
                        });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = part.Name,
                            Quantity = part.RootProduct.MainsCablesPerProduct ?? 0,
                            ColumnId = "Mains Cables Per Product"
                        });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = part.Name,
                            TextDisplay = part.RootProduct.DimensionOver50Cm ? "X" : string.Empty,
                            ColumnId = "Dimension Over 50cm"
                        });
            }

            return values;
        }
    }
}