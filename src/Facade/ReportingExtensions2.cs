namespace Linn.Products.Facade
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.ReportModels;

    public static class ReportingExtensions2
    {
        public static IEnumerable<IEnumerable<string>> ConvertFinalModelToCsvResource(this ResultsModel resultsModel)
        {
            var csv = new List<List<string>>();
            var headerRow = new List<string> { resultsModel.RowHeader };
            headerRow.AddRange(resultsModel.Columns.Select(a => a.ColumnHeader));
            csv.Add(headerRow);

            var rows = resultsModel.GetRowValues()
                .OrderBy(a => resultsModel.Rows.First(r => r.RowIndex == a.RowIndex).SortOrder);
            csv.AddRange(rows.Select(resultsRowModel =>
                new List<string>(
                    ConvertToList(
                        resultsModel.Rows.First(r => r.RowIndex == resultsRowModel.RowIndex).RowTitle,
                        resultsRowModel.Values,
                        resultsModel.ColumnCount()))));
            return csv;
        }

        private static IEnumerable<string> ConvertToList(
            string rowTitle,
            SortedDictionary<int, ValueModel> values,
            int columnCount)
        {
            var list = new List<string>();
            if (!string.IsNullOrEmpty(rowTitle))
            {
                list.Add(rowTitle);
            }

            if (values == null)
            {
                return list;
            }

            for (var i = 0; i < columnCount; i++)
            {
                values.TryGetValue(i, out var value);
                list.Add(value?.TextDisplayValue ?? value?.DisplayValue?.ToString());
            }

            return list;
        }
    }
}