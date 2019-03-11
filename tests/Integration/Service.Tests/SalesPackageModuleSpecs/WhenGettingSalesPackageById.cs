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

    public class WhenGettingSalesPackageById : ContextBase
    {
        private SalesPackage salesPackage;

        [SetUp]
        public void SetUp()
        {
            this.salesPackage = new SalesPackage
                                    {
                                        Id = 1,
                                        SalesPackageId = "one",
                                        Description = "one desc",
                                        Elements = new List<SalesPackageElementJoin>
                                                       {
                                                           new SalesPackageElementJoin
                                                               {
                                                                   BridgeId = 1,
                                                                   ElementType = "e1",
                                                                   SalesPackageId = "one",
                                                                   Id = 243434,
                                                                   SalesPackageElement = new SalesPackageElement
                                                                                             {
                                                                                                 ElementType = "e1",
                                                                                                 Quantity = 1,
                                                                                                 Sequence = 12
                                                                                             }
                                                               }
                                                       }
                                    };

            this.SalesPackageService.GetById(1).Returns(new SuccessResult<SalesPackage>(this.salesPackage));

            this.Response = this.Browser.Get(
                "/products/maint/sales-packages/1",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SalesPackageService.Received().GetById(1);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SalesPackageResource>();
            resource.Id.Should().Be(this.salesPackage.Id);
            resource.Description.Should().Be(this.salesPackage.Description);
            resource.SalesPackageId.Should().Be(this.salesPackage.SalesPackageId);
            resource.Elements.Should().HaveCount(1);
            resource.Elements.First().ElementType.Should().Be("e1");
            resource.Elements.First().Sequence.Should().Be(12);
            resource.Elements.First().Quantity.Should().Be(1);
        }
    }
}
