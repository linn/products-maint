namespace Linn.Products.Facade.Tests.SalesPackageServiceSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAddingSalesPackage : ContextBase
    {
        private IResult<SalesPackage> result;

        private SalesPackageResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SalesPackageResource
                                {
                                    SalesPackageId = "package don't change this",
                                    Description = "new desc",
                                    Elements = new List<SalesPackageElementResource>
                                                   {
                                                       new SalesPackageElementResource
                                                           {
                                                               ElementType = "main bit", Quantity = 1, Sequence = 1
                                                           },
                                                       new SalesPackageElementResource
                                                           {
                                                               ElementType = "other bit", Quantity = 1, Sequence = 2
                                                           },
                                                       new SalesPackageElementResource
                                                           {
                                                               ElementType = "top bit", Quantity = 2, Sequence = 3
                                                           }
                                                   }
            };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldAddSalesPackage()
        {
            this.SalesPackageRepository.Received().Add(Arg.Is<SalesPackage>(s => s.Description == this.resource.Description));
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<CreatedResult<SalesPackage>>();
            var dataResult = ((CreatedResult<SalesPackage>)this.result).Data;
            dataResult.Description.Should().Be(this.resource.Description);
            dataResult.SalesPackageId.Should().Be(this.resource.SalesPackageId);
            dataResult.Elements.Should().HaveCount(3);
        }
    }
}
