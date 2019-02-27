namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    public interface ISalesArticleReportService
    {
        IResult<ResultsModel> GetEanCodeResults(bool includePhasedOut = false, bool cartonisedOnly = false);

        IResult<IEnumerable<IEnumerable<string>>> GetEanCodeCsvResults(
            bool includePhasedOut = false,
            bool cartonisedOnly = false);

        IResult<ResultsModel> GetSalesArticleCoreTypes();

        IResult<IEnumerable<IEnumerable<string>>> GetSalesArticleCoreTypesCsv();
    }
}
