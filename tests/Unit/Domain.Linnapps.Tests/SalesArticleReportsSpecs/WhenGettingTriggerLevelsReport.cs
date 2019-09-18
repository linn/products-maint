namespace Linn.Products.Domain.Linnapps.Tests.SalesArticleReportsSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingTriggerLevelsReport : ContextBase
    {
        private IEnumerable<ProductionTriggerLevel> triggerLevels;

        [SetUp]
        public void SetUp()
        {
            this.triggerLevels = new List<ProductionTriggerLevel>
                                     {
                                         new ProductionTriggerLevel { PartNumber = "P1", KanbanSize = 1, VariableTriggerLevel = 2, OverrideTriggerLevel = 3, CitCode = "C" },
                                         new ProductionTriggerLevel { PartNumber = "P2", KanbanSize = 4, VariableTriggerLevel = 1, CitCode = "D" }
                                     };
            var salesArticle1 = new SalesArticle
                                    {
                                        ArticleNumber = "P1",
                                        InvoiceDescription = "a1d",
                                        SaCoreType = new SaCoreType(1, "one")
                                    };
            var salesArticle2 = new SalesArticle
                                    {
                                        ArticleNumber = "P2",
                                        InvoiceDescription = "b2d",
                                        SaCoreType = new SaCoreType(2, "two")
                                    };
            this.ProductionTriggerLevelsService.GetAll().Returns(this.triggerLevels.AsQueryable());
            this.SalesArticleRepository.FindById("P1").Returns(salesArticle1);
            this.SalesArticleRepository.FindById("P2").Returns(salesArticle2);

            this.Results = this.Sut.SalesArticleTriggerLevelsReport();
        }

        [Test]
        public void ShouldSetTitle()
        {
            this.Results.ReportTitle.DisplayValue.Should().Be("Sales Article Trigger Levels");
        }

        [Test]
        public void ShouldGetTriggerLevelsFromProxyService()
        {
            this.ProductionTriggerLevelsService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.Results.GetRowValues().Should().HaveCount(2);
            this.Results.Rows.First(a => a.RowIndex == 0).RowTitle.Should().Be("P1");
            this.Results.Rows.First(a => a.RowIndex == 1).RowTitle.Should().Be("P2");
            this.Results.GetGridTextValue(0, 0).Should().Be("C");
            this.Results.GetGridTextValue(0, 1).Should().Be("one");
            this.Results.GetGridTextValue(0, this.Results.ColumnIndex("Variable Trigger")).Should().Be("2");
            this.Results.GetGridTextValue(0, this.Results.ColumnIndex("Override Trigger")).Should().Be("3");
            this.Results.GetGridTextValue(0, this.Results.ColumnIndex("Kanban Size")).Should().Be("1");
            this.Results.GetGridTextValue(1, this.Results.ColumnIndex("Override Trigger")).Should().BeNull();
        }
    }
}
