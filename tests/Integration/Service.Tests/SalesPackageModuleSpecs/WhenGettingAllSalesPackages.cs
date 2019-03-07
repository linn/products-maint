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

    using NUnit.Framework;

    public class WhenGettingAllSalesPackages : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var salesPackage1 = new SalesPackage { Id = 1 };
            var salesPackage2 = new SalesPackage { Id = 2 };
            this.SalesPackageService.GetAll()
                .Returns(new SuccessResult<IEnumerable<SalesPackage>>(new List<SalesPackage> { salesPackage1, salesPackage2 }));

            this.Response = this.Browser.Get(
                "/products/maint/sales-packages/",
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
            this.SalesPackageService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<SalesPackageResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.Id == 1);
            resources.Should().Contain(a => a.Id == 2);
        }
    }
}
