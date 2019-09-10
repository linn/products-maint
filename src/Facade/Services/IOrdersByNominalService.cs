namespace Linn.Products.Facade.Services
{
    using System;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    public interface IOrdersByNominalService
    {
        IResult<ResultsModel> GetOrdersByNominalReport(DateTime from, DateTime to, string nominal = null);
    }
}