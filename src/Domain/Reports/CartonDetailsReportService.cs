namespace Linn.Products.Domain.Reports
{
    using System.Linq;

    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Repositories;

    public class CartonDetailsReportService : ICartonDetailsReportService
    {
        private readonly ICartonRepository cartonRepository;

        public CartonDetailsReportService(ICartonRepository cartonRepository)
        {
            this.cartonRepository = cartonRepository;
        }

        public ResultsModel GetCartonsReport()
        {
            var cartons = this.cartonRepository.GetCartons();

            var results = new ResultsModel(new[] { "Description", "Height", "Width", "Depth" })
                              {
                                  RowHeader = "Name",
                                  ReportTitle = new NameModel("Carton Details")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);

            foreach (var carton in cartons.OrderBy(a => a.Name))
            {
                var row = results.AddRow(carton.Name);
                results.SetGridTextValue(row.RowIndex, 0, carton.Description);
                results.SetGridValue(row.RowIndex, 1, (decimal)carton.Height);
                results.SetGridValue(row.RowIndex, 2, (decimal)carton.Width);
                results.SetGridValue(row.RowIndex, 3, (decimal)carton.Depth);
            }

            return results;
        }
    }
}
