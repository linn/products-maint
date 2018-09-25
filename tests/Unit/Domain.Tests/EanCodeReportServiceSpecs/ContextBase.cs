﻿namespace Linn.Products.Domain.Tests.EanCodeReportServiceSpecs
{
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.RemoteServices;
    using Linn.Products.Domain.Reports;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected EanCodeReportService Sut { get; private set; }

        protected ISalesArticleService SalesArticleService { get; private set; }

        protected bool IncludePhasedOut { get; set; }

        protected bool CartonisedOnly { get; set; }

        protected ResultsModel Results { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.SalesArticleService = Substitute.For<ISalesArticleService>();

            this.Sut = new EanCodeReportService(this.SalesArticleService);
        }
    }
}
