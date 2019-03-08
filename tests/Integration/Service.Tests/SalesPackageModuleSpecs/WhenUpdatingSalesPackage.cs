namespace Linn.Products.Service.Tests.SalesPackageModuleSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSalesPackage : ContextBase
    {
        private SalesPackage salesPackage;

        private SalesPackageResource resource;

        [SetUp]
        public void SetUp()
        {
            this.salesPackage = new SalesPackage { Id = 3, Elements = new List<SalesPackageElementJoin>() };
            this.resource = new SalesPackageResource
                                {
                                    Description = "desc"
                                };
            this.SalesPackageService.Update(3, Arg.Any<SalesPackageResource>())
                .Returns(new SuccessResult<SalesPackage>(this.salesPackage));

            this.Response = this.Browser.Put(
                "/products/maint/sales-packages/3",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Header("Content-Type", "application/json");
                        with.JsonBody(this.resource);
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
            this.SalesPackageService.Received().Update(
                3,
                Arg.Is<SalesPackageResource>(r => r.Description == this.resource.Description));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var response = this.Response.Body.DeserializeJson<SalesPackageResource>();
            response.Id.Should().Be(this.salesPackage.Id);
        }
    }
}