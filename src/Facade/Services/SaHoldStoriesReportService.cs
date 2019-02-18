namespace Linn.Products.Facade
{
    using System;
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Facade.Services;

    public class SaHoldStoriesReportService : ISaHoldStoriesReportService
    {
        private readonly Domain.Linnapps.Reports.ISaHoldStoriesReportService saHoldStoriesReportService;

        public SaHoldStoriesReportService(Domain.Linnapps.Reports.ISaHoldStoriesReportService saHoldStoriesReportService)
        {
            this.saHoldStoriesReportService = saHoldStoriesReportService;
        }

        public IResult<ResultsModel> GetSaHoldStories(string articleNumber)
        {
            var results = this.saHoldStoriesReportService.GetSaHoldStoriesReportForSalesArticle(articleNumber);
            return new SuccessResult<ResultsModel>(results);
        }
    }
}
