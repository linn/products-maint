namespace Linn.Products.Domain.Linnapps.Tests.SalesArticleReallocationSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.Services;
    using NSubstitute;
    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected IRepository<SalesArticle, string> SalesArticleRepository { get; private set; } 

        protected ISalesArticleReallocationService SalesArticleReallocationService { get; set; }

        protected IList<SalesArticle> SalesArticles { get; set; }

        protected SalesArticlesReallocator Result { get; set; }


        [SetUp]
        public void SetUpContext()
        {
            this.SalesArticleRepository = Substitute.For<IRepository<SalesArticle, string>>();
            this.SalesArticleReallocationService = new SalesArticleReallocationService(this.SalesArticleRepository);

            this.SalesArticles = new List<SalesArticle>
                                  {
                                      new SalesArticle {TariffId = 118, ArticleNumber = "m"},
                                      new SalesArticle {TariffId = 118, ArticleNumber = "n"},
                                      new SalesArticle {TariffId = 118, ArticleNumber = "l"},
                                  };

            this.SalesArticleRepository.FindAll().Returns(this.SalesArticles.AsQueryable());
        }
    }
}
