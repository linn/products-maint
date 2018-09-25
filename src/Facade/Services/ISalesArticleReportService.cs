namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    public interface ISalesArticleReportService
    {
        IResult<ResultsModel> GetEanCodeResults();

        IResult<IEnumerable<IEnumerable<string>>> GetEanCodeCsvResults();
    }
}
