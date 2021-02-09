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

        private readonly IReportingHelper reportingHelper;

        private readonly ISalesPartRepository salesPartRepository;

        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        public WEEEReports(
            IQueryRepository<SalesAnalysis> salesAnalysisRepository,
            IReportingHelper reportingHelper,
            ISalesPartRepository salesPartRepository,
            IRepository<SalesArticle, string> salesArticleRepository)
        {
            this.salesAnalysisRepository = salesAnalysisRepository;
            this.reportingHelper = reportingHelper;
            this.salesPartRepository = salesPartRepository;
            this.salesArticleRepository = salesArticleRepository;
        }

        public IEnumerable<ResultsModel> GetUkWEEEReport(DateTime fromDate, DateTime toDate)
        {
            var results = new List<ResultsModel>();

            var weeeParts = this.salesPartRepository.GetWEEESalesParts().ToList();

            var salesAnalyses = this.salesAnalysisRepository.FilterBy(
                s => s.SanlDate >= fromDate && s.SanlDate <= toDate && s.AccountingCompany == "LINN"
                     && s.CountryCode == "GB" && s.DocumentType == "I").ToList();

            var weeeSalesAnalyses = salesAnalyses.Where(s => weeeParts.Any(w => w.Name == s.ArticleNumber)).ToList();

            var ukWeeeParts = weeeParts
                .Where(w => weeeSalesAnalyses.Any(a => a.ArticleNumber == w.Name) && string.IsNullOrEmpty(w.WeeeCategory))
                .OrderBy(w => w.Name).ToList();

            var nonWeeeSalesAnanlyses = salesAnalyses
                .Where(s => weeeParts.All(p => p.Name != s.ArticleNumber) && s.Quantity != 0).ToList();

            var nonWeeeSalesArticles = this.salesArticleRepository
                .FilterBy(s => nonWeeeSalesAnanlyses.Any(a => a.ArticleNumber == s.ArticleNumber))
                .OrderBy(s => s.ArticleNumber).ToList();

            var model = new ResultsModel
                            {
                                ReportTitle = new NameModel($"UK WEEE Report {fromDate:d} - {toDate:d}")
                            };
            var nonWeeeResultsModel = new ResultsModel { ReportTitle = new NameModel("Sales of non WEEE Products") };

            var columns = this.UkModelColumns();
            var nonWeeeColumns = this.NonWeeeColumns();

            model.AddSortedColumns(columns);
            nonWeeeResultsModel.AddSortedColumns(nonWeeeColumns);

            var values = this.SetUkModelRows(weeeSalesAnalyses, ukWeeeParts);

            this.reportingHelper.AddResultsToModel(model, values, CalculationValueModelType.Quantity, true);
            this.reportingHelper.AddResultsToModel(
                nonWeeeResultsModel,
                this.SetNonWeeeModelRows(nonWeeeSalesAnanlyses, nonWeeeSalesArticles),
                CalculationValueModelType.Quantity,
                true);

            results.Add(model);
            results.Add(nonWeeeResultsModel);

            return results;
        }

        public IEnumerable<ResultsModel> GetGermanWeeeReport(DateTime fromDate, DateTime toDate)
        {
            var results = new List<ResultsModel>();

            var allWeeeParts = this.salesPartRepository.GetWEEESalesParts().ToList();

            var salesAnalyses = this.salesAnalysisRepository.FilterBy(
                s => s.SanlDate >= fromDate && s.SanlDate <= toDate && s.AccountingCompany == "LINN"
                     && s.CountryCode == "DE" && s.DocumentType == "I").ToList();

            var weeeSalesAnalyses = salesAnalyses.Where(s => allWeeeParts.Any(w => w.Name == s.ArticleNumber)).ToList();

            allWeeeParts = allWeeeParts.Where(w => weeeSalesAnalyses.Any(a => a.ArticleNumber == w.Name))
                .OrderBy(w => w.Name).ToList();

            var weeeParts = allWeeeParts.Where(w => string.IsNullOrEmpty(w.WeeeCategory));

            var nonWeeeSalesAnanlyses =
                salesAnalyses.Where(s => allWeeeParts.All(p => p.Name != s.ArticleNumber) && s.Quantity != 0);

            var nonWeeeSalesArticles = this.salesArticleRepository
                .FilterBy(s => nonWeeeSalesAnanlyses.Any(a => a.ArticleNumber == s.ArticleNumber))
                .OrderBy(s => s.ArticleNumber).Select(
                    s => new SalesArticle
                             {
                                 ArticleNumber = s.ArticleNumber, InvoiceDescription = s.InvoiceDescription
                             }).ToList();

            var packagingOnlyParts = allWeeeParts.Where(w => w.WeeeCategory == "PACKAGING");

            var cableParts = allWeeeParts.Where(w => w.WeeeCategory == "CABLE");

            var productColumns = this.GermanModelColumns();
            var dimensionColumns = this.GermanDimensionColumns();
            var packagingColumns = this.GermanModelColumns();
            var cableColumns = this.GermanCableColumns();
            var nonWeeeColumns = this.NonWeeeColumns();

            var weeeResultsModel = new ResultsModel
                                       {
                                           ReportTitle = new NameModel($"WEEE Products from {fromDate:d} - {toDate:d}")
                                       };
            var dimensionsResultsModel =
                new ResultsModel { ReportTitle = new NameModel("Totals by Product Dimension") };
            var packagingResultsModel = new ResultsModel { ReportTitle = new NameModel("Packaging Only") };
            var cablesResultsModel = new ResultsModel { ReportTitle = new NameModel("Cables Only") };
            var nonWeeeResultsModel = new ResultsModel { ReportTitle = new NameModel("Sales of non WEEE Products") };

            weeeResultsModel.AddSortedColumns(productColumns);
            dimensionsResultsModel.AddSortedColumns(dimensionColumns);
            packagingResultsModel.AddSortedColumns(packagingColumns);
            cablesResultsModel.AddSortedColumns(cableColumns);
            nonWeeeResultsModel.AddSortedColumns(nonWeeeColumns);

            this.reportingHelper.AddResultsToModel(
                weeeResultsModel,
                this.SetGermanModelRows(weeeSalesAnalyses, weeeParts),
                CalculationValueModelType.Quantity,
                true);
            this.reportingHelper.AddResultsToModel(
                dimensionsResultsModel,
                this.SetGermanDimensionModelRows(weeeSalesAnalyses, weeeParts),
                CalculationValueModelType.Quantity,
                true);
            this.reportingHelper.AddResultsToModel(
                packagingResultsModel,
                this.SetGermanModelRows(weeeSalesAnalyses, packagingOnlyParts),
                CalculationValueModelType.Quantity,
                true);
            this.reportingHelper.AddResultsToModel(
                cablesResultsModel,
                this.SetGermanCableModelRows(weeeSalesAnalyses, cableParts),
                CalculationValueModelType.Quantity,
                true);
            this.reportingHelper.AddResultsToModel(
                nonWeeeResultsModel,
                this.SetNonWeeeModelRows(nonWeeeSalesAnanlyses, nonWeeeSalesArticles),
                CalculationValueModelType.Quantity,
                true);

            results.Add(weeeResultsModel);
            results.Add(dimensionsResultsModel);
            results.Add(packagingResultsModel);
            results.Add(cablesResultsModel);
            results.Add(nonWeeeResultsModel);

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

                var totalWeight = salesPart.NettWeight * quantity;

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
                           new AxisDetailsModel("Weight of Mains Cables")
                               {
                                   SortOrder = 7, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                           new AxisDetailsModel("Mains Cables Per Product") { SortOrder = 8, GridDisplayType = GridDisplayType.Value }
                       };
        }

        private List<AxisDetailsModel> GermanCableColumns()
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
                               }
                       };
        }

        private List<AxisDetailsModel> GermanDimensionColumns()
        {
            return new List<AxisDetailsModel>
                       {
                           new AxisDetailsModel("Nett Weight")
                               {
                                   SortOrder = 0, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                           new AxisDetailsModel("Nett Packaging Weight")
                               {
                                   SortOrder = 1, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                           new AxisDetailsModel("Nett Packaging Foam Weight")
                               {
                                   SortOrder = 1, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               },
                           new AxisDetailsModel("Weight of Mains Cables")
                               {
                                   SortOrder = 1, GridDisplayType = GridDisplayType.Value, DecimalPlaces = 2
                               }
                       };
        }

        private List<AxisDetailsModel> NonWeeeColumns()
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
                           new AxisDetailsModel("Quantity") { SortOrder = 2, GridDisplayType = GridDisplayType.Value }
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

                var nettWeight = part.NettWeight * quantity;

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
                        Quantity = new decimal(part.PackagingNettWeight * quantity ?? 0),
                        ColumnId = "Nett Packaging Weight"
                    });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = part.Name,
                            Quantity = new decimal(part.PackagingFoamNettWeight * quantity ?? 0),
                            ColumnId = "Nett Packaging Foam Weight"
                        });


                values.Add(
                    new CalculationValueModel
                        {
                            RowId = part.Name,
                            Quantity = part.MainsCablesPerProduct ?? 0,
                            ColumnId = "Mains Cables Per Product"
                    });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = part.Name,
                            Quantity = new decimal(part.MainsCablesPerProduct * 0.25 * quantity ?? 0),
                            ColumnId = "Weight of Mains Cables"
                        });

                values.Add(
                    new CalculationValueModel
                        {
                            RowId = part.Name,
                            TextDisplay = part.DimensionOver50Cm ? "X" : string.Empty,
                            ColumnId = "Dimension Over 50cm"
                        });
            }

            return values;
        }

        private List<CalculationValueModel> SetGermanCableModelRows(
            IEnumerable<SalesAnalysis> salesAnalyses,
            IEnumerable<SalesPart> salesParts)
        {
            var values = new List<CalculationValueModel>();

            foreach (var part in salesParts)
            {
                var analyses = salesAnalyses.Where(s => s.ArticleNumber == part.Name);

                var quantity = analyses.Sum(a => a.Quantity);

                var nettWeight = part.NettWeight * quantity;

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
            }

            return values;
        }

        private List<CalculationValueModel> SetGermanDimensionModelRows(
            IEnumerable<SalesAnalysis> salesAnalyses,
            IEnumerable<SalesPart> salesParts)
        {
            var values = new List<CalculationValueModel>();

            var partsOver50Cm = salesParts.Where(p => p.DimensionOver50Cm);
            var partsUnder50Cm = salesParts.Where(p => !p.DimensionOver50Cm);

            values.Add(
                new CalculationValueModel
                    {
                        RowId = "Products Over 50 cm",
                        Quantity = new decimal(
                            salesAnalyses.Sum(
                                s => partsOver50Cm.Where(p => p.Name == s.ArticleNumber).Sum(p => p.NettWeight * s.Quantity)) ?? 0),
                        ColumnId = "Nett Weight"
                    });
            values.Add(new CalculationValueModel
                           {
                               RowId = "Products Over 50 cm",
                               Quantity = new decimal(
                                   salesAnalyses.Sum(
                                       s => partsOver50Cm.Where(p => p.Name == s.ArticleNumber)
                                           .Sum(p => p.PackagingNettWeight * s.Quantity)) ?? 0),
                               ColumnId = "Nett Packaging Weight"
                           });
            values.Add(
                new CalculationValueModel
                    {
                        RowId = "Products Over 50 cm",
                        Quantity = new decimal(
                            salesAnalyses.Sum(
                                s => partsOver50Cm.Where(p => p.Name == s.ArticleNumber)
                                    .Sum(p => p.PackagingFoamNettWeight * s.Quantity)) ?? 0),
                        ColumnId = "Nett Packaging Foam Weight"
                    });
            values.Add(new CalculationValueModel
                           {
                               RowId = "Products Over 50 cm",
                               Quantity = new decimal(
                                   salesAnalyses.Sum(
                                       s => partsOver50Cm.Where(p => p.Name == s.ArticleNumber)
                                           .Sum(p => p.MainsCablesPerProduct * 0.25 * s.Quantity)) ?? 0),
                               ColumnId = "Weight of Mains Cables"
                           });

            values.Add(
                new CalculationValueModel
                {
                    RowId = "Products Under 50 cm",
                    Quantity = new decimal(
                            salesAnalyses.Sum(
                                s => partsUnder50Cm.Where(p => p.Name == s.ArticleNumber).Sum(p => p.NettWeight * s.Quantity)) ?? 0),
                    ColumnId = "Nett Weight"
                });
            values.Add(new CalculationValueModel
            {
                RowId = "Products Under 50 cm",
                Quantity = new decimal(
                                   salesAnalyses.Sum(
                                       s => partsUnder50Cm.Where(p => p.Name == s.ArticleNumber)
                                           .Sum(p => p.PackagingNettWeight * s.Quantity)) ?? 0),
                ColumnId = "Nett Packaging Weight"
            });
            values.Add(
                new CalculationValueModel
                {
                    RowId = "Products Under 50 cm",
                    Quantity = new decimal(
                            salesAnalyses.Sum(
                                s => partsUnder50Cm.Where(p => p.Name == s.ArticleNumber)
                                    .Sum(p => p.PackagingFoamNettWeight * s.Quantity)) ?? 0),
                    ColumnId = "Nett Packaging Foam Weight"
                });
            values.Add(new CalculationValueModel
            {
                RowId = "Products Under 50 cm",
                Quantity = new decimal(
                                   salesAnalyses.Sum(
                                       s => partsUnder50Cm.Where(p => p.Name == s.ArticleNumber)
                                           .Sum(p => p.MainsCablesPerProduct * 0.25 * s.Quantity)) ?? 0),
                ColumnId = "Weight of Mains Cables"
            });

            return values;
        }

        private List<CalculationValueModel> SetNonWeeeModelRows(
            IEnumerable<SalesAnalysis> salesAnalyses,
            IEnumerable<SalesArticle> salesArticles)
        {
            var values = new List<CalculationValueModel>();

            foreach (var salesArticle in salesArticles)
            {
                var analyses = salesAnalyses.Where(s => s.ArticleNumber == salesArticle.ArticleNumber);

                var quantity = analyses.Sum(a => a.Quantity);

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = salesArticle.ArticleNumber,
                        TextDisplay = salesArticle.ArticleNumber,
                        ColumnId = "Article Number"
                    });

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = salesArticle.ArticleNumber,
                        TextDisplay = salesArticle.InvoiceDescription,
                        ColumnId = "Description"
                    });

                values.Add(
                    new CalculationValueModel
                    {
                        RowId = salesArticle.ArticleNumber,
                        Quantity = quantity,
                        ColumnId = "Quantity"
                    });
            }

            return values;
        }
    }
}