namespace Linn.Products.Service.Tests.SaCoreTypesModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingAllSaCoreTypes : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var saCoreType1 = new SaCoreType(1, "description");
            var saCoreType2 = new SaCoreType(2, "description");
            this.SaCoreTypeService.GetAll()
                .Returns(new SuccessResult<IEnumerable<SaCoreType>>(new List<SaCoreType> { saCoreType1, saCoreType2 }));

            this.Response = this.Browser.Get(
                "/products/maint/sa-core-types/",
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
            this.SaCoreTypeService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<SaCoreTypeResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.CoreType == 1);
            resources.Should().Contain(a => a.CoreType == 2);
        }
    }
}
