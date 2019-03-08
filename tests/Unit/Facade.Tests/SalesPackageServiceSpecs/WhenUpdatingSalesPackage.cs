namespace Linn.Products.Facade.Tests.SalesPackageServiceSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSalesPackage : ContextBase
    {
        private IResult<SalesPackage> result;

        private SalesPackageResource resource;

        private SalesPackage salesPackage;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SalesPackageResource
                                {
                                    Id = 11,
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
            this.salesPackage = new SalesPackage
                                    {
                                        Id = 11,
                                        SalesPackageId = "package",
                                        Elements = new List<SalesPackageElementJoin>
                                                       {
                                                           new SalesPackageElementJoin
                                                               {
                                                                   Id = 1,
                                                                   BridgeId = 11,
                                                                   ElementType = "main bit",
                                                                   SalesPackageElement = new SalesPackageElement
                                                                                             {
                                                                                                 SalesPackageId = "package",
                                                                                                 ElementType = "main bit",
                                                                                                 Quantity = 11,
                                                                                                 Sequence = 11
                                                                                             }
                                                               },
                                                           new SalesPackageElementJoin
                                                               {
                                                                   Id = 1,
                                                                   BridgeId = 11,
                                                                   ElementType = "old bit",
                                                                   SalesPackageElement = new SalesPackageElement
                                                                                             {
                                                                                                 SalesPackageId = "package",
                                                                                                 ElementType = "old bit",
                                                                                                 Quantity = 11,
                                                                                                 Sequence = 11
                                                                                             }
                                                               }
                                                       }
                                    };
            this.SalesPackageRepository.FindById(11)
                .Returns(this.salesPackage);
            this.result = this.Sut.Update(11, this.resource);
        }

        [Test]
        public void ShouldGetSalesPackage()
        {
            this.SalesPackageRepository.Received().FindById(11);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<SalesPackage>>();
            var dataResult = ((SuccessResult<SalesPackage>)this.result).Data;
            dataResult.Description.Should().Be(this.resource.Description);
            dataResult.SalesPackageId.Should().Be("package");
            dataResult.Id.Should().Be(11);
            dataResult.Elements.Should().HaveCount(3);
        }
    }
}
