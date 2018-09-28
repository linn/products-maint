namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Reports;

    public class CartonReportsService : ICartonReportsService
    {
        private readonly ICartonDetailsReportService cartonDetailsReportService;

        public CartonReportsService(ICartonDetailsReportService cartonDetailsReportService)
        {
            this.cartonDetailsReportService = cartonDetailsReportService;
        }

        public IResult<ResultsModel> GetCartonDetails()
        {
            var results = this.cartonDetailsReportService.GetCartonsReport();
            return new SuccessResult<ResultsModel>(results);
        }
    }
}