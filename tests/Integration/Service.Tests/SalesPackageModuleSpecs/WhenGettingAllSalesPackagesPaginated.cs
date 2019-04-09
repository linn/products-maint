﻿
namespace Linn.Products.Service.Tests.SalesPackageModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;
    using NSubstitute.Core.Arguments;

    using NUnit.Framework;

    using PagedList.Core;

    public class WhenGettingAllSalesPackagesPaginated : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var salesPackage1 = new SalesPackage { Id = 1 };
            var salesPackage2 = new SalesPackage { Id = 2 };
            var salesPackage3 = new SalesPackage { Id = 3 };
            var salesPackage4 = new SalesPackage { Id = 4 };
            var salesPackage5 = new SalesPackage { Id = 5 };

            this.SalesPackageService.GetAll(1, 5).Returns(
                new SuccessResult<IPagedList<SalesPackage>>(
                    new PagedList<SalesPackage>(
                        new[] { salesPackage1, salesPackage2, salesPackage3, salesPackage4, salesPackage5 }
                            .AsQueryable(),
                        1,
                        5)));
            this.Response = this.Browser.Get(
                "/products/maint/sales-packages/1/5",
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
            this.SalesPackageService.Received().GetAll(1, 5);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<SalesPackagesPaginatedResource>();
            resources.SalesPackageResources.Should().HaveCount(5);
        }
    }
}
