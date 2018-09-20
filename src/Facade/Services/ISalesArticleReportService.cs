namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    public interface ISalesArticleReportService
    {
        IResult<ResultsModel> GetEanCodeResults();
    }
}
