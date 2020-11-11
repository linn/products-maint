namespace Linn.Products.Domain.Tests.WEEEReports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Reports;
    using Linn.Products.Domain.Repositories;

    using NSubstitute;

    using NUnit.Framework;

    using Expression = Castle.DynamicProxy.Generators.Emitters.SimpleAST.Expression;

    public abstract class ContextBase
    {
        protected WEEEReports Sut { get; private set; }

        protected IReportingHelper ReportingHelper { get; private set; }

        protected ISalesPartRepository SalesPartRepository { get; private set; }

        protected IQueryRepository<SalesAnalysis> SalesAnalysisRepository { get; private set; }

        protected IRepository<SalesArticle, string> SalesArticleRepository { get; set; }

            [SetUp]
        public void SetUpContext()
        {
            this.SalesPartRepository = Substitute.For<ISalesPartRepository>();
            this.ReportingHelper = new ReportingHelper();
            this.SalesAnalysisRepository = Substitute.For<IQueryRepository<SalesAnalysis>>();
            this.SalesArticleRepository = Substitute.For<IRepository<SalesArticle, string>>();

            this.SalesPartRepository.GetWEEESalesParts().Returns(
                new List<SalesPart>
                    {
                        new SalesPart
                            {
                                Name = "P1",
                                Description = "DESC1",
                                NettWeight = 2,
                                PackagingNettWeight = 2,
                                PackagingFoamNettWeight = 2,
                                MainsCablesPerProduct = 1,
                                DimensionOver50Cm = true,
                                WeeeProduct = true
                            },
                        new SalesPart
                            {
                                Name = "P2",
                                Description = "DESC2",
                                NettWeight = 2,
                                PackagingNettWeight = 2,
                                PackagingFoamNettWeight = 2,
                                MainsCablesPerProduct = 1,
                                DimensionOver50Cm = false,
                                WeeeProduct = true
                            },
                        new SalesPart
                            {
                                Name = "P3",
                                Description = "DESC3",
                                PackagingNettWeight = 0.5,
                                WeeeCategory = "PACKAGING",
                                WeeeProduct = true
                            },
                        new SalesPart
                            {
                                Name = "P4",
                                Description = "DESC4",
                                NettWeight = 0.25,
                                WeeeCategory = "CABLE",
                                WeeeProduct = true
                            }
                    });

            this.SalesAnalysisRepository.FilterBy(Arg.Any<Expression<Func<SalesAnalysis, bool>>>()).Returns(
                new List<SalesAnalysis>
                    {
                        new SalesAnalysis { ArticleNumber = "P1", Quantity = 2 },
                        new SalesAnalysis { ArticleNumber = "P2", Quantity = 1 },
                        new SalesAnalysis { ArticleNumber = "P3", Quantity = 1 },
                        new SalesAnalysis { ArticleNumber = "P4", Quantity = 1 },
                        new SalesAnalysis { ArticleNumber = "P5", Quantity = 1 }
                    }.AsQueryable());

            this.SalesArticleRepository.FilterBy(Arg.Any<Expression<Func<SalesArticle, bool>>>()).Returns(
                new List<SalesArticle> { new SalesArticle { ArticleNumber = "P5", InvoiceDescription = "DESC5" }, }
                    .AsQueryable());

            this.Sut = new WEEEReports(
                this.SalesAnalysisRepository,
                this.ReportingHelper,
                this.SalesPartRepository,
                this.SalesArticleRepository);
        }
    }
}


