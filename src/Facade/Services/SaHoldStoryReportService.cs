namespace Linn.Products.Facade
{
    using System;
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Facade.Services;

    public class SaHoldStoryReportService : ISaHoldStoriesReportService
    {
        private readonly Domain.Linnapps.Reports.ISaHoldStoryReportService saHoldStoryReportService;

        public SaHoldStoryReportService(Domain.Linnapps.Reports.ISaHoldStoryReportService saHoldStoryReportService)
        {
            this.saHoldStoryReportService = saHoldStoryReportService;
        }

        public IResult<ResultsModel> GetSaHoldStories(string articleNumber)
        {
            var results = this.saHoldStoryReportService.GetSaHoldStoriesReportForSalesArticle(articleNumber);
            return new SuccessResult<ResultsModel>(results);
        }
    }
}
