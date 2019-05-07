namespace Linn.Products.Service.Tests.SernosUsedOnInvoiceModuleSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Reporting.Models;

    using Nancy;

    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    public class WhenGettingReportAndNoParameters : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.ReportService.GetReport(null, null)
                .Throws(new ArgumentException("Bad Arguments"));

            this.Response = this.Browser.Get(
                "/products/reports/sernos-used-on-invoice",
                with =>
                    {
                        with.Header("Accept", "application/json");
                    }).Result;
        }

        [Test]
        public void ShouldReturnBadRequest()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
