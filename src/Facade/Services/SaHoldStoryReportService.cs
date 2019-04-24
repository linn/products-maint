namespace Linn.Products.Facade
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Reports;
    using Linn.Products.Facade.Services;

    public class SaHoldStoryReportService : ISaHoldStoriesReportService
    {
        private readonly ISaHoldStoryService saHoldStoryService;

        public SaHoldStoryReportService(ISaHoldStoryService saHoldStoryService)
        {
            this.saHoldStoryService = saHoldStoryService;
        }

        public IResult<ResultsModel> GetHoldStoriesForSalesArticle(string articleNumber)
        {
            var results = this.saHoldStoryService.GetHoldStoriesForSalesArticle(articleNumber);
            return new SuccessResult<ResultsModel>(results);
        }

        public IResult<ResultsModel> GetHoldStoriesForRootProduct(string rootProductName)
        {
            var results = this.saHoldStoryService.GetHoldStoriesForRootProduct(rootProductName);
            return new SuccessResult<ResultsModel>(results);
        }
    }
}
