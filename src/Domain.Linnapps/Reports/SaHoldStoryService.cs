namespace Linn.Products.Domain.Linnapps.Reports
{
    using System;
    using System.Linq;

    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;

    public class SaHoldStoryService : ISaHoldStoryService
    {
        private readonly IRepository<SaHoldStory, int> saHoldStoryRepository;

        public SaHoldStoryService(IRepository<SaHoldStory, int> repo)
        {
            this.saHoldStoryRepository = repo;
        }

        public ResultsModel GetHoldStoriesForSalesArticle(string articleNumber)
        {
            var stories = this.saHoldStoryRepository.FindAll().Where(s => s.SalesArticle.ArticleNumber == articleNumber);

            var results = new ResultsModel(new[] { "Date Started", "Date Finished"})
                              {
                                  RowHeader = "Name",
                                  ReportTitle = new NameModel("Hold Stories")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);

            foreach (var story in stories.OrderByDescending(a => a.DateStarted))
            {
                var row = results.AddRow(story.HoldStoryId.ToString().Replace("/", "%2F"));
                results.SetGridTextValue(row.RowIndex, 0, story.DateStarted.ToShortDateString());
                results.SetGridTextValue(row.RowIndex, 1, story.DateFinished != null ? ((DateTime)story.DateFinished).ToShortDateString() : story.DateFinished.ToString());
            }

            results.RowDrillDownTemplates.Add(new DrillDownModel("story", "/products/reports/sa-hold-stories/{rowId}"));
           
            return results;
        }

        public ResultsModel GetHoldStoriesForRootProduct(string rootProduct)
        {
            var stories = this.saHoldStoryRepository.FindAll().Where(s => s.RootProduct.Name == rootProduct);

            var results = new ResultsModel(new[] { "Date Started", "Date Finished" })
                              {
                                  RowHeader = "Name",
                                  ReportTitle = new NameModel("Hold Stories")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);

            foreach (var story in stories.OrderByDescending(a => a.DateStarted))
            {
                var row = results.AddRow(story.HoldStoryId.ToString().Replace("/", "%2F"));
                results.SetGridTextValue(row.RowIndex, 0, story.DateStarted.ToShortDateString());
                results.SetGridTextValue(row.RowIndex, 1, story.DateFinished != null ? ((DateTime)story.DateFinished).ToShortDateString() : story.DateFinished.ToString());
            }

            results.RowDrillDownTemplates.Add(new DrillDownModel("story", "/products/reports/sa-hold-stories/{rowId}"));

            return results;
        }
    }
}
