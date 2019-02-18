namespace Linn.Products.Domain.Linnapps.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Repositories;

    public class SaHoldStoriesReportService : ISaHoldStoriesReportService
    {
        private readonly ISaHoldStoryRepository saHoldStoryRepository;

        public SaHoldStoriesReportService(ISaHoldStoryRepository repo)
        {
            this.saHoldStoryRepository = repo;
        }

        public IEnumerable<string> GetArticleNumbersWithHoldStories()
        {
            var stories = this.saHoldStoryRepository.GetSaHoldStories().GroupBy(s => s.ArticleNumber)
                .Select(grp => grp.First());

            return stories.Select(s => new string(s.ArticleNumber));
        }

        public ResultsModel GetSaHoldStoriesReportForSalesArticle(string articleNumber)
        {
            var stories = this.saHoldStoryRepository.GetSaHoldStories().Where(s => s.ArticleNumber == articleNumber);

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

            results.RowDrillDownTemplates.Add(new DrillDownModel("story", "/products/sa-hold-stories/" + "{rowId}"));
           
            return results;
        }
    }
}
