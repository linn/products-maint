namespace Linn.Products.Facade.Services
{
    using System;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Reports;
                                                                                        
    public class OrdersByNominalService : IOrdersByNominalService
    {
        private readonly IOrdersByNominalReportService reportService;

        public OrdersByNominalService(IOrdersByNominalReportService reportService)
        {
            this.reportService = reportService;
        }

        public IResult<ResultsModel> GetOrdersByNominalReport(DateTime from, DateTime to, string nominal)
        {
            return new SuccessResult<ResultsModel>(this.reportService.GetOrdersByNominal(from, to, nominal));
        }
    }
}