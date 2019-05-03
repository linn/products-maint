namespace Linn.Products.Service.Tests.SalesPackageModuleSpecs
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    using PagedList.Core;

    using Expression = System.Linq.Expressions.Expression;

    internal class WhenGettingAllSalesPackagesSortedPaginated : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var salesPackage1 = new SalesPackage { SalesPackageId = "1" };
            var salesPackage2 = new SalesPackage { SalesPackageId = "2" };
            var salesPackage3 = new SalesPackage { SalesPackageId = "3" };
            var salesPackage4 = new SalesPackage { SalesPackageId = "4" };
            var salesPackage5 = new SalesPackage { SalesPackageId = "5" };

            this.SalesPackageService.GetAll(1, 5, s=>s.SalesPackageId, false).Returns<dynamic>(
                new SuccessResult<IPagedList<SalesPackage>>(
                    new PagedList<SalesPackage>(
                        new[] { salesPackage1, salesPackage2, salesPackage3, salesPackage4, salesPackage5 }
                            .AsQueryable(),
                        1,
                        5)));
            this.Response = this.Browser.Get(
                "/products/maint/sales-packages/1/5/salesPackageId/false",
                with =>
                    {
                        with.Header("Accept", "application/json");
                    }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SalesPackageService.Received().GetAll(
                1,
                5,
                Arg.Any<Expression<Func<SalesPackage, dynamic>>>(),
                false);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var response = this.Response.Body;
            var resources = this.Response.Body.DeserializeJson<SalesPackagesPaginatedResource>();
            resources.Elements.Should().HaveCount(5);
        }

        private static Expression<Func<SalesPackage, dynamic>> GetExpression()
        {
            var param = Expression.Parameter(typeof(SalesPackage));
            return Expression.Lambda<Func<SalesPackage, dynamic>>(Expression.Property(param, "salesPackageId"), param);
        }
    }
}
